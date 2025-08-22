public void RegistrarSolicitudPrestamo(SolicitudPrestamo solicitud)
{
    using (var conn = conexion.ObtenerConexionMySQL())
    {
        conn.Open();
        string query = @"INSERT INTO solicitudes_prestamo (estudiante_id, libro_id, fecha_solicitud, estado, aprobado_por)
                         VALUES (@estudiante_id, @libro_id, @fecha_solicitud, @estado, @aprobado_por);";
        using (var cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@estudiante_id", solicitud.EstudianteId);
            cmd.Parameters.AddWithValue("@libro_id", solicitud.LibroId);
            cmd.Parameters.AddWithValue("@fecha_solicitud", solicitud.FechaSolicitud);
            cmd.Parameters.AddWithValue("@estado", solicitud.Estado);
            cmd.Parameters.AddWithValue("@aprobado_por", solicitud.AprobadoPor.HasValue ? solicitud.AprobadoPor.Value : (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // Obtén el último id generado por MySQL
        using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
        {
            var id = Convert.ToInt32(cmdId.ExecuteScalar());
            solicitud.Id = id; // Asigna el id generado
        }
    }

    // Guardar en MongoDB con Id único
    conexion.InsertarDocumento("solicitudes_prestamo", solicitud);
}

public void AprobarSolicitud(int idSolicitud, int idBibliotecario)
{
    // Actualiza en MySQL
    using (var conn = conexion.ObtenerConexionMySQL())
    {
        conn.Open();
        string query = "UPDATE solicitudes_prestamo SET estado = 'aprobado', aprobado_por = @idBibliotecario WHERE id = @idSolicitud";
        using (var cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@idBibliotecario", idBibliotecario);
            cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
            cmd.ExecuteNonQuery();
        }
    }

    // Actualiza en MongoDB
    var coleccion = conexion.ObtenerColeccionMongo<SolicitudPrestamo>("solicitudes_prestamo");
    var filtro = Builders<SolicitudPrestamo>.Filter.Eq(x => x.Id, idSolicitud);
    var actualizacion = Builders<SolicitudPrestamo>.Update
        .Set(x => x.Estado, "aprobado")
        .Set(x => x.AprobadoPor, idBibliotecario);
    coleccion.UpdateOne(filtro, actualizacion);
}