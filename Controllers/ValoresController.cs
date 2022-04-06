using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalificacionAPI.Models;

namespace CalificacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ValoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Valore>>> GetValores()
        {
            return await _context.Valores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Valore>> GetValore(int id)
        {
            var valore = await _context.Valores.FindAsync(id);

            if (valore == null)
            {
                return NotFound();
            }

            return valore;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutValore(int id, Valore valore)
        {
            if (id != valore.IdValores)
            {
                return BadRequest();
            }

            _context.Entry(valore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValoreExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Valore>> PostValore(Valore valore)
        {
            _context.Valores.Add(valore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValore", new { id = valore.IdValores }, valore);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValore(int id)
        {
            var valore = await _context.Valores.FindAsync(id);
            if (valore == null)
            {
                return NotFound();
            }

            _context.Valores.Remove(valore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValoreExists(int id)
        {
            return _context.Valores.Any(e => e.IdValores == id);
        }
    }
}
