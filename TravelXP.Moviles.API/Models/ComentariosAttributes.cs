using System.ComponentModel.DataAnnotations;

namespace TravelXP.Moviles.API.Models
{
    public class ComentariosAttributes
    {
        public int Id { get; set; }
        public int Id_publicacion { get; set; }
        public int Id_usuario { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
    }
}
