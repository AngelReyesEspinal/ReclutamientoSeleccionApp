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
    public partial class IdiomaView : Form
    {
        private readonly IdiomaService _idiomaService;
        private int _rowSelectedId = 0;
        public IdiomaView()
        {
            InitializeComponent();
            _idiomaService = new IdiomaService();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EstadosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IdiomaView_Load(object sender, EventArgs e)
        {
            foreach (var estado in Enum.GetNames(typeof(Estado)))
            {
                EstadosComboBox.Items.Add(estado);
            }
            update_dataGridView();
        }

        private async void update_dataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _idiomaService.GetAll()).ToList();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text) && !String.IsNullOrWhiteSpace(EstadosComboBox.Text))
            {
                showLoading();
                string accionRealizada;
                var entity = new Idioma()
                {
                    Id = _rowSelectedId,
                    Nombre = NombreTxtBox.Text,
                    Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString(EstadosComboBox.SelectedItem))
                };

                if (_rowSelectedId == 0)
                {
                    if (await _idiomaService.ValidateIfExist(entity.Nombre))
                    {
                        MessageBox.Show("Ya se ha creado un idioma con ese nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                }
                else
                {
                    accionRealizada = "editado";
                }

                await _idiomaService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " el idioma correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            EstadosComboBox.SelectedItem = null;
            button8.Text = "Guardar";
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        private void loading_Click_1(object sender, EventArgs e)
        {

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
            await _idiomaService.DeleteManyAsync((await _idiomaService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }
    }
}
