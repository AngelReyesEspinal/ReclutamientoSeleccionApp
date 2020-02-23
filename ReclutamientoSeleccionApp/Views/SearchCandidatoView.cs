using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
using ReclutamientoSeleccionApp.DataModel.Models;
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
using static ReclutamientoSeleccionApp.Core.DataModel.CurrentUser.CurrentUser;

namespace ReclutamientoSeleccionApp.Views
{
    public partial class SearchCandidatoView : Form
    {
        private readonly CandidatoService _candidatoService;
        private readonly PuestoService _puestoService;
        private readonly CompetenciaService _competenciaService;
        private readonly CapacitacionService _capacitacionService;
        private readonly DepartamentoService _departamentoService;
        private readonly IdiomaService _idiomasService;
        //
        private List<Puesto> _puestos;
        private List<Idioma> _idiomas;
        private List<Competencia> _competencias;
        private List<Capacitacion> _capacitaciones;
        private List<Departamento> _departamentos;
        public SearchCandidatoView()
        {
            InitializeComponent();
            _departamentoService = new DepartamentoService();
            _capacitacionService = new CapacitacionService();
            _competenciaService = new CompetenciaService();
            _puestoService = new PuestoService();
            _candidatoService = new CandidatoService();
            _idiomasService = new IdiomaService();
            //
            _puestos = new List<Puesto>();
            _competencias = new List<Competencia>();
            _capacitaciones = new List<Capacitacion>();
            _departamentos = new List<Departamento>();
            _idiomas = new List<Idioma>();
        }

      
    private void update_dataGridView(List<Candidato> candidatos)
    {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = candidatos;
    }

    private async void SearchCandidatoView_Load(object sender, EventArgs e)
        {
            _puestos = (await _puestoService.GetAll()).ToList();
            _capacitaciones = (await _capacitacionService.GetAll()).ToList();
            _competencias = (await _competenciaService.GetAll()).ToList();
            _departamentos = (await _departamentoService.GetAll()).ToList();
            _idiomas = (await _idiomasService.GetAll()).ToList();

            foreach (var departamento in _departamentos)
            {
                DepartamentoComboBox.Items.Add(departamento);
                DepartamentoComboBox.DisplayMember = "Nombre";
                DepartamentoComboBox.ValueMember = "Id";
            }

            foreach (var idioma in _idiomas)
            {
                IdiomaComboBox.Items.Add(idioma);
                IdiomaComboBox.DisplayMember = "Nombre";
                IdiomaComboBox.ValueMember = "Id";
            }
        }

        private void CapacitacionesListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        private void DepartamentocomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showLoading();

            PuestoComboBox.Items.Clear();
            PuestoComboBox.SelectedItem = null;
            PuestoComboBox.Text = null;

            CapacitacionesListBox2.Items.Clear();
            CapacitacionesListBox2.SelectedItem = null;
            CapacitacionesListBox2.Text = null;

            CompetenciasListBox2.Items.Clear();
            CompetenciasListBox2.SelectedItem = null;
            CompetenciasListBox2.Text = null;

            if (DepartamentoComboBox.SelectedItem != null)
            {
                var dept = (Departamento)DepartamentoComboBox.SelectedItem;
                foreach (var puesto in dept.Puestos.Where(x => !x.Deleted).ToList())
                {
                    PuestoComboBox.Items.Add(puesto);
                    PuestoComboBox.DisplayMember = "Nombre";
                    PuestoComboBox.ValueMember = "Id";
                }
            }
            hideLoading();
        }

        private void PuestoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PuestoComboBox.SelectedItem != null)
            {
                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                //
                var capacitaciones = _capacitacionService.GetActiveByPuestoNotAsync(puesto.Id).ToList();
                CapacitacionesListBox2.Items.Clear();
                CapacitacionesListBox2.SelectedItem = null;
                CapacitacionesListBox2.Text = null;
                foreach (var competencia in capacitaciones)
                {
                    competencia.Descripcion = competencia.Descripcion + " (" + competencia.Nivel.Titulo + ")";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(DepartamentoComboBox.Text)
            || !String.IsNullOrWhiteSpace(NombreTxtBox.Text)
            || !String.IsNullOrWhiteSpace(IdiomaComboBox.Text))
            {
                showLoading();

                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                var departamento = (Departamento)DepartamentoComboBox.SelectedItem;
                var capacitacion = (Capacitacion)CapacitacionesListBox2.SelectedItem;
                var competencia = (Competencia)CompetenciasListBox2.SelectedItem;
                var idioma = (Idioma)IdiomaComboBox.SelectedItem;

                var searchModel = new SearchCandidatosModel {
                    Nombres = NombreTxtBox.Text,
                    Puesto = puesto,
                    Departamento = departamento,
                    Capacitacion = capacitacion,
                    Competencia = competencia,
                    Idioma = idioma
                };

                var result =  _candidatoService.AdvanceSearch(searchModel);
                update_dataGridView(result);

                hideLoading();
            } else
                MessageBox.Show("Debe escribir el nombre o almenos seleciconar un departamento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sePuedeEditar = true;
            string mensaje = "";

            if (dataGridView1.SelectedRows.Count == 0)
            {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar una fila";
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar solo la fila del candidato que desea ver";
            }

            if (!sePuedeEditar)
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            CandidatoSelected.Id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].FormattedValue.ToString());
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NombreTxtBox.Text = "";
            DepartamentoComboBox.SelectedItem = null;
            PuestoComboBox.SelectedItem = null;
            IdiomaComboBox.SelectedItem = null;
            CompetenciasListBox2.SelectedItem = null;
            CapacitacionesListBox2.SelectedItem = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }
    }
}
