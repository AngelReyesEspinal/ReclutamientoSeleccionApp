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
    public partial class NivelView : Form
    {
        private readonly NivelService _nivelService;
        private int _rowSelectedId = 0;
        public NivelView()
        {
            InitializeComponent();
            _nivelService = new NivelService();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nivelView = new NivelView();
            Hide();
            nivelView.Show();
            Dispose();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var capacitacionView = new CapacitacionView();
            Hide();
            capacitacionView.Show();
            Dispose();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text))
            {
                showLoading();
                string accionRealizada;
                var entity = new Nivel()
                {
                    Id = _rowSelectedId,
                    Titulo = NombreTxtBox.Text,
                };

                if (_rowSelectedId == 0)
                {
                    if (await _nivelService.ValidateIfExist(entity.Titulo))
                    {
                        MessageBox.Show("Ya se ha creado un nivel con ese nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                }
                else
                {
                    accionRealizada = "editado";
                }

                await _nivelService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " el nivel correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update_dataGridView();
                cleanModel();
                hideLoading();
            }
            else
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showLoading()
        {
            loading.Visible = true;
        }

        private void cleanModel()
        {
            _rowSelectedId = 0;
            NombreTxtBox.Text = "";
            button8.Text = "Guardar";
            criterioTxtBox.Text = "";
        }

        private void hideLoading()
        {
            loading.Visible = false;


        }
        private void NivelView_Load(object sender, EventArgs e)
        {
            update_dataGridView();
        }
        private async void update_dataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _nivelService.GetAll()).ToList();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
            update_dataGridView();
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
            bool hayCapacitacionesConEsteNivel = false;

            var rowsIndex = new List<int>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                rowsIndex.Add(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["Id"].FormattedValue.ToString()));
            }
            
            foreach (var deptId in rowsIndex)
            {
                if (await _nivelService.ValidateIfHasCapacitaciones(deptId))
                {
                    var dpt = _nivelService.GetById(deptId).Titulo;
                    hayCapacitacionesConEsteNivel = true;
                    MessageBox.Show("El nivel " + dpt + " no se puede eliminar pues posee competencias activas",
                           "Atención",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                }
            }

            if (hayCapacitacionesConEsteNivel)
            {
                hideLoading();
                return;
            }
            
            await _nivelService.DeleteManyAsync((await _nivelService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }

        private void button7_Click(object sender, EventArgs e)
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
            button8.Text = "Editar";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var institucionView = new InstitucionView();
            Hide();
            institucionView.Show();
            Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource =  _nivelService.GetIdiomaByCriteria(criterioTxtBox.Text).ToList();
        }
    }
}
