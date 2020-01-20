using ReclutamientoSeleccionApp.Bl.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReclutamientoSeleccionApp
{
    public partial class Form1 : Form
    {
        private readonly AutenticacionService _autenticacionService;
        public Form1()
        {
            InitializeComponent();
            _autenticacionService = new AutenticacionService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (UsuarioTxtBox.Text != "" && ContraseniaTxtBox.Text != "") {
                showLoading();
                if (await _autenticacionService.Autenticar(UsuarioTxtBox.Text, ContraseniaTxtBox.Text))
                    MessageBox.Show("Muy bien", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else 
                    MessageBox.Show("Favor validar sus credenciales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hideLoading();
            }
            else 
                MessageBox.Show("Debe llenar los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void showLoading() { 
            loading.Visible = true;
        }

        private void hideLoading() {
            loading.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
