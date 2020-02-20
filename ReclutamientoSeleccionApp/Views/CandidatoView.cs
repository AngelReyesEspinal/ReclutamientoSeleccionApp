using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
using ReclutamientoSeleccionApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReclutamientoSeleccionApp.Views
{
    public partial class CandidatoView : Form
    {
        private readonly CandidatoService _candidatoService;
        private readonly PuestoService _puestoService;
        private readonly DepartamentoService _departamentoService;
        private readonly CompetenciaService _competenciaService;
        private readonly CapacitacionService _capacitacionService;
        private readonly ExperienciaLaboralService _experienciaLaboralService;
        private readonly IdiomaService _idiomaService;
        private int candidatoId = 0;
        //
        private List<Puesto> _puestos;
        private List<ExperienciaLaboral> _experienciasLaborales;
        private List<Departamento> _departamentos;
        private List<Idioma> _idiomas;
        private List<Competencia> _competencias;
        public CandidatoView()
        {
            InitializeComponent();
            _idiomas = new List<Idioma>();
            _puestos = new List<Puesto>();
            _experienciasLaborales = new List<ExperienciaLaboral>();
            _competencias = new List<Competencia>();
            _departamentos = new List<Departamento>();
            //
            _candidatoService = new CandidatoService();
            _idiomaService = new IdiomaService();
            _puestoService = new PuestoService();
            _competenciaService = new CompetenciaService();
            _departamentoService = new DepartamentoService();
            _capacitacionService = new CapacitacionService();
            _experienciaLaboralService = new ExperienciaLaboralService();
            //CurrentUser.Nombre;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void CandidatoView_Load(object sender, EventArgs e)
        {
            var candidatoCreado = await _candidatoService.GetCandidatoByUserId(CurrentUser.Id);
            
            _idiomas = (await _idiomaService.GetActiveLanguages()).ToList();
            _departamentos = (await _departamentoService.GetAll()).ToList();
            _experienciasLaborales = (await _experienciaLaboralService.GetAll()).ToList();

            foreach (var experiencias in _experienciasLaborales)
            {
                checkedListBox2.Items.Add(experiencias);
                checkedListBox2.DisplayMember = "PuestoOcupado";
                checkedListBox2.ValueMember = "Id";
            }

            foreach (var idioma in _idiomas)
            {
                checkedListBox1.Items.Add(idioma);
                checkedListBox1.DisplayMember = "Nombre";
                checkedListBox1.ValueMember = "Id";
            }

            foreach (var departamento in _departamentos)
            {
                DepartamentoComboBox.Items.Add(departamento);
                DepartamentoComboBox.DisplayMember = "Nombre";
                DepartamentoComboBox.ValueMember = "Id";
            }
            
            if (candidatoCreado != null) {
                var departamento = _departamentos.Find(x => x.Id == candidatoCreado.DepartamentoId);
                var puesto = departamento.Puestos.FirstOrDefault(x => x.Id == candidatoCreado.PuestoId);

                candidatoId = candidatoCreado.Id;
                CedulaTxtBox.Text = candidatoCreado.Cedula;
                NombresTxtBox.Text = candidatoCreado.Nombres;
                ApellidoTxtBox.Text = candidatoCreado.Apellidos;
                recomendadoPorTxtBox.Text = candidatoCreado.RecomendadoPor;
                DepartamentoComboBox.SelectedItem = departamento;
                PuestoComboBox.SelectedItem = puesto;
                SalarioAspiradoTxtBox.Text = Convert.ToString(candidatoCreado.Salario);

                foreach (var capacitacionBD in candidatoCreado.Capacitaciones)
                {
                    for (int i = 0; i < CapacitacionesListBox2.Items.Count; i++)
                    {
                        var capacitacion = (Capacitacion)CapacitacionesListBox2.Items[i];
                        if (capacitacion.Id == capacitacionBD.Id)
                        {
                            CapacitacionesListBox2.SetItemChecked(i, true);
                        }
                    }
                }

                foreach (var competenciaBD in candidatoCreado.Competencias)
                {
                    for (int i = 0; i < CompetenciasListBox2.Items.Count; i++)
                    {
                        var competencia = (Competencia)CompetenciasListBox2.Items[i];
                        if (competencia.Id == competenciaBD.Id)
                        {
                            CompetenciasListBox2.SetItemChecked(i, true);
                        }
                    }
                }

                foreach (var idiomaDb in candidatoCreado.Idiomas)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        var idioma = (Idioma)checkedListBox1.Items[i];
                        if (idioma.Id == idiomaDb.Id)
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                foreach (var experienciaDb in candidatoCreado.ExperienciasLaborales)
                {
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                    {
                        var experiencia = (ExperienciaLaboral)checkedListBox2.Items[i];
                        if (experiencia.Id == experienciaDb.Id)
                        {
                            checkedListBox2.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (
                !String.IsNullOrWhiteSpace(CedulaTxtBox.Text) &&
                !String.IsNullOrWhiteSpace(NombresTxtBox.Text) &&
                !String.IsNullOrWhiteSpace(ApellidoTxtBox.Text) &&
                !String.IsNullOrWhiteSpace(recomendadoPorTxtBox.Text) &&
                !String.IsNullOrWhiteSpace(DepartamentoComboBox.Text) &&
                !String.IsNullOrWhiteSpace(PuestoComboBox.Text) &&
                !String.IsNullOrWhiteSpace(SalarioAspiradoTxtBox.Text)
            )
            {
                showLoading();
                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                var departamento = (Departamento)DepartamentoComboBox.SelectedItem;
                var idiomas = new List<Idioma>();
                var capacitaciones = new List<Capacitacion>();
                var competencias = new List<Competencia>();
                var experiencias = new List<ExperienciaLaboral>();

                foreach (var idioma in checkedListBox1.CheckedItems)
                {
                    idiomas.Add((Idioma)idioma);
                }
                
                foreach (var capacitacion in CapacitacionesListBox2.CheckedItems)
                {
                    capacitaciones.Add((Capacitacion)capacitacion);
                }

                foreach (var competencia in CompetenciasListBox2.CheckedItems)
                {
                    competencias.Add((Competencia)competencia);
                }

                foreach (var experiencia in checkedListBox2.CheckedItems)
                {
                    experiencias.Add((ExperienciaLaboral)experiencia);
                }

                var entity = new Candidato()
                {
                    Id = candidatoId,
                    Cedula = CedulaTxtBox.Text,
                    PuestoId = puesto.Id,
                    DepartamentoId = departamento.Id,
                    Nombres = NombresTxtBox.Text,
                    Apellidos = ApellidoTxtBox.Text,
                    RecomendadoPor = recomendadoPorTxtBox.Text,
                    Salario = Convert.ToDecimal(SalarioAspiradoTxtBox.Text),
                    Idiomas = idiomas,
                    Capacitaciones = capacitaciones,
                    Competencias = competencias,
                    ExperienciasLaborales = experiencias,
                    UserId = CurrentUser.Id
                };
                await _candidatoService.AssociateAndSave(entity);

                string accionRealizada = candidatoId == 0 ? "guardado" : "editado";
                MessageBox.Show("Se ha " + accionRealizada + " su perfil correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hideLoading();
            }
            else
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void showPuestosLoading()
        {
            puestosLoading.Visible = true;
        }

        private void hidePuestosLoading()
        {
            puestosLoading.Visible = false;
        }

        // general loading
        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        // end loading zone

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContraseniaTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var deptarmentoView = new DepartamentoView();
            Hide();
            deptarmentoView.Show();
            Dispose();
        }

        private void NivelesDeRiesgoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PuestoComboBox.SelectedItem != null) {
                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                SalarioMaximoLabel.Text = Convert.ToString(puesto.SalarioMaximo);
                SalarioMinimoLabel.Text = Convert.ToString(puesto.SalarioMinimo);
                NivelDeRiesgoLabel.Text = Convert.ToString(puesto.NivelDeRiesgo);
                //
                var capacitaciones = _capacitacionService.GetActiveByPuestoNotAsync(puesto.Id).ToList();
                CapacitacionesListBox2.Items.Clear();
                CapacitacionesListBox2.SelectedItem = null;
                CapacitacionesListBox2.Text = null;
                foreach (var competencia in capacitaciones)
                {
                    competencia.Descripcion = competencia.Descripcion + " (" +  competencia.Nivel.Titulo + ")";
                    CapacitacionesListBox2.Items.Add(competencia);
                    CapacitacionesListBox2.DisplayMember = "Descripcion";
                    CapacitacionesListBox2.ValueMember = "Id";
                }
                //                
                var competencias = _competenciaService.GetActiveByPuestoNotAsync(puesto.Id).ToList();
                CompetenciasListBox2.Items.Clear();
                CompetenciasListBox2.SelectedItem = null;
                CompetenciasListBox2.Text = null;
                foreach (var competencia in competencias)
                {
                    CompetenciasListBox2.Items.Add(competencia);
                    CompetenciasListBox2.DisplayMember = "Descripcion";
                    CompetenciasListBox2.ValueMember = "Id";
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void DepartamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPuestosLoading();

            PuestoComboBox.Items.Clear();
            PuestoComboBox.SelectedItem = null;
            PuestoComboBox.Text = null;

            CapacitacionesListBox2.Items.Clear();
            CapacitacionesListBox2.SelectedItem = null;
            CapacitacionesListBox2.Text = null;

            CompetenciasListBox2.Items.Clear();
            CompetenciasListBox2.SelectedItem = null;
            CompetenciasListBox2.Text = null;

            SalarioMaximoLabel.Text = "";
            SalarioMinimoLabel.Text = "";
            NivelDeRiesgoLabel.Text = "";

            if (DepartamentoComboBox.SelectedItem != null) {
                var dept = (Departamento)DepartamentoComboBox.SelectedItem;
                foreach (var puesto in dept.Puestos.Where(x => !x.Deleted).ToList())
                {
                    PuestoComboBox.Items.Add(puesto);
                    PuestoComboBox.DisplayMember = "Nombre";
                    PuestoComboBox.ValueMember = "Id";
                }
            }
            hidePuestosLoading();
        }

        private void SalarioAspiradoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var idiomaView = new IdiomaView();
            Hide();
            idiomaView.Show();
            Dispose();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var competenciaView = new CompetenciaView();
            Hide();
            competenciaView.Show();
            Dispose();
        }

        private void CompetenciasListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // aqui
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var capacitacionView = new CapacitacionView();
            Hide();
            capacitacionView.Show();
            Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nivelView = new NivelView();
            Hide();
            nivelView.Show();
            Dispose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var institucionView = new InstitucionView();
            Hide();
            institucionView.Show();
            Dispose();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var experienciaLaboralView = new ExperienciaLaboralView();
            Hide();
            experienciaLaboralView.Show();
            Dispose();
        }

        private void CapacitacionesListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DepartamentoComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
