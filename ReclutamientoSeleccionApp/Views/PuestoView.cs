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
        private readonly DepartamentoService _departamentoService;
        private int _rowSelectedId = 0;
        private List<Departamento> _departamentos;
        public PuestoView()
        {
            _puestoService = new PuestoService();
            _departamentoService = new DepartamentoService();
            _departamentos = new List<Departamento>();
            InitializeComponent();
            update_dataGridView();
        }

        private void SalarioMaximoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private async void PuestoView_Load(object sender, EventArgs e)
        {
            showLoading();
            _departamentos = (await _departamentoService.GetAll()).ToList();
            foreach (var dept in _departamentos)
            {
                DepartamentosComboBox.Items.Add(dept);
                DepartamentosComboBox.DisplayMember = "Nombre";
                DepartamentosComboBox.ValueMember = "Id";
            }
            foreach (var estado in Enum.GetNames(typeof(Estado))) {
                EstadosComboBox.Items.Add(estado);
            }
            foreach (var nivel in Enum.GetNames(typeof(NivelDeRiesgo))) {
                NivelesDeRiesgoComboBox.Items.Add(nivel);
            }
            hideLoading();
        }

        private async void update_dataGridView() {
            refreshTable();
        }

        private async void refreshTable() {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = await _puestoService.GetAllDtos();
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
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text) 
             && !String.IsNullOrWhiteSpace(SalarioMaximoTxtBox.Text) 
             && !String.IsNullOrWhiteSpace(SalarioMinimoTxtBox.Text) 
             && !String.IsNullOrWhiteSpace(NivelesDeRiesgoComboBox.Text)
             && !String.IsNullOrWhiteSpace(DepartamentosComboBox.Text)
             && !String.IsNullOrWhiteSpace(EstadosComboBox.Text))
            {
                showLoading();
                string accionRealizada;
                var dept = (Departamento)DepartamentosComboBox.SelectedItem;
                var entity = new Puesto()
                {
                    Id = _rowSelectedId,
                    Nombre = NombreTxtBox.Text,
                    DepartamentoId = dept.Id,
                    SalarioMaximo = Convert.ToDecimal(SalarioMaximoTxtBox.Text),
                    SalarioMinimo = Convert.ToDecimal(SalarioMinimoTxtBox.Text),
                    NivelDeRiesgo = (NivelDeRiesgo)Enum.Parse(typeof(NivelDeRiesgo), Convert.ToString(NivelesDeRiesgoComboBox.SelectedItem)),
                    Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString(EstadosComboBox.SelectedItem))
                };

                if (entity.SalarioMinimo >= entity.SalarioMaximo) { 
                    MessageBox.Show("El salario máximo no puede ser menor o igual al salario mínimo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hideLoading();
                    return;
                }

                if (_rowSelectedId == 0) {
                    if (await _puestoService.ValidateIfExist(entity.Nombre, entity.DepartamentoId)) {
                        MessageBox.Show("Ya se ha creado un puesto con ese nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                } else {
                    accionRealizada = "editado";
                }

                await _puestoService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " el puesto correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cleanModel() {
            _rowSelectedId = 0;
            NombreTxtBox.Text = "";
            SalarioMaximoTxtBox.Text = "";
            SalarioMinimoTxtBox.Text = "";
            NivelesDeRiesgoComboBox.SelectedItem = null;
            EstadosComboBox.SelectedItem = null;
            DepartamentosComboBox.SelectedItem = null;
            button1.Text = "Guardar";
            criterioTxtBox.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool sePuedeEditar = true;
            string mensaje = "";

            if (dataGridView1.SelectedRows.Count == 0) {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar almenos una fila para editar";
            }

            if (dataGridView1.SelectedRows.Count > 1) {
                sePuedeEditar = false;
                mensaje = "Debe seleccionar solo la fila que desea editar";
            }

            if (!sePuedeEditar) {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            _rowSelectedId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].FormattedValue.ToString());
            NombreTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Nombre"].FormattedValue.ToString();
            SalarioMinimoTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["SalarioMinimo"].FormattedValue.ToString();
            SalarioMaximoTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["SalarioMaximo"].FormattedValue.ToString();
            DepartamentosComboBox.SelectedItem = _departamentos.Find(x => x.Nombre == (dataGridView1.Rows[rowIndex].Cells["Departamento"].FormattedValue.ToString()));
            NivelesDeRiesgoComboBox.SelectedIndex = NivelesDeRiesgoComboBox.Items.IndexOf(dataGridView1.Rows[rowIndex].Cells["NivelDeRiesgo"].FormattedValue.ToString());
            EstadosComboBox.SelectedIndex = EstadosComboBox.Items.IndexOf(dataGridView1.Rows[rowIndex].Cells["Estado"].FormattedValue.ToString());
            button1.Text = "Editar";
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("Debe seleccionar almenos una fila para eliminarla",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            showLoading();
            bool hayPuestosConCompetencias = false;
            
            var rowsIndex = new List<int>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) {
                rowsIndex.Add(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["Id"].FormattedValue.ToString()));
            }

            foreach (var deptId in rowsIndex)
            {
                if (await _puestoService.ValidateIfHasCompetencias(deptId))
                {
                    var dpt = _puestoService.GetById(deptId).Nombre;
                    hayPuestosConCompetencias = true;
                    MessageBox.Show("El puesto " + dpt + " no se puede eliminar pues posee competencias activas",
                           "Atención",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                }
            }

            if (hayPuestosConCompetencias)
            {
                hideLoading();
                return;
            }

            await _puestoService.DeleteManyAsync((await _puestoService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
            refreshTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var puestoView = new PuestoView();
            Hide();
            puestoView.Show();
            Dispose();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var deptarmentoView = new DepartamentoView();
            Hide();
            deptarmentoView.Show();
            Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void SalarioMinimoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SalarioMaximoTxtBox_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            var idiomaView = new IdiomaView();
            Hide();
            idiomaView.Show();
            Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var competenciaView = new CompetenciaView();
            Hide();
            competenciaView.Show();
            Dispose();
        }

        private void criterioTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource =  _puestoService.GetIdiomaByCriteria(criterioTxtBox.Text).ToList();
        }
    }
}
