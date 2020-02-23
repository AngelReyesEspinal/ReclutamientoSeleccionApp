using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.DataModel.Models;
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
    public partial class SolicitudesPendientesView : Form
    {
        private readonly SolicitudPendienteService _solicitudPendienteService;
        private readonly CandidatoService _candidatoService;
        private readonly EmpleadoService _empleadoService;
        private List<SolicitudPendiente> _solicitudes;
        private List<Empleado> _empleados;
        public SolicitudesPendientesView()
        {
            InitializeComponent();
            _solicitudPendienteService = new SolicitudPendienteService();
            _candidatoService = new CandidatoService();
            _empleadoService = new EmpleadoService();
            _solicitudes = new List<SolicitudPendiente>();
            _empleados = new List<Empleado>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void SolicitudesPendientesView_Load(object sender, EventArgs e)
        {
            CargarSolicitudes();
            CargarEmpleados();
        }

        private  void CargarSolicitudes() 
        {
            candidatosListBox.Items.Clear();
            _solicitudes = _solicitudPendienteService.GetAll().ToList();
            foreach (var _solicitud in _solicitudes)
            {
                if (_solicitud.Candidato == null)
                    _solicitud.Candidato = _candidatoService.GetById(_solicitud.CandidatoId);
                candidatosListBox.Items.Add(_solicitud.Candidato);
                candidatosListBox.DisplayMember = "FullName";
                candidatosListBox.ValueMember = "Id";
            }
        }
        private void CargarEmpleados()
        {
            empleadosListBox.Items.Clear();
            _empleados = _empleadoService.GetAll().ToList();
            foreach (var _empleado in _empleados)
            {
                if (_empleado.Candidato == null)
                    _empleado.Candidato = _candidatoService.GetById(_empleado.CandidatoId);
                empleadosListBox.Items.Add(_empleado.Candidato);
                empleadosListBox.DisplayMember = "FullName";
                empleadosListBox.ValueMember = "Id";
            }
        }

        private void candidatosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private  void button1_Click(object sender, EventArgs e)
        {
            if (candidatosListBox.CheckedItems.Count > 0)
            {
                var candidatos = new List<Candidato>();
                
                foreach (var candidato in candidatosListBox.CheckedItems)
                {
                    candidatos.Add((Candidato)candidato);
                }
                _empleadoService.VolverCandidatosAEmpleados(candidatos);
                CargarSolicitudes();
                CargarEmpleados();
                MessageBox.Show("Se han promovido los candidatos correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Debe seleccionar los candidatos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (candidatosListBox.CheckedItems.Count > 0) {
                var candidatosId = new List<int>();
                foreach (var candidato in candidatosListBox.CheckedItems)
                {
                    var candidatoId = (Candidato)candidato;
                    candidatosId.Add(candidatoId.Id);
                }
                _solicitudPendienteService.RechazarSolicitudes(candidatosId);
                CargarSolicitudes();
                CargarEmpleados();
                MessageBox.Show("Se han rechazado las peticiones correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Debe seleccionar los candidatos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var candidatoView = new CandidatoView();
            Hide();
            candidatoView.Show();
            Dispose();
        }
    }
}
