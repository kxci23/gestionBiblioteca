using GestionBiblioteca.Controlador;
using GestionBiblioteca.Modelo;

namespace GestionBiblioteca
{
    public partial class Form1 : Form
    {
        private UsuarioControlador controlador = new UsuarioControlador();
        private SesionControlador sesionControlador = new SesionControlador(); // Agrega esto

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; // Permite iniciar sesión con Enter
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                lblMensaje.Text = "Ingrese usuario y contraseña.";
                return;
            }

            // Autenticación estricta (sensible a mayúsculas/minúsculas)
            var rol = controlador.AutenticarUsuario(usuario, contraseña);
            int idUsuario = controlador.ObtenerIdUsuario(usuario, contraseña);

            if (rol == null || idUsuario <= 0)
            {
                lblMensaje.Text = "Credenciales incorrectas.";
                return;
            }

            if (rol == "Administrador")
            {
                sesionControlador.RegistrarSesion(idUsuario, true);
                var adminForm = new Pantalla_Admin();
                adminForm.Show();
                this.Hide();
            }
            else if (rol == "Bibliotecario")
            {
                sesionControlador.RegistrarSesion(idUsuario, true);
                var biblioForm = new Pantalla_Bibliotecario(idUsuario);
                biblioForm.Show();
                this.Hide();
            }
            else if (rol == "Estudiante")
            {
                sesionControlador.RegistrarSesion(idUsuario, true);
                var estudianteForm = new Pantalla_Estudiante(idUsuario);
                estudianteForm.Show();
                this.Hide();
            }
            else
            {
                lblMensaje.Text = "Credenciales incorrectas.";
            }
        }
    }
}