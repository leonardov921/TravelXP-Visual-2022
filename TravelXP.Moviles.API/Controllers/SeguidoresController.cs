using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class SeguidoresController : ControllerBase
    {
        private readonly APPDbContext _context;

        public SeguidoresController(APPDbContext context)
        {
            _context = context;
        }

        // GET: api/Seguidores
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<SeguidoresAttributes>>> GetSeguidores()
        {
            return await _context.Seguidores.ToListAsync();
        }

        // GET: api/Seguidores/5
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<SeguidoresAttributes>> GetSeguidor(int id_usuario)
        {
            var seguidor = await _context.Seguidores.FindAsync(id_usuario);

            if (seguidor == null)
            {
                return NotFound();
            }

            return seguidor;
        }

        // PUT: api/Seguidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Put")]
        public async Task<IActionResult> PutSeguidor(int id_usuario, SeguidoresAttributes seguidor)
        {
            if (id_usuario != seguidor.Id_usuario)
            {
                return BadRequest();
            }

            _context.Entry(seguidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguidorExists(id_usuario))
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

        // POST: api/Seguidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post")]
        public async Task<ActionResult<SeguidoresAttributes>> PostSeguidor(SeguidoresAttributes seguidor)
        {
            _context.Seguidores.Add(seguidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeguidor), new { id_usuario = seguidor.Id_usuario }, seguidor);
        }

        // DELETE: api/Seguidores/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSeguidor(int id_usuario)
        {
            var seguidor = await _context.Seguidores.FindAsync(id_usuario);
            if (seguidor == null)
            {
                return NotFound();
            }

            _context.Seguidores.Remove(seguidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguidorExists(int id_usuario)
        {
            return _context.Seguidores.Any(e => e.Id_usuario == id_usuario);
        }
    }
}
