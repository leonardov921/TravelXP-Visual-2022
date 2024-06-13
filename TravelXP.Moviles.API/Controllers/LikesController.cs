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
    public class LikesController : ControllerBase
    {
        private readonly APPDbContext _context;

        public LikesController(APPDbContext context) => _context = context;

        // GET: api/Likes
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<LikesAttributes>>> GetLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikesAttributes>> GetLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        // PUT: api/Likes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Put")]
        public async Task<IActionResult> PutLike(int id, LikesAttributes like)
        {
            if (id != like.Id)
            {
                return BadRequest();
            }

            _context.Entry(like).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post")]
        public async Task<ActionResult<LikesAttributes>> PostLike(LikesAttributes like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLike), new { id = like.Id }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.Id == id);
        }
    }
}
