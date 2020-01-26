using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
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
    public partial class RegisterView : Form
    {
        private readonly UserService _userService;
        public RegisterView()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombresTxtBox.Text) && !String.IsNullOrWhiteSpace(ApellidosTxtBox.Text) && !String.IsNullOrWhiteSpace(UsuarioTxtBox.Text) && !String.IsNullOrWhiteSpace(ContraseniaTxtBox.Text))
            {
                showLoading();
                var usuario = new User()
                {
                    Nombre = NombresTxtBox.Text,
                    Apellido = ApellidosTxtBox.Text,
                    UserName = UsuarioTxtBox.Text,
                    Password = ContraseniaTxtBox.Text,
                    Rol = Models.Codes.Rol.Estandar,
                    FechaCreacion = DateTime.Now
                };
                var createdUser = await _userService.CreateAsync(usuario);
                MessageBox.Show("Se ha creado el usuario correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CurrentUser.SetCurrentUser(createdUser);
                hideLoading();
                //
                var candidatoView = new CandidatoView();
                Hide();
                candidatoView.Show();
                Dispose();
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
    }
}
