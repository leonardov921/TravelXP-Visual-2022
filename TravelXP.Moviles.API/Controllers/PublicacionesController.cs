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
    public class PublicacionesController : ControllerBase
    {
        private readonly APPDbContext _context;

        public PublicacionesController(APPDbContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<PublicacionesAttributes>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }

        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicacionesAttributes>> GetPublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }

        // PUT: api/Publicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Put")]
        public async Task<IActionResult> PutPublicacion(int id, PublicacionesAttributes publicacion)
        {
            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // POST: api/Publicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post")]
        public async Task<ActionResult<PublicacionesAttributes>> PostPublicacion(PublicacionesAttributes publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublicacion), new { id = publicacion.Id }, publicacion);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacionExists(int id)
        {
            return _context.Publicaciones.Any(e => e.Id == id);
        }
    }
}
