using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionBiblioteca.Controlador; // Asegúrate de incluir esta directiva
using GestionBiblioteca.Modelo;      // Asegúrate de incluir esta directiva


namespace GestionBiblioteca
{
    public partial class Pantalla_Admin : Form
    {
        private UsuarioControlador controlador = new UsuarioControlador(); // Instancia global
        private SesionControlador sesionControlador = new SesionControlador();
        private int idUsuarioSeleccionado = 0;

        public Pantalla_Admin()
        {
            InitializeComponent();
            this.Load += Pantalla_Admin_Load;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged; // <-- Agrega esta línea
        }

        private void Pantalla_Admin_Load(object sender, EventArgs e)
        {
            // Cargar roles en el ComboBox
            var roles = controlador.ObtenerRoles();
            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";

            // Cargar usuarios en el DataGridView
            dgvUsuarios.DataSource = controlador.ObtenerUsuarios();
            dgvUsuarios.Columns["PasswordHash"].Visible = false; // Opcional: ocultar hash

            // Cargar sesiones en el DataGridView
            CargarSesiones();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is Usuario usuario)
            {
                idUsuarioSeleccionado = usuario.IdUsuario;
                txtNombreCompleto.Text = usuario.NombreCompleto;
                txtUsername.Text = usuario.Username;
                txtPassword.Text = ""; // No mostrar el hash
                cmbRol.SelectedValue = usuario.RolId;
                chkActivo.Checked = usuario.Activo;
            }
        }

        private void CargarSesiones()
        {
            dgvSesion.DataSource = sesionControlador.ObtenerSesiones();
            if (dgvSesion.Columns["NombreUsuario"] != null)
                dgvSesion.Columns["NombreUsuario"].HeaderText = "Nombre de Usuario";
        }

        private bool ValidarCamposUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El campo 'Nombre Completo' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El campo 'Username' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("El campo 'Contraseña' es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }
            return true;
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposUsuario())
                return;

            var usuario = new Usuario
            {
                NombreCompleto = txtNombreCompleto.Text,
                Username = txtUsername.Text,
                PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPassword.Text)),
                RolId = (int)cmbRol.SelectedValue,
                Activo = chkActivo.Checked
            };

            try
            {
                controlador.CrearUsuario(usuario);
                dgvUsuarios.DataSource = controlador.ObtenerUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // No se cierra el programa ni se sale del método
            }
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {


            var usuario = new Usuario
            {
                IdUsuario = idUsuarioSeleccionado,
                NombreCompleto = txtNombreCompleto.Text,
                Username = txtUsername.Text,
                PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPassword.Text)),
                RolId = (int)cmbRol.SelectedValue,
                Activo = chkActivo.Checked
            };

            controlador.ActualizarUsuario(usuario);
            dgvUsuarios.DataSource = controlador.ObtenerUsuarios();
            LimpiarCampos();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            // No es necesario poner lógica aquí a menos que quieras hacer algo especial al cambiar el check
        }

        // Método para limpiar los campos y la variable de selección
        private void LimpiarCampos()
        {
            idUsuarioSeleccionado = 0;
            txtNombreCompleto.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cmbRol.SelectedIndex = 0;
            chkActivo.Checked = false;
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
              "¿Está seguro de que desea cerrar sesión?",
              "Confirmar cierre de sesión",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                var loginForm = new Form1(); // Usa el nombre real de tu formulario de login
                loginForm.Show();
                this.Close();
            }
        }

        private void btnActualizarUsuario_Click_1(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario para actualizar.");
                return;
            }

            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol.");
                return;
            }

            var usuario = new Usuario
            {
                IdUsuario = idUsuarioSeleccionado,
                NombreCompleto = txtNombreCompleto.Text,
                Username = txtUsername.Text,
                PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPassword.Text)),
                RolId = (int)cmbRol.SelectedValue,
                Activo = chkActivo.Checked
            };

            controlador.ActualizarUsuario(usuario);
            dgvUsuarios.DataSource = controlador.ObtenerUsuarios();
            LimpiarCampos();
        }
    }
}