using GestionBiblioteca.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using MongoDB.Driver;

namespace GestionBiblioteca.Controlador
{
    public class SesionControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        public void RegistrarSesion(int usuarioId, bool activo)
        {
            string ip = ObtenerIpLocal();
            var id = Guid.NewGuid();

            // Guardar en MySQL
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                string query = @"INSERT INTO sesiones (id, usuario_id, ip_origen, creado_en, activo)
                                 VALUES (@id, @usuario_id, @ip_origen, NOW(), @activo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@ip_origen", ip);
                    cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }

            // Guardar en MongoDB
            var sesion = new Sesion
            {
                Id = id.ToString(),
                UsuarioId = usuarioId,
                IpOrigen = ip,
                CreadoEn = DateTime.Now,
                Activo = activo
            };
            conexion.InsertarDocumento("sesiones", sesion);
        }

        public void CerrarSesion(Guid sesionId)
        {
            // MySQL
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                string query = "UPDATE sesiones SET activo = 0 WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", sesionId);
                    cmd.ExecuteNonQuery();
                }
            }

            // MongoDB
            var filtro = Builders<Sesion>.Filter.Eq(s => s.Id, sesionId.ToString());
            var update = Builders<Sesion>.Update.Set(s => s.Activo, false);
            conexion.ObtenerColeccionMongo<Sesion>("sesiones").UpdateOne(filtro, update);
        }

        public List<Sesion> ObtenerSesiones()
        {
            // MySQL
            var sesiones = new List<Sesion>();
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                string query = @"SELECT s.id, s.usuario_id, s.ip_origen, s.creado_en, s.activo
                                 FROM sesiones s";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sesiones.Add(new Sesion
                        {
                            Id = reader.GetGuid(0).ToString(),
                            UsuarioId = reader.GetInt32(1),
                            IpOrigen = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                            CreadoEn = reader.GetDateTime(3),
                            Activo = reader.GetBoolean(4)
                        });
                    }
                }
            }

            // MongoDB (puedes retornar ambas listas si lo necesitas)
            // var sesionesMongo = conexion.ObtenerDocumentos<Sesion>("sesiones");

            return sesiones;
        }

        private string ObtenerIpLocal()
        {
            string ip = "127.0.0.1";
            foreach (var addr in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = addr.ToString();
                    break;
                }
            }
            return ip;
        }

        public bool IniciarSesion(string usuario, string contraseña)
        {
            if (!conexion.ServidorDisponible())
            {
                MessageBox.Show("El servidor no está disponible. Por favor, contacte al administrador.");
                return false;
            }
            // Lógica de autenticación aquí...
            return true;
        }
    }
}