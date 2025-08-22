using GestionBiblioteca.Controlador; // Agrega este using
using GestionBiblioteca.Modelo;
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
using MongoDB.Driver; // Agrega este using

namespace GestionBiblioteca
{
    public partial class Pantalla_Bibliotecario : Form
    {
        private int idBibliotecario;
        private ConexionMySQL conexion = new ConexionMySQL(); // Instancia global

        public Pantalla_Bibliotecario(int idBibliotecario)
        {
            InitializeComponent();
            this.idBibliotecario = idBibliotecario;

            // Inicializa el ComboBox de estado del libro
            cmbEstadoLibro.Items.Clear();
            cmbEstadoLibro.Items.Add(new KeyValuePair<int, string>(1, "Prestado"));
            cmbEstadoLibro.Items.Add(new KeyValuePair<int, string>(2, "Disponible"));
            cmbEstadoLibro.DisplayMember = "Value";
            cmbEstadoLibro.ValueMember = "Key";
            cmbEstadoLibro.SelectedIndex = 1; // Por defecto "Disponible"

            // Configuración DataGridViews
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;

            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.ReadOnly = true;
            dgvLibros.AllowUserToAddRows = false;

            dgvPrestamosActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamosActivos.MultiSelect = false;
            dgvPrestamosActivos.ReadOnly = true;
            dgvPrestamosActivos.AllowUserToAddRows = false;

            // Cargas iniciales
            CargarCategorias();
            CargarLibros();
            CargarPrestamos(); // Préstamos en dataGridView1
            CargarPrestamosActivos();
            CargarSolicitudesPendientes(); // <-- ¡Agrega esta línea!

            dgvLibros.SelectionChanged += dgvLibros_SelectionChanged;
        }

        // Carga categorías en el comboBox
        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            try
            {
                string query = "SELECT id, nombre FROM categorias_libros";
                DataTable dt = conexion.EjecutarConsulta(query);
                foreach (DataRow row in dt.Rows)
                {
                    cmbCategoria.Items.Add(new CategoriaLibro
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    });
                }
                if (cmbCategoria.Items.Count > 0)
                    cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        // Carga libros en dgvLibros
        private void CargarLibros()
        {
            try
            {
                string query = @"SELECT l.id, l.titulo, l.autor, l.isbn, l.total_paginas, l.stock, 
                                l.categoria_id, c.nombre AS categoria, 
                                l.estado_id
                         FROM libros l
                         INNER JOIN categorias_libros c ON l.categoria_id = c.id
                         INNER JOIN libros_estado e ON l.estado_id = e.id";
                DataTable dt = conexion.EjecutarConsulta(query);
                dgvLibros.DataSource = dt;

                // Limpia los campos y deselecciona cualquier fila
                LimpiarCampos();
                dgvLibros.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
        }

        private bool ExisteDevolucion(int prestamoId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM devoluciones WHERE prestamo_id = @prestamoId";
                var parametros = new MySqlParameter[] { new MySqlParameter("@prestamoId", prestamoId) };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar devolución existente: " + ex.Message);
                return false;
            }
        }

        // Carga solicitudes pendientes en dgvSolicitudes
        private void CargarSolicitudesPendientes()
        {
            try
            {
                string query = @"
                    SELECT sp.id AS solicitud_id,
                           sp.estudiante_id,
                           sp.libro_id,
                           u.nombre_completo AS estudiante,
                           l.titulo AS libro,
                           sp.fecha_solicitud,
                           sp.estado
                    FROM solicitudes_prestamo sp
                    INNER JOIN usuarios u ON sp.estudiante_id = u.id
                    INNER JOIN libros l ON sp.libro_id = l.id
                    WHERE sp.estado = 'pendiente'";
                DataTable dt = conexion.EjecutarConsulta(query);
                dgvSolicitudes.DataSource = dt;
                if (dgvSolicitudes.Columns["estudiante_id"] != null)
                    dgvSolicitudes.Columns["estudiante_id"].Visible = false;
                if (dgvSolicitudes.Columns["libro_id"] != null)
                    dgvSolicitudes.Columns["libro_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar solicitudes: " + ex.Message);
            }
        }

