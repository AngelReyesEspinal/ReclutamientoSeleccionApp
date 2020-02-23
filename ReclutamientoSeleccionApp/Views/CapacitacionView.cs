using ReclutamientoSeleccionApp.Bl.Services.UserService;
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
    public partial class CapacitacionView : Form
    {
        private readonly CapacitacionService _capacitacionService;
        private readonly NivelService _nivelService;
        private readonly InstitucionService _institucionService;
        private readonly DepartamentoService _departamentoService;
        private List<Departamento> _departamentos;
        private List<Nivel> _niveles;
        private List<Institucion> _instituciones;
        private int _rowSelectedId = 0;
        public CapacitacionView()
        {
            InitializeComponent();
            _capacitacionService = new CapacitacionService();
            _nivelService = new NivelService();
            _institucionService = new InstitucionService();
            _departamentoService = new DepartamentoService();
            _departamentos = new List<Departamento>();
            _niveles = new List<Nivel>();
            _instituciones = new List<Institucion>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var deptarmentoView = new DepartamentoView();
            Hide();
            deptarmentoView.Show();
            Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idiomaView = new IdiomaView();
            Hide();
            idiomaView.Show();
            Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var competenciaView = new CompetenciaView();
            Hide();
            competenciaView.Show();
            Dispose();
        }

        private void button12_Click(object sender, EventArgs e)
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
            var nivelView = new InstitucionView();
            Hide();
            nivelView.Show();
            Dispose();
        }
        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        private async void CapacitacionView_Load(object sender, EventArgs e)
        {
            update_dataGridView();
            showLoading();

            _departamentos = (await _departamentoService.GetAll()).ToList();
            _niveles = (await _nivelService.GetAll()).ToList();
            _instituciones = (await _institucionService.GetAll()).ToList();

            foreach (var departamento in _departamentos)
            {
                DepartamentoComboBox.Items.Add(departamento);
                DepartamentoComboBox.DisplayMember = "Nombre";
                DepartamentoComboBox.ValueMember = "Id";
            }
            foreach (var dept in _niveles)
            {
                NivelComboBox.Items.Add(dept);
                NivelComboBox.DisplayMember = "Titulo";
                NivelComboBox.ValueMember = "Id";
            }
            foreach (var isntitucion in _instituciones)
            {
                IntitucionComboBox.Items.Add(isntitucion);
                IntitucionComboBox.DisplayMember = "NombreInstitucion";
                IntitucionComboBox.ValueMember = "Id";
            }

            hideLoading();
        }
        private async void update_dataGridView()
        {
            refreshTable();
        }

        private void DepartamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerPuestos();
        }

        public void ObtenerPuestos()
        {
            if (DepartamentoComboBox.SelectedItem != null)
            {
                var dept = (Departamento)DepartamentoComboBox.SelectedItem;
                updatePuestos(dept.Puestos.Where(x => !x.Deleted).ToList());
            }
        }

        public void updatePuestos(List<Puesto> puestos)
        {
            PuestoComboBox.Items.Clear();
            PuestoComboBox.SelectedItem = null;
            PuestoComboBox.Text = null;

            foreach (var puesto in puestos)
            {
                PuestoComboBox.Items.Add(puesto);
                PuestoComboBox.DisplayMember = "Nombre";
                PuestoComboBox.ValueMember = "Id";
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(DescripcionTxtBox.Text)
             && !String.IsNullOrWhiteSpace(PuestoComboBox.Text)
             && !String.IsNullOrWhiteSpace(NivelComboBox.Text)
             && !String.IsNullOrWhiteSpace(IntitucionComboBox.Text)
             && !String.IsNullOrWhiteSpace(Convert.ToString(fechaDesde.Value))
             && !String.IsNullOrWhiteSpace(Convert.ToString(fechaHasta.Value)))
            {
                showLoading();
                string accionRealizada;
                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                var nivel = (Nivel)NivelComboBox.SelectedItem;
                var institucion = (Institucion)IntitucionComboBox.SelectedItem;
                var entity = new Capacitacion()
                {
                    Id = _rowSelectedId,
                    Descripcion = DescripcionTxtBox.Text,
                    PuestoId = puesto.Id,
                    NivelId = nivel.Id,
                    InstitucionId = institucion.Id,
                    FechaDesde = fechaDesde.Value,
                    FechaHasta = fechaHasta.Value,
                };

                if (_rowSelectedId == 0)
                {
                    if (await _capacitacionService.ValidateIfExist(entity.Descripcion))
                    {
                        MessageBox.Show("Ya se ha creado una capacitacion con esa descripcion en ese puesto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                }
                else
                {
                    accionRealizada = "editado";
                }

                await _capacitacionService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " la capacitacion correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update_dataGridView();
                cleanModel();
                hideLoading();
            }
            else
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cleanModel()
        {
            _rowSelectedId = 0;
            DescripcionTxtBox.Text = "";
            NivelComboBox.SelectedItem = null;
            IntitucionComboBox.SelectedItem = null;
            DepartamentoComboBox.SelectedItem = null;
            PuestoComboBox.SelectedItem = null;
            fechaDesde.Value = DateTime.Now;
            fechaHasta.Value = DateTime.Now;
            button8.Text = "Guardar";
            criterioTxtBox.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            bool sePuedeEditar = true;
            string mensaje = "";

            if (dataGridView1.SelectedRows.Count == 0)
            {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar almenos una fila para editar";
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar solo la fila que desea editar";
            }

            if (!sePuedeEditar)
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            _rowSelectedId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].FormattedValue.ToString());

            var departamento = _departamentos.Find(x => x.Id == _departamentos.FirstOrDefault(y => y.Puestos.Any(p => p.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PuestoId"].FormattedValue.ToString()))).Id);
            var puestoSelected = departamento.Puestos.ToList().Find(x => x.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PuestoId"].FormattedValue.ToString()));
            var nivel = _niveles.FirstOrDefault(x => x.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["NivelId"].FormattedValue.ToString()));
            var institucion = _instituciones.FirstOrDefault(x => x.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["InstitucionId"].FormattedValue.ToString()));

            DescripcionTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Descripcion"].FormattedValue.ToString();
            DepartamentoComboBox.SelectedItem = departamento;
            PuestoComboBox.SelectedIndex = PuestoComboBox.Items.IndexOf(puestoSelected);
            NivelComboBox.SelectedIndex = NivelComboBox.Items.IndexOf(nivel);
            IntitucionComboBox.SelectedIndex = IntitucionComboBox.Items.IndexOf(institucion);
            fechaDesde.Value = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["Desde"].FormattedValue.ToString());
            fechaHasta.Value = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["Hasta"].FormattedValue.ToString());

            button8.Text = "Editar";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar almenos una fila para eliminarla",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            showLoading();
            var rowsIndex = new List<int>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                rowsIndex.Add(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["Id"].FormattedValue.ToString()));
            }
            await _capacitacionService.DeleteManyAsync((await _capacitacionService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
            refreshTable();
        }

        private async void refreshTable() {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _capacitacionService.GetAll()).ToList();
        }

        private  void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _capacitacionService.GetCapacitacionByCriteria(criterioTxtBox.Text).ToList();
        }
    }
}
