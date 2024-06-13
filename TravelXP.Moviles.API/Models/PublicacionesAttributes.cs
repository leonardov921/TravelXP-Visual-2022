using System.ComponentModel.DataAnnotations;

namespace TravelXP.Moviles.API.Models
{
    public class PublicacionesAttributes
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_publicacion { get; set; }
        public string Ubicacion { get; set; }
    }
}
