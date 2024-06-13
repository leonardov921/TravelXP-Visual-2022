using System.ComponentModel.DataAnnotations;

namespace TravelXP.Moviles.API.Models
{
    public class SeguidoresAttributes
    {
        public int Id_usuario { get; set; }
        public int SeguidorID { get; set; }
        public required DateTime Fecha_seguimiento { get; set; }
    }
}
