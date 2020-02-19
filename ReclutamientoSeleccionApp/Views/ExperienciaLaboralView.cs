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
    public partial class ExperienciaLaboralView : Form
    {
        private readonly InstitucionService _institucionService;
        private readonly ExperienciaLaboralService _experienciaLaboralService;
        private List<Institucion> _instituciones;
        private int _rowSelectedId = 0;

        public ExperienciaLaboralView()
        {
            InitializeComponent();
            _experienciaLaboralService = new ExperienciaLaboralService();
            _institucionService = new InstitucionService();
            _instituciones = new List<Institucion>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }
       

        private async void ExperienciaLaboralView_Load(object sender, EventArgs e)
        {
            _instituciones = (await _institucionService.GetAll()).ToList();
            foreach (var isntitucion in _instituciones)
            {
                IntitucionComboBox.Items.Add(isntitucion);
                IntitucionComboBox.DisplayMember = "NombreInstitucion";
                IntitucionComboBox.ValueMember = "Id";
            }
            update_dataGridView();
        }
        private async void update_dataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = (await _experienciaLaboralService.GetAll()).ToList();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void showLoading()
        {
            loading.Visible = true;
        }
        private void hideLoading()
        {
            loading.Visible = false;
        }
        private void cleanModel()
        {
            _rowSelectedId = 0;
            NombreTxtBox.Text = "";
            SalarioTxtBox.Text = "";
            IntitucionComboBox.SelectedItem = null;
            fechaDesde.Value = DateTime.Now;
            fechaHasta.Value = DateTime.Now;
            button1.Text = "Guardar";
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NombreTxtBox.Text)
            && !String.IsNullOrWhiteSpace(SalarioTxtBox.Text)
            && !String.IsNullOrWhiteSpace(IntitucionComboBox.Text)
            && !String.IsNullOrWhiteSpace(Convert.ToString(fechaDesde.Value))
            && !String.IsNullOrWhiteSpace(Convert.ToString(fechaHasta.Value)))
            {
                showLoading();
                string accionRealizada;
                var institucion = (Institucion)IntitucionComboBox.SelectedItem;
                var entity = new ExperienciaLaboral()
                {
                    Id = _rowSelectedId,
                    InstitucionId = institucion.Id,
                    FechaDesde = fechaDesde.Value,
                    FechaHasta = fechaHasta.Value,
                    PuestoOcupado = NombreTxtBox.Text,
                    Salario = Convert.ToDecimal(SalarioTxtBox.Text),
                    UserId = CurrentUser.Id
                };

                if (_rowSelectedId == 0)
                {
                    if (await _experienciaLaboralService.ValidateIfExist(entity.PuestoOcupado, entity.InstitucionId))
                    {
                        MessageBox.Show("Ya se ha creado esa experiencia en ese puesto en esa institucion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hideLoading();
                        return;
                    }
                    accionRealizada = "creado";
                }
                else
                {
                    accionRealizada = "editado";
                }

                await _experienciaLaboralService.AddOrUpdateAsync(entity);
                MessageBox.Show("Se ha " + accionRealizada + " la experiencia laboral correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update_dataGridView();
                cleanModel();
                hideLoading();
            }
            else
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            cleanModel();
        }

        private void button2_Click(object sender, EventArgs e)
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
            var institucion = _instituciones.FirstOrDefault(x => x.Id == Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["InstitucionId"].FormattedValue.ToString()));
            _rowSelectedId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].FormattedValue.ToString());
            NombreTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Puesto"].FormattedValue.ToString();
            SalarioTxtBox.Text = dataGridView1.Rows[rowIndex].Cells["Salario"].FormattedValue.ToString();
            IntitucionComboBox.SelectedIndex = IntitucionComboBox.Items.IndexOf(institucion);
            fechaDesde.Value = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["Desde"].FormattedValue.ToString());
            fechaHasta.Value = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["Hasta"].FormattedValue.ToString());

            button1.Text = "Editar";
        }

        private async void button5_Click(object sender, EventArgs e)
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
            await _experienciaLaboralService.DeleteManyAsync((await _experienciaLaboralService.GetAllByIds(rowsIndex)).ToList());
            update_dataGridView();
            string accionRealizada = dataGridView1.SelectedRows.Count > 1
                    ? accionRealizada = "han eliminado los registros"
                    : accionRealizada = "ha eliminado el registro";
            MessageBox.Show("Se " + accionRealizada + " correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hideLoading();
        }
    }
}
