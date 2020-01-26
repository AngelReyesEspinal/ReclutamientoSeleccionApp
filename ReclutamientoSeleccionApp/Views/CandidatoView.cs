using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
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
    public partial class CandidatoView : Form
    {
        public CandidatoView()
        {
            InitializeComponent();
            var x = CurrentUser.Nombre;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CandidatoView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContraseniaTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }
    }
}
