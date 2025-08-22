using GestionBiblioteca.Modelo;
using MySql.Data.MySqlClient;
using MongoDB.Driver;
using System.Collections.Generic;

namespace GestionBiblioteca.Controlador
{
    public class UsuarioControlador
    {
        // Cambia 'Conexion' por 'ConexionMySQL' para que coincida con la definición real
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        public List<Rol> ObtenerRoles()
        {
            var roles = new List<Rol>();
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, nombre FROM roles", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Rol
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
            }

            // MongoDB
            var rolesMongo = conexion.ObtenerDocumentos<Rol>("roles");
            // roles.AddRange(rolesMongo.Where(r => !roles.Any(x => x.Id == r.Id)));

            return roles;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var usuarios = new List<Usuario>();
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    @"SELECT u.id, u.nombre_completo, u.username, u.password_hash, u.rol_id, r.nombre, u.activo
                      FROM usuarios u
                      JOIN roles r ON u.rol_id = r.id", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            NombreCompleto = reader.GetString(1),
                            Username = reader.GetString(2),
                            PasswordHash = reader.GetString(3),
                            RolId = reader.GetInt32(4),
                            RolNombre = reader.GetString(5),
                            Activo = reader.GetBoolean(6)
                        });
                    }
                }
            }

            // MongoDB
            var usuariosMongo = conexion.ObtenerDocumentos<Usuario>("usuarios");
            // usuarios.AddRange(usuariosMongo.Where(u => !usuarios.Any(x => x.IdUsuario == u.IdUsuario)));

            return usuarios;
        }

        public void CrearUsuario(Usuario usuario)
        {
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE username = @username", conn);
                checkCmd.Parameters.AddWithValue("@username", usuario.Username);
                var exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                if (exists)
                {
                    throw new Exception("El nombre de usuario ya existe.");
                }

                var cmd = new MySqlCommand(
                    @"INSERT INTO usuarios (nombre_completo, username, password_hash, rol_id, activo)
                      VALUES (@nombre, @username, @password, @rol, @activo); SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@password", usuario.PasswordHash);
                cmd.Parameters.AddWithValue("@rol", usuario.RolId);
                cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                var id = Convert.ToInt32(cmd.ExecuteScalar());
                usuario.IdUsuario = id;

                // Obtener el nombre del rol
                var rolCmd = new MySqlCommand("SELECT nombre FROM roles WHERE id = @rolId", conn);
                rolCmd.Parameters.AddWithValue("@rolId", usuario.RolId);
                var rolNombre = rolCmd.ExecuteScalar()?.ToString() ?? "";
                usuario.RolNombre = rolNombre;
            }

            // Guardar en MongoDB con RolNombre
            conexion.InsertarDocumento("usuarios", usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    @"UPDATE usuarios SET nombre_completo=@nombre, username=@username, password_hash=@password, rol_id=@rol, activo=@activo
                      WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@password", usuario.PasswordHash);
                cmd.Parameters.AddWithValue("@rol", usuario.RolId);
                cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
                cmd.ExecuteNonQuery();
            }

            // Actualizar en MongoDB
            conexion.ActualizarDocumento("usuarios", usuario.IdUsuario.ToString(), usuario);
        }

        public string? AutenticarUsuario(string username, string password)
        {
            string passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            if (conexion.ServidorDisponible())
            {
                using (var conn = conexion.ObtenerConexionMySQL())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"SELECT r.nombre 
                          FROM usuarios u 
                          JOIN roles r ON u.rol_id = r.id 
                          WHERE u.username = @username AND u.password_hash = @passwordHash AND u.activo = TRUE", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
            else
            {
                // Autenticación en MongoDB
                var usuarios = conexion.ObtenerDocumentos<Usuario>("usuarios");
                var usuario = usuarios.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash && u.Activo);
                return usuario?.RolNombre;
            }
        }

        public int ObtenerIdUsuario(string username, string password)
        {
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                string passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
                string query = "SELECT id FROM usuarios WHERE username = @username AND password_hash = @passwordHash";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                        return id;
                    else
                        return -1;
                }
            }
        }
    }
}