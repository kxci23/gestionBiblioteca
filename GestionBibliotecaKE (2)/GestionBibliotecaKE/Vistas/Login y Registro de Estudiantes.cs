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
            this.AcceptButton = btnLogin; // Permite iniciar sesi�n con Enter
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrase�a = txtContrase�a.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrase�a))
            {
                lblMensaje.Text = "Ingrese usuario y contrase�a.";
                return;
            }

            // Autenticaci�n estricta (sensible a may�sculas/min�sculas)
            var rol = controlador.AutenticarUsuario(usuario, contrase�a);
            int idUsuario = controlador.ObtenerIdUsuario(usuario, contrase�a);

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