using DGVPrinterHelper;
using ReclutamientoSeleccionApp.Bl.Services.UserService;
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
    public partial class EmpleadosView : Form
    {
        private readonly EmpleadoService _empleadoService;
        private List<Empleado> empleados;
        public EmpleadosView()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            empleados = new List<Empleado>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var desde = Convert.ToDateTime(fechaDesde.Value);
            var hasta = Convert.ToDateTime(fechaHasta.Value);
            empleados = _empleadoService.GetByDates(desde, hasta).ToList();
            update_dataGridView(empleados);
        }

        private void update_dataGridView(List<Empleado> candidatos)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = candidatos;
        }

        private void EmpleadosView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (empleados.Count > 0) {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Reporte Empleados";
                printer.SubTitle = string.Format("Fecha desde: {0} hasta: {1}", Convert.ToString(fechaDesde.Value), Convert.ToString(fechaHasta.Value));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = string.Format("EMB, reporte impreso el: {0}", Convert.ToString(DateTime.Now));
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
            }
            else
                MessageBox.Show("No hay empleados para imprimir", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
