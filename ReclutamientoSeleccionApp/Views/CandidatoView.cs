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
    public partial class CandidatoView : Form
    {
        private readonly PuestoService _puestoService;
        private readonly DepartamentoService _departamentoService;
        private List<Puesto> _puestos;
        private List<Departamento> _departmaentos;
        public CandidatoView()
        {
            InitializeComponent();
            _puestos = new List<Puesto>();
            _departmaentos = new List<Departamento>();
            //
            _puestoService = new PuestoService();
            _departamentoService = new DepartamentoService();
            //CurrentUser.Nombre;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void CandidatoView_Load(object sender, EventArgs e)
        {
            _departmaentos = (await _departamentoService.GetAll()).ToList();
            foreach (var departamento in _departmaentos)
            {
                DepartamentoComboBox.Items.Add(departamento);
                DepartamentoComboBox.DisplayMember = "Nombre";
                DepartamentoComboBox.ValueMember = "Id";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        // loadings zone

        // puestos loading
        private void showPuestosLoading()
        {
            puestosLoading.Visible = true;
        }

        private void hidePuestosLoading()
        {
            puestosLoading.Visible = false;
        }

        // general loading
        private void showLoading()
        {
            loading.Visible = true;
        }

        private void hideLoading()
        {
            loading.Visible = false;
        }

        // end loading zone

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
            var deptarmentoView = new DepartamentoView();
            Hide();
            deptarmentoView.Show();
            Dispose();
        }

        private void NivelesDeRiesgoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var puesto = (Puesto)PuestoComboBox.SelectedItem;
            SalarioMaximoLabel.Text = Convert.ToString(puesto.SalarioMaximo);
            SalarioMinimoLabel.Text = Convert.ToString(puesto.SalarioMinimo);
            NivelDeRiesgoLabel.Text = Convert.ToString(puesto.NivelDeRiesgo);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private async void DepartamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPuestosLoading();
            PuestoComboBox.Items.Clear();
            var dept = (Departamento)DepartamentoComboBox.SelectedItem;
            _puestos = (await _puestoService.GetActiveRecordsByDepartamento(dept.Id)).ToList();
            foreach (var puesto in _puestos)
            {
                PuestoComboBox.Items.Add(puesto);
                PuestoComboBox.DisplayMember = "Nombre";
                PuestoComboBox.ValueMember = "Id";
            }
            hidePuestosLoading();
        }

        private void SalarioAspiradoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
