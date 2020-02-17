using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Models;
using ReclutamientoSeleccionApp.Models.Codes;
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
    public partial class CompetenciaView : Form
    {
        private int _rowSelectedId = 0;
        private readonly CompetenciaService _competenciaService;
        private readonly PuestoService _puestoService;
        private readonly DepartamentoService _departamentoService;
        //
        private List<Puesto> _puestos;
        private List<Departamento> _departamentos;
        public CompetenciaView()
        {
            InitializeComponent();
            _puestos = new List<Puesto>();
            _departamentos = new List<Departamento>();
            //
            _competenciaService = new CompetenciaService();
            _puestoService = new PuestoService();
            _departamentoService = new DepartamentoService();
        }

        private async void CompetenciaView_Load(object sender, EventArgs e)
        {
            _departamentos = (await _departamentoService.GetAll()).ToList();
            foreach (var departamento in _departamentos)
            {
                DepartamentoComboBox.Items.Add(departamento);
                DepartamentoComboBox.DisplayMember = "Nombre";
                DepartamentoComboBox.ValueMember = "Id";
            }
            foreach (var estado in Enum.GetNames(typeof(Estado)))
            {
                EstadosComboBox.Items.Add(estado);
            }
            update_dataGridView();
        }
        private void showLoading()
        {
            loading.Visible = true;
        }
        private void hideLoading()
        {
            loading.Visible = false;
        }
        private async void update_dataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _competenciaService.GetAllDtos()).ToList();
        }

        private async void DepartamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerPuestos();
        }

        public void ObtenerPuestos() {
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
             && !String.IsNullOrWhiteSpace(EstadosComboBox.Text))
            {
                showLoading();
                string accionRealizada;
                var puesto = (Puesto)PuestoComboBox.SelectedItem;
                var entity = new Competencia()
                {
                    Id = _rowSelectedId,
                    Descripcion = DescripcionTxtBox.Text,
                    PuestoId = puesto.Id,
                    Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString(EstadosComboBox.SelectedItem))
                };

                if (_rowSelectedId == 0)
                {
                    if (await _competenciaService.ValidateIfExist(entity.Descripcion, entity.PuestoId))
                    {
                        MessageBox.Show("Ya se ha creado una competencia con esa descripcion en ese puesto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                }
                else
                {
                    accionRealizada = "editado";
                }

                await _competenciaService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " la competencia correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            EstadosComboBox.SelectedItem = null;
            DepartamentoComboBox.SelectedItem = null;
            PuestoComboBox.SelectedItem = null;
            button8.Text = "Guardar";
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
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
            var departamento = _departamentos.Find(x => x.Id == _departamentos.FirstOrDefault(y => y.Puestos.Any(p => p.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PuestoId"].FormattedValue.ToString()))).Id);
            _rowSelectedId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].FormattedValue.ToString());
            DescripcionTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Descripcion"].FormattedValue.ToString();
            DepartamentoComboBox.SelectedItem = departamento;
            var puestoSelected = departamento.Puestos.ToList().Find(x => x.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PuestoId"].FormattedValue.ToString()));
            PuestoComboBox.SelectedIndex = PuestoComboBox.Items.IndexOf(puestoSelected); 
            EstadosComboBox.SelectedIndex = EstadosComboBox.Items.IndexOf(dataGridView1.Rows[rowIndex].Cells["Estado"].FormattedValue.ToString());
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
            await _competenciaService.DeleteManyAsync((await _competenciaService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
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
    }
}
