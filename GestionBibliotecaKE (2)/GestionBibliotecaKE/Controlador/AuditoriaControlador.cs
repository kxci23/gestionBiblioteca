using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca.Controlador
{
    internal class AuditoriaControlador
    {
        private readonly List<Auditoria> auditorias = new();

        public void RegistrarEvento(string usuario, string accion, string descripcion)
        {
            auditorias.Add(new Auditoria
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Accion = accion,
                Descripcion = descripcion
            });
        }

        public IEnumerable<Auditoria> ObtenerEventos()
        {
            return auditorias.OrderByDescending(a => a.Fecha);
        }

        public IEnumerable<Auditoria> BuscarPorUsuario(string usuario)
        {
            return auditorias.Where(a => a.Usuario.Equals(usuario, StringComparison.OrdinalIgnoreCase));
        }
    }

    // Clase de ejemplo para Auditoria
    internal class Auditoria
    {
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}