using ReclutamientoSeleccionApp.Bl.Services;
using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
using ReclutamientoSeleccionApp.Views;
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
        private readonly UserService _userService;
        public Form1()
        {
            InitializeComponent();
            _userService = new UserService();
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
                var currentUser = await _userService.Autenticar(UsuarioTxtBox.Text, ContraseniaTxtBox.Text);
                if (currentUser != null) {
                    MessageBox.Show("Bienvenido "+ currentUser.Nombre + " " + currentUser.Apellido, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CurrentUser.SetCurrentUser(currentUser);
                    var candidatoView = new CandidatoView();
                    Hide();
                    candidatoView.Show();
                    Dispose();
                } else
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

        private void showLoading() 
        { 
            loading.Visible = true;
        }

        private void hideLoading() 
        {
            loading.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var registerView = new RegisterView();
            Hide();
            registerView.Show();
            Dispose();
        }
    }
}