        // Carga préstamos activos en dgvPrestamosActivos
        private void CargarPrestamosActivos()
        {
            try
            {
                string query = @"
                SELECT p.id, u.nombre_completo AS estudiante, l.titulo AS libro,
                       p.fecha_prestamo, p.fecha_devolucion_esperada, p.estado
                FROM prestamos p
                INNER JOIN usuarios u ON p.estudiante_id = u.id
                INNER JOIN libros l ON p.libro_id = l.id
                WHERE p.estado = 'activo'";

                DataTable dt = conexion.EjecutarConsulta(query);
                dgvPrestamosActivos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos activos: " + ex.Message);
            }
        }

        // Sobrecarga del método para cargar préstamos activos de un estudiante específico
        private void CargarPrestamosActivos(int idEstudianteSeleccionado)
        {
            try
            {
                string query = @"
            SELECT p.id, u.nombre_completo AS estudiante, l.titulo AS libro,
                   p.fecha_prestamo, p.fecha_devolucion_esperada, p.estado
            FROM prestamos p
            INNER JOIN usuarios u ON p.estudiante_id = u.id
            INNER JOIN libros l ON p.libro_id = l.id
            LEFT JOIN devoluciones d ON p.id = d.prestamo_id
            WHERE p.estado = 'activo'
              AND d.id IS NULL
              AND p.estudiante_id = @idEstudiante";
                var parametros = new MySqlParameter[] {
            new MySqlParameter("@idEstudiante", idEstudianteSeleccionado)
        };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                dgvPrestamosActivos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos activos: " + ex.Message);
            }
        }

        // Botón aprobar solicitud
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una solicitud para aprobar.");
                return;
            }

            var row = dgvSolicitudes.SelectedRows[0];
            int solicitudId = Convert.ToInt32(row.Cells["solicitud_id"].Value);
            int estudianteId = Convert.ToInt32(row.Cells["estudiante_id"].Value);
            int libroId = Convert.ToInt32(row.Cells["libro_id"].Value);

            DateTime fechaPrestamo = dtpFechaPrestamo.Value;
            DateTime fechaDevolucion = dtpFechaDevolucion.Value;

            if (fechaPrestamo == null || fechaDevolucion == null)
            {
                MessageBox.Show("Seleccione fechas de préstamo y devolución.");
                return;
            }

            try
            {
                // 1. Verifica el stock actual
                string stockQuery = "SELECT stock FROM libros WHERE id = @libroId";
                var stockParam = new MySqlParameter[] { new MySqlParameter("@libroId", libroId) };
                DataTable stockDt = conexion.EjecutarConsulta(stockQuery, stockParam);
                int stockActual = Convert.ToInt32(stockDt.Rows[0][0]);

                if (stockActual <= 0)
                {
                    MessageBox.Show("No hay stock disponible para este libro.");
                    return;
                }

                // 2. Inserta el préstamo en MySQL
                string query = @"INSERT INTO prestamos (solicitud_id, estudiante_id, libro_id, bibliotecario_id, fecha_prestamo, fecha_devolucion_esperada, estado)
                         VALUES (@solicitudId, @estudianteId, @libroId, @bibliotecarioId, @fechaPrestamo, @fechaDevolucion, 'activo')";
                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@solicitudId", solicitudId),
                    new MySqlParameter("@estudianteId", estudianteId),
                    new MySqlParameter("@libroId", libroId),
                    new MySqlParameter("@bibliotecarioId", idBibliotecario),
                    new MySqlParameter("@fechaPrestamo", fechaPrestamo),
                    new MySqlParameter("@fechaDevolucion", fechaDevolucion)
                };
                conexion.EjecutarComando(query, parametros);

