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
        public PuestoView()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text) && 
                !String.IsNullOrWhiteSpace(SalarioMaximoTxtBox.Text) && 
                !String.IsNullOrWhiteSpace(SalarioMinimoTxtBox.Text) && 
                !String.IsNullOrWhiteSpace(NivelesDeRiesgoComboBox.Text) &&
                !String.IsNullOrWhiteSpace(EstadosComboBox.Text)
            )
            {
                showLoading();
                var entity = new Puesto()
                {
                    NivelDeRiesgo = (NivelDeRiesgo)Enum.Parse(typeof(NivelDeRiesgo), Convert.ToString(NivelesDeRiesgoComboBox.SelectedItem)),
                    Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString(EstadosComboBox.SelectedItem))
                };
            }
        }


        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }
    }
}
