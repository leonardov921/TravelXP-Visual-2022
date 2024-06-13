using System.ComponentModel.DataAnnotations;

namespace TravelXP.Moviles.API.Models
{
    public class UsuarioAttributes
    {
        public int Id_usuario { get; set; }
        public required string? Nombre { get; set; }
        public required string? Apellido { get; set; }
        public required string? Nombre_usuario { get; set; }
        public required string? Email { get; set; }
        public required string? Contrasena { get; set; }
    }
}