                // Obtener el último ID generado para el préstamo
                int idPrestamoGenerado = 0;
                using (var conn = conexion.ObtenerConexionMySQL())
                {
                    conn.Open();
                    using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                    {
                        idPrestamoGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }

                // Lógica para MongoDB
                var prestamoMongo = new Prestamos
                {
                    Id = idPrestamoGenerado,
                    SolicitudId = solicitudId,
                    EstudianteId = estudianteId,
                    LibroId = libroId,
                    BibliotecarioId = idBibliotecario,
                    FechaPrestamo = fechaPrestamo,
                    FechaDevolucionEsperada = fechaDevolucion,
                    Estado = "activo"
                };
                try
                {
                    conexion.InsertarDocumento("prestamos", prestamoMongo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar préstamo en MongoDB: " + ex.Message);
                }

                // 3. Actualiza la solicitud a "aprobado" en MySQL
                string updateSolicitud = "UPDATE solicitudes_prestamo SET estado = 'aprobado', aprobado_por = @bibliotecarioId WHERE id = @solicitudId";
                var parametros2 = new MySqlParameter[] {
                    new MySqlParameter("@bibliotecarioId", idBibliotecario),
                    new MySqlParameter("@solicitudId", solicitudId)
                };
                conexion.EjecutarComando(updateSolicitud, parametros2);

                // 3.1. Actualiza la solicitud en MongoDB
                var coleccionMongo = conexion.ObtenerColeccionMongo<SolicitudPrestamo>("solicitudes_prestamo");
                var filtroMongo = Builders<SolicitudPrestamo>.Filter.Eq(x => x.Id, solicitudId);
                var actualizacionMongo = Builders<SolicitudPrestamo>.Update
                    .Set(x => x.Estado, "aprobado")
                    .Set(x => x.AprobadoPor, idBibliotecario);
                coleccionMongo.UpdateOne(filtroMongo, actualizacionMongo);

                // 4. Resta 1 al stock del libro
                string updateStock = "UPDATE libros SET stock = stock - 1 WHERE id = @libroId";
                var parametros3 = new MySqlParameter[] { new MySqlParameter("@libroId", libroId) };
                conexion.EjecutarComando(updateStock, parametros3);

                MessageBox.Show("Préstamo registrado correctamente.");
                CargarPrestamos();
                CargarSolicitudesPendientes();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aprobar la solicitud: " + ex.Message);
            }
        }

