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
    public partial class DepartamentoView : Form
    {
        private readonly DepartamentoService _departamentoService;
        private int _rowSelectedId = 0;
        public DepartamentoView()
        {
            InitializeComponent();
            _departamentoService = new DepartamentoService();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void NombreTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void DepartamentoView_Load(object sender, EventArgs e)
        {
            showLoading();
            update_dataGridView();
            hideLoading();
        }
        private async void update_dataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _departamentoService.GetAll()).ToList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text)) {
                showLoading();
                string accionRealizada;
                var entity = new Departamento {
                    Id = _rowSelectedId,
                    Nombre = NombreTxtBox.Text
                };

                if (_rowSelectedId == 0) {
                    if (await _departamentoService.ValidateIfExist(NombreTxtBox.Text))
                    {
                        MessageBox.Show(
                            "Ya se ha creado un departamento con ese nombre", 
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                } else {
                    accionRealizada = "editado";
                }

                await _departamentoService.AddOrUpdateAsync(entity);
                update_dataGridView();
                MessageBox.Show("Se ha " + accionRealizada + " el puesto correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanModel();
                button1.Text = "Guardar";
            } else {
                MessageBox.Show(
                    "Debe ingresar el nombre del departamento", 
                    "Atención", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
            hideLoading();
        }

        private void cleanModel() 
        {
            _rowSelectedId = 0;
            NombreTxtBox.Text = "";
            button1.Text = "Guardar";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showLoading() {
            loading.Visible = true;
        }
        private void hideLoading()
        {
            loading.Visible = false;
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
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
            NombreTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Nombre"].FormattedValue.ToString();
            button1.Text = "Editar";
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar almenos una fila para eliminarla",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            showLoading();
            bool hayDepartamentosConPuestos = false;

            var rowsIndex = new List<int>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                rowsIndex.Add(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["Id"].FormattedValue.ToString()));
            }

            foreach (var deptId in rowsIndex)
            {
                if (await _departamentoService.ValidateIfHasPuestos(deptId))
                {
                    var dpt = _departamentoService.GetById(deptId).Nombre;
                    hayDepartamentosConPuestos = true;
                    MessageBox.Show("El departamento "+ dpt + " no se puede eliminar pues posee puestos activos",
                           "Atención",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                }
            }

            if (hayDepartamentosConPuestos) { 
                hideLoading();
                return;
            }

            await _departamentoService.DeleteManyAsync((await _departamentoService.GetAllByIds(rowsIndex)).ToList());

            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }
    }
}
