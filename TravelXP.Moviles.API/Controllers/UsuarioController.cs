using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelXP.Moviles.API.Context;
using TravelXP.Moviles.API.Models;

namespace TravelXP.Moviles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsuarioController : ControllerBase
    {
        private readonly APPDbContext _context;

        public UsuarioController(APPDbContext context) => _context = context;

        // GET: api/Usuario
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<UsuarioAttributes>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<UsuarioAttributes>> GetUsuario(int id_usuario)
        {
            var usuario = await _context.Usuarios.FindAsync(id_usuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        [HttpPut("Put/{id_usuario}")]
        public async Task<IActionResult> PutUsuario(int id_usuario, UsuarioAttributes usuario)
        {
            if (id_usuario != usuario.Id_usuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id_usuario))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        [HttpPost("Post")]
        public async Task<ActionResult<UsuarioAttributes>> PostUsuario(UsuarioAttributes usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id_usuario = usuario.Id_usuario }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("Delete/{id_usuario}")]
        public async Task<IActionResult> DeleteUsuario(int id_usuario)
        {
            var usuario = await _context.Usuarios.FindAsync(id_usuario);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Usuario/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioAttributes>> Login([FromBody] LoginRequest loginRequest)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Contrasena == loginRequest.Contrasena);

            if (usuario == null)
            {
                return Unauthorized();
            }

            return usuario;
        }

        private bool UsuarioExists(int id_usuario)
        {
            return _context.Usuarios.Any(e => e.Id_usuario == id_usuario);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
