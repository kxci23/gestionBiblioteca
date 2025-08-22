using MySql.Data.MySqlClient;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;

namespace GestionBiblioteca.Controlador
{
    public class ConexionMySQL
    {
        private string cadenaMySQL = "server=localhost;port=3306;user=root;password=;database=gestionbiblioteca";

        // --- MongoDB ---
        private readonly string cadenaMongo = "mongodb+srv://kecix2025:kevin123@gestionbiblioteca.o9jf3vy.mongodb.net/?retryWrites=true&w=majority&appName=gestionBiblioteca";
        private readonly string nombreBDMongo = "gestionbiblioteca";
        private readonly MongoClient clienteMongo;
        private readonly IMongoDatabase databaseMongo;

        public ConexionMySQL()
        {
            // Inicializa MongoDB
            clienteMongo = new MongoClient(cadenaMongo);
            databaseMongo = clienteMongo.GetDatabase(nombreBDMongo);
        }

        public MySqlConnection ObtenerConexionMySQL()
        {
            return new MySqlConnection(cadenaMySQL);
        }

        // --- Métodos MySQL existentes ---
        public DataTable EjecutarConsulta(string query, params MySqlParameter[] parametros)
        {
            if (!ServidorDisponible())
            {
                // Si MySQL no está disponible, retorna una tabla vacía o puedes implementar una consulta equivalente en MongoDB
                return new DataTable();
            }
            using (var conn = ObtenerConexionMySQL())
            using (var da = new MySqlDataAdapter(query, conn))
            {
                if (parametros != null)
                {
                    da.SelectCommand.Parameters.AddRange(parametros);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int EjecutarComando(string query, params MySqlParameter[] parametros)
        {
            if (!ServidorDisponible())
            {
                // Si MySQL no está disponible, puedes guardar en MongoDB si la lógica lo permite
                // Retorna 0 para indicar que no se ejecutó en MySQL
                return 0;
            }
            using (var conn = ObtenerConexionMySQL())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public bool ServidorDisponible()
        {
            try
            {
                using (var conn = ObtenerConexionMySQL())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // --- Métodos para MongoDB ---
        public IMongoCollection<T> ObtenerColeccionMongo<T>(string nombreColeccion)
        {
            return databaseMongo.GetCollection<T>(nombreColeccion);
        }

        // Insertar un documento en MongoDB
        public void InsertarDocumento<T>(string nombreColeccion, T documento)
        {
            var coleccion = ObtenerColeccionMongo<T>(nombreColeccion);
            coleccion.InsertOne(documento);
        }

        // Actualizar un documento en MongoDB (por Id)
        public void ActualizarDocumento<T>(string nombreColeccion, string id, T documento)
        {
            var coleccion = ObtenerColeccionMongo<T>(nombreColeccion);
            var filtro = Builders<T>.Filter.Eq("_id", BsonValue.Create(id));
            coleccion.ReplaceOne(filtro, documento);
        }

        // Obtener todos los documentos de una colección
        public List<T> ObtenerDocumentos<T>(string nombreColeccion)
        {
            var coleccion = ObtenerColeccionMongo<T>(nombreColeccion);
            return coleccion.Find(_ => true).ToList();
        }
    }
}