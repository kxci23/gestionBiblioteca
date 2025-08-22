using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionBiblioteca.Modelo; 
using GestionBiblioteca.Controlador; // Agrega este using

namespace GestionBiblioteca
{
    // Cambia la herencia: NO heredes de Conexion ni ConexionMySQL
    public partial class Pantalla_Estudiante : Form
    {
        private int idEstudiante;
        private ConexionMySQL conexion = new ConexionMySQL(); // Instancia de la clase de conexión

        public Pantalla_Estudiante(int idEstudiante)
        {
            InitializeComponent();
            this.idEstudiante = idEstudiante;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.CellClick += dgvLibros_CellClick;
            CargarLibros();
            CargarHistorialPrestamos();
            ConfigurarDgvDevolucion();
            CargarDatos();
        }
        private void CargarHistorialPrestamos()
        {
            try
            {
                string query = @"SELECT sp.id AS solicitud_id,
                                   u.nombre_completo AS estudiante,
                                   l.titulo AS libro,
                                   sp.fecha_solicitud,
                                   sp.estado,
                                   b.nombre_completo AS bibliotecario
                            FROM solicitudes_prestamo sp
                            INNER JOIN usuarios u ON sp.estudiante_id = u.id
                            INNER JOIN libros l ON sp.libro_id = l.id
                            LEFT JOIN usuarios b ON sp.aprobado_por = b.id
                            WHERE sp.estado IN ('pendiente', 'aprobado', 'rechazado')
                              AND sp.estudiante_id = @idEstudiante
                            ORDER BY sp.fecha_solicitud DESC";

                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@idEstudiante", idEstudiante)
                };

                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                dgvHistorial.AutoGenerateColumns = true;
                dgvHistorial.DataSource = dt;
                dgvHistorial.Refresh();

                // Cambia los encabezados de columna
                if (dgvHistorial.Columns["solicitud_id"] != null)
                    dgvHistorial.Columns["solicitud_id"].HeaderText = "Número de Solicitud";
                if (dgvHistorial.Columns["estudiante"] != null)
                    dgvHistorial.Columns["estudiante"].HeaderText = "Estudiante";
                if (dgvHistorial.Columns["libro"] != null)
                    dgvHistorial.Columns["libro"].HeaderText = "Libro";
                if (dgvHistorial.Columns["fecha_solicitud"] != null)
                    dgvHistorial.Columns["fecha_solicitud"].HeaderText = "Fecha Solicitud";
                if (dgvHistorial.Columns["estado"] != null)
                    dgvHistorial.Columns["estado"].HeaderText = "Estado";
                if (dgvHistorial.Columns["bibliotecario"] != null)
                    dgvHistorial.Columns["bibliotecario"].HeaderText = "Nombre del Bibliotecario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }


        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            try
            {
                string query = @"SELECT l.id, l.titulo, l.autor, l.isbn, l.total_paginas, l.stock, 
                                c.nombre AS categoria
                         FROM libros l
                         INNER JOIN categorias_libros c ON l.categoria_id = c.id
                         WHERE l.titulo LIKE @filtro OR l.autor LIKE @filtro OR l.isbn LIKE @filtro OR c.nombre LIKE @filtro";

                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@filtro", "%" + filtro + "%")
                };

                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                dgvLibros.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar libros: " + ex.Message);
            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            int libroId = 5; // O el libro seleccionado

            try
            {
                string query = "INSERT INTO solicitudes_prestamo (estudiante_id, libro_id, fecha_solicitud, estado, approved_por) " +
                               "VALUES (@estudianteId, @libroId, NOW(), 'pendiente', NULL)";

                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@estudianteId", this.idEstudiante),
                    new MySqlParameter("@libroId", libroId)
                };

                conexion.EjecutarComando(query, parametros);

                MessageBox.Show("Solicitud enviada. Espere la aprobación del bibliotecario.");
                CargarHistorialPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar solicitud: " + ex.Message);
            }
        }

        private void btnActualizarHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialPrestamos();
        }

        private void btnInicio_Click(object sender, EventArgs e)
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

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string query = @"
    SELECT sp.id AS solicitud_id,
           u.nombre_completo AS estudiante,
           l.titulo AS libro,
           sp.fecha_solicitud,
           sp.estado,
           b.nombre_completo AS bibliotecario
    FROM solicitudes_prestamo sp
    INNER JOIN usuarios u ON sp.estudiante_id = u.id
    INNER JOIN libros l ON sp.libro_id = l.id
    LEFT JOIN usuarios b ON sp.aprobado_por = b.id
    WHERE sp.estado IN ('pendiente', 'aprobado', 'rechazado')
      AND sp.estudiante_id = @idEstudiante
    ORDER BY sp.fecha_solicitud DESC";

                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@idEstudiante", idEstudiante)
                };

                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                dgvHistorial.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0)
            {
                var row = dgvLibros.SelectedRows[0];
                txtAdquisicion.Text = row.Cells["titulo"].Value.ToString();
            }
        }

        private void CargarLibros()
        {
            try
            {
                string query = @"SELECT l.id, l.titulo, l.autor, l.isbn, l.total_paginas, l.stock, 
                                c.nombre AS categoria
                         FROM libros l
                         INNER JOIN categorias_libros c ON l.categoria_id = c.id";

                DataTable dt = conexion.EjecutarConsulta(query);
                dgvLibros.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
        }


        private void btnAdquirir_Click_1(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un libro para adquirir.");
                return;
            }

            var row = dgvLibros.SelectedRows[0];
            int libroId = Convert.ToInt32(row.Cells["id"].Value);

            // Verificar stock antes de permitir la solicitud
            int stock = 0;
            string stockQuery = "SELECT stock FROM libros WHERE id = @libroId";
            var stockParam = new MySqlParameter[] { new MySqlParameter("@libroId", libroId) };
            DataTable stockDt = conexion.EjecutarConsulta(stockQuery, stockParam);
            if (stockDt.Rows.Count > 0)
                stock = Convert.ToInt32(stockDt.Rows[0][0]);

            if (stock <= 0)
            {
                MessageBox.Show("El libro no está disponible. No hay stock.");
                return;
            }

            var resultMsg = MessageBox.Show(
                "¿Estás seguro de adquirir este libro?",
                "Confirmar adquisición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultMsg == DialogResult.Yes)
            {
                try
                {
                    // 1. Insertar en MySQL y obtener el ID generado
                    string query = "INSERT INTO solicitudes_prestamo (estudiante_id, libro_id, fecha_solicitud, estado, aprobado_por) " +
                                   "VALUES (@estudianteId, @libroId, NOW(), 'pendiente', NULL);";
                    var parametros = new MySqlParameter[] {
                        new MySqlParameter("@estudianteId", this.idEstudiante),
                        new MySqlParameter("@libroId", libroId)
                    };
                    conexion.EjecutarComando(query, parametros);

                    // Obtener el último ID generado
                    int idGenerado = 0;
                    using (var conn = conexion.ObtenerConexionMySQL())
                    {
                        conn.Open();
                        using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                        {
                            idGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                        }
                    }

                    // 2. Crear el objeto para MongoDB con el ID correcto
                    var solicitudMongo = new SolicitudPrestamo
                    {
                        Id = idGenerado, // Asigna el ID generado por MySQL
                        EstudianteId = this.idEstudiante,
                        LibroId = libroId,
                        FechaSolicitud = DateTime.Now,
                        Estado = "pendiente",
                        AprobadoPor = null
                    };
                    conexion.InsertarDocumento("solicitudes_prestamo", solicitudMongo);

                    MessageBox.Show("Tu libro está en proceso de adquisición. En unos momentos podrás ver en tu historial de préstamo si tu pedido fue aprobado.");
                    CargarHistorialPrestamos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al solicitar el libro: " + ex.Message);
                }
            }
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLibros.Rows[e.RowIndex].Cells["titulo"].Value != null)
            {
                txtAdquisicion.Text = dgvLibros.Rows[e.RowIndex].Cells["titulo"].Value.ToString();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpHistorial_Click(object sender, EventArgs e)
        {

        }

        private void Pantalla_Estudiante_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarDgvDevolucion()
        {
            dgvDevolucion.AutoGenerateColumns = false;
            dgvDevolucion.AllowUserToAddRows = false;
            dgvDevolucion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevolucion.MultiSelect = false;
            dgvDevolucion.Columns.Clear();

            dgvDevolucion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "ID Préstamo",
                DataPropertyName = "id",
                ReadOnly = true
            });

            dgvDevolucion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "libro_id",
                HeaderText = "ID Libro",
                DataPropertyName = "libro_id",
                ReadOnly = true
            });

            dgvDevolucion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "titulo",
                HeaderText = "Título",
                DataPropertyName = "titulo",
                ReadOnly = true
            });

            dgvDevolucion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_prestamo",
                HeaderText = "Fecha Préstamo",
                DataPropertyName = "fecha_prestamo",
                ReadOnly = true,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });
        }

        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection conn = conexion.ObtenerConexionMySQL()) // Usa la instancia
                {
                    string query = @"SELECT p.id, p.libro_id, l.titulo, p.fecha_prestamo
                             FROM prestamos p
                             INNER JOIN libros l ON p.libro_id = l.id
                             WHERE p.estado = 'activo' AND p.estudiante_id = @idEstudiante";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDevolucion.DataSource = dt;

                    // Oculta la columna de ID Libro
                    if (dgvDevolucion.Columns["libro_id"] != null)
                        dgvDevolucion.Columns["libro_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La solicitud a sido enviada al bibliotecario .");
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


        