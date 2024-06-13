using System.ComponentModel.DataAnnotations;

namespace TravelXP.Moviles.API.Models
{
    public class LikesAttributes
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public int Id_Publicacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
