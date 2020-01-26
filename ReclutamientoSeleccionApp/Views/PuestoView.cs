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
    public partial class PuestoView : Form
    {
        private readonly PuestoService _puestoService;

        public PuestoView()
        {
            _puestoService = new PuestoService();
            InitializeComponent();
            update_dataGridView();
        }

        private void PuestoView_Load(object sender, EventArgs e)
        {
            foreach (var estado in Enum.GetNames(typeof(Estado))) {
                EstadosComboBox.Items.Add(estado);
            }
            foreach (var nivel in Enum.GetNames(typeof(NivelDeRiesgo))) {
                NivelesDeRiesgoComboBox.Items.Add(nivel);
            }
        }

        private async void update_dataGridView() {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _puestoService.GetAll()).ToList();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombreTxtBox_Click(object sender, EventArgs e)
        {

        }

        private void ContraseniaTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text) && !String.IsNullOrWhiteSpace(SalarioMaximoTxtBox.Text) && !String.IsNullOrWhiteSpace(SalarioMinimoTxtBox.Text) && !String.IsNullOrWhiteSpace(NivelesDeRiesgoComboBox.Text) && !String.IsNullOrWhiteSpace(EstadosComboBox.Text))
            {
                showLoading();
                var entity = new Puesto()
                {
                    Nombre = NombreTxtBox.Text,
                    SalarioMaximo = Convert.ToDecimal(SalarioMaximoTxtBox.Text),
                    SalarioMinimo = Convert.ToDecimal(SalarioMinimoTxtBox.Text),
                    NivelDeRiesgo = (NivelDeRiesgo)Enum.Parse(typeof(NivelDeRiesgo), Convert.ToString(NivelesDeRiesgoComboBox.SelectedItem)),
                    Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString(EstadosComboBox.SelectedItem))
                };
                var createdEntity = await _puestoService.CreateAsync(entity);
                MessageBox.Show("Se ha creado el puesto correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update_dataGridView();
                hideLoading();
            }
            else
                MessageBox.Show("Debe llenar los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        private void EstadosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void NivelesDeRiesgoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