        // Botón rechazar solicitud
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una solicitud para rechazar.");
                return;
            }

            int solicitudId = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["solicitud_id"].Value);

            try
            {
                string query = "UPDATE solicitudes_prestamo SET estado = 'rechazado', aprobado_por = @bibliotecarioId WHERE id = @solicitudId";
                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@bibliotecarioId", idBibliotecario),
                    new MySqlParameter("@solicitudId", solicitudId)
                };
                int filasAfectadas = conexion.EjecutarComando(query, parametros);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Solicitud rechazada correctamente.");
                    CargarSolicitudesPendientes();
                }
                else
                {
                    MessageBox.Show("No se pudo rechazar la solicitud.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rechazar la solicitud: " + ex.Message);
            }
        }

        // Botón registrar libro nuevo
        private void btnRegistrarLibro_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text) ||
                nudPaginas.Value <= 0 ||
                nudStock.Value <= 0 ||
                cmbCategoria.SelectedItem == null ||
                cmbEstadoLibro.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos y asegurarse que N. PÁGINAS y STOCK sean mayores a 0.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var estadoSeleccionado = (KeyValuePair<int, string>)cmbEstadoLibro.SelectedItem;
                int estadoId = estadoSeleccionado.Key;

                string query = "INSERT INTO libros (titulo, autor, isbn, total_paginas, stock, categoria_id, estado_id) " +
                               "VALUES (@titulo, @autor, @isbn, @total_paginas, @stock, @categoria_id, @estado_id)";
                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@titulo", txtTitulo.Text),
                    new MySqlParameter("@autor", txtAutor.Text),
                    new MySqlParameter("@isbn", txtISBN.Text),
                    new MySqlParameter("@total_paginas", Convert.ToInt32(nudPaginas.Value)),
                    new MySqlParameter("@stock", Convert.ToInt32(nudStock.Value)),
                    new MySqlParameter("@categoria_id", ((CategoriaLibro)cmbCategoria.SelectedItem).Id),
                    new MySqlParameter("@estado_id", estadoId)
                };
                conexion.EjecutarComando(query, parametros);

                // Recupera el Id generado por MySQL
                int idGenerado = 0;
                using (var conn = conexion.ObtenerConexionMySQL())
                {
                    conn.Open();
                    using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                    {
                        idGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }

                // Crea el objeto Libro con el Id correcto
                var libroMongo = new Libro
                {
                    Id = idGenerado,
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Isbn = txtISBN.Text,
                    TotalPaginas = Convert.ToInt32(nudPaginas.Value),
                    Stock = Convert.ToInt32(nudStock.Value),
                    CategoriaId = ((CategoriaLibro)cmbCategoria.SelectedItem).Id,
                    EstadoId = estadoId
                };
                conexion.InsertarDocumento("libros", libroMongo);

                MessageBox.Show("Libro registrado correctamente.");
                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar libro: " + ex.Message);
            }
        }

        // Botón actualizar libro
        private void btnActualizarLibro_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text) ||
                nudPaginas.Value <= 0 ||
                nudStock.Value <= 0 ||
                cmbCategoria.SelectedItem == null ||
                cmbEstadoLibro.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos y asegurarse que N. PÁGINAS y STOCK sean mayores a 0.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var estadoSeleccionado = (KeyValuePair<int, string>)cmbEstadoLibro.SelectedItem;
                int estadoId = estadoSeleccionado.Key;

                string query = "UPDATE libros SET titulo = @titulo, autor = @autor, total_paginas = @total_paginas, stock = @stock, categoria_id = @categoria_id, estado_id = @estado_id " +
                               "WHERE isbn = @isbn";
                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@titulo", txtTitulo.Text),
                    new MySqlParameter("@autor", txtAutor.Text),
                    new MySqlParameter("@total_paginas", Convert.ToInt32(nudPaginas.Value)),
                    new MySqlParameter("@stock", Convert.ToInt32(nudStock.Value)),
                    new MySqlParameter("@categoria_id", ((CategoriaLibro)cmbCategoria.SelectedItem).Id),
                    new MySqlParameter("@estado_id", estadoId),
                    new MySqlParameter("@isbn", txtISBN.Text)
                };
                int filasAfectadas = conexion.EjecutarComando(query, parametros);

                if (filasAfectadas > 0)
                {
                    // Actualiza en MongoDB
                    // Busca el libro por ISBN en MongoDB
                    var librosMongo = conexion.ObtenerDocumentos<Libro>("libros");
                    var libroMongo = librosMongo.FirstOrDefault(l => l.Isbn == txtISBN.Text);
                    if (libroMongo != null)
                    {
                        libroMongo.Titulo = txtTitulo.Text;
                        libroMongo.Autor = txtAutor.Text;
                        libroMongo.TotalPaginas = Convert.ToInt32(nudPaginas.Value);
                        libroMongo.Stock = Convert.ToInt32(nudStock.Value);
                        libroMongo.CategoriaId = ((CategoriaLibro)cmbCategoria.SelectedItem).Id;
                        libroMongo.EstadoId = estadoId;

                        conexion.ActualizarDocumento("libros", libroMongo.Id.ToString(), libroMongo);
                    }

                    MessageBox.Show("Libro actualizado correctamente.");
                    LimpiarCampos();
                    CargarLibros();
                }
                else
                {
                    MessageBox.Show("No se encontró un libro con ese ISBN.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar libro: " + ex.Message);
            }
        }

        // Limpia campos del formulario de libros
        private void LimpiarCampos()
        {
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtISBN.Text = "";
            nudPaginas.Value = nudPaginas.Minimum;
            nudStock.Value = nudStock.Minimum;
            cmbCategoria.SelectedIndex = 0;
            cmbEstadoLibro.SelectedIndex = 0;
        }

        // Botón registrar devolución
        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo para registrar la devolución.");
                return;
            }

            int prestamoId = Convert.ToInt32(dgvPrestamosActivos.SelectedRows[0].Cells["id"].Value);

            if (ExisteDevolucion(prestamoId))
            {
                MessageBox.Show("Este préstamo ya tiene una devolución registrada.");
                return;
            }

            string condicionLibro = txtCondicion.Text.Trim();
            string observaciones = txtObservaciones.Text.Trim();

            if (string.IsNullOrEmpty(condicionLibro))
            {
                MessageBox.Show("Ingrese la condición del libro.");
                return;
            }

            try
            {
                string query = @"
        INSERT INTO devoluciones (prestamo_id, fecha_devolucion, condicion_libro, observaciones, recibido_por)
        VALUES (@prestamoId, @fechaDevolucion, @condicionLibro, @observaciones, @recibidoPor)";
                var parametros = new MySqlParameter[] {
                    new MySqlParameter("@prestamoId", prestamoId),
                    new MySqlParameter("@fechaDevolucion", DateTime.Now),
                    new MySqlParameter("@condicionLibro", condicionLibro),
                    new MySqlParameter("@observaciones", observaciones),
                    new MySqlParameter("@recibidoPor", idBibliotecario)
                };
                conexion.EjecutarComando(query, parametros);

                // Obtener el último id generado para la devolución
                int idDevolucionGenerado = 0;
                using (var conn = conexion.ObtenerConexionMySQL())
                {
                    conn.Open();
                    using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                    {
                        idDevolucionGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }

                // Crear el objeto para MongoDB
                var devolucionMongo = new Devolucion
                {
                    Id = idDevolucionGenerado,
                    PrestamoId = prestamoId,
                    FechaDevolucion = DateTime.Now,
                    CondicionLibro = condicionLibro,
                    Observaciones = observaciones,
                    RecibidoPor = idBibliotecario
                };
                conexion.InsertarDocumento("devoluciones", devolucionMongo);

                // Actualiza el estado del préstamo a devuelto
                ActualizarEstadoPrestamo(prestamoId);

                // Suma 1 al stock del libro
                string updateStock = "UPDATE libros SET stock = stock + 1 WHERE id = (SELECT libro_id FROM prestamos WHERE id = @prestamoId)";
                var parametros2 = new MySqlParameter[] { new MySqlParameter("@prestamoId", prestamoId) };
                conexion.EjecutarComando(updateStock, parametros2);

                MessageBox.Show("Devolución registrada correctamente.");
                LimpiarCamposDevolucion();
                CargarPrestamosActivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la devolución: " + ex.Message);
            }
        }

        // Actualiza estado del préstamo a 'devuelto'
        private void ActualizarEstadoPrestamo(int prestamoId)
        {
            try
            {
                string query = "UPDATE prestamos SET estado = 'devuelto' WHERE id = @prestamoId";
                var parametros = new MySqlParameter[] { new MySqlParameter("@prestamoId", prestamoId) };
                conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado del préstamo: " + ex.Message);
            }
        }

        // Limpia campos para registrar devolución
        private void LimpiarCamposDevolucion()
        {
            txtCondicion.Clear();
            txtObservaciones.Clear();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void CargarPrestamos()
        {
            try
            {
                string query = @"
            SELECT 
                p.id, 
                p.solicitud_id, 
                u_estudiante.nombre_completo AS estudiante, 
                l.titulo AS libro, 
                u_bibliotecario.nombre_completo AS bibliotecario,
                p.fecha_prestamo, 
                p.fecha_devolucion_esperada, 
                p.estado
            FROM prestamos p
            INNER JOIN usuarios u_estudiante ON p.estudiante_id = u_estudiante.id
            INNER JOIN libros l ON p.libro_id = l.id
            INNER JOIN usuarios u_bibliotecario ON p.bibliotecario_id = u_bibliotecario.id";
                DataTable dt = conexion.EjecutarConsulta(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos: " + ex.Message);
            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            // Solo rellena los campos si hay una fila seleccionada y el DataGridView tiene el foco
            if (dgvLibros.SelectedRows.Count > 0 && dgvLibros.Focused)
            {
                var row = dgvLibros.SelectedRows[0];
                txtTitulo.Text = row.Cells["titulo"].Value?.ToString() ?? "";
                txtAutor.Text = row.Cells["autor"].Value?.ToString() ?? "";
                txtISBN.Text = row.Cells["isbn"].Value?.ToString() ?? "";

                // Páginas
                decimal paginas = row.Cells["total_paginas"].Value != null ? Convert.ToDecimal(row.Cells["total_paginas"].Value) : nudPaginas.Minimum;
                paginas = Math.Max(nudPaginas.Minimum, Math.Min(nudPaginas.Maximum, paginas));
                nudPaginas.Value = paginas;

                // Stock
                decimal stock = row.Cells["stock"].Value != null ? Convert.ToDecimal(row.Cells["stock"].Value) : nudStock.Minimum;
                stock = Math.Max(nudStock.Minimum, Math.Min(nudStock.Maximum, stock));
                nudStock.Value = stock;

                // Selecciona la categoría en el ComboBox
                int categoriaId = row.Cells["categoria_id"].Value != null ? Convert.ToInt32(row.Cells["categoria_id"].Value) : 0;
                for (int i = 0; i < cmbCategoria.Items.Count; i++)
                {
                    if (((CategoriaLibro)cmbCategoria.Items[i]).Id == categoriaId)
                    {
                        cmbCategoria.SelectedIndex = i;
                        break;
                    }
                }

                // Selecciona el estado en el ComboBox
                int estadoId = row.Cells["estado_id"].Value != null ? Convert.ToInt32(row.Cells["estado_id"].Value) : 0;
                for (int i = 0; i < cmbEstadoLibro.Items.Count; i++)
                {
                    if (((KeyValuePair<int, string>)cmbEstadoLibro.Items[i]).Key == estadoId)
                    {
                        cmbEstadoLibro.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                // Si no hay selección, limpia los campos
                LimpiarCampos();
            }
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
