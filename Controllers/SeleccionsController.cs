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
    public class SeleccionsController : ControllerBase
    {
        private readonly DataContext _context;

        public SeleccionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seleccion>>> GetSeleccions()
        {
            return await _context.Seleccions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seleccion>> GetSeleccion(int id)
        {
            var seleccion = await _context.Seleccions.FindAsync(id);

            if (seleccion == null)
            {
                return NotFound();
            }

            return seleccion;
        }

        [HttpGet("{materia}/{semestre}/{grupo}")]
        public async Task<ActionResult<IEnumerable<Seleccion>>> GetSeleccion(int materia, int semestre, int grupo)
        {
            var seleccion = await _context.Seleccions.Where(s=>s.Materia == materia && s.Semestre == semestre && s.Grupo == grupo).ToListAsync();

            if (seleccion == null)
            {
                return NotFound();
            }

            return seleccion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeleccion(int id, Seleccion seleccion)
        {
            if (id != seleccion.IdSeleccion)
            {
                return BadRequest();
            }

            _context.Entry(seleccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeleccionExists(id))
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
        public async Task<ActionResult<Seleccion>> PostSeleccion(Seleccion seleccion)
        {
            _context.Seleccions.Add(seleccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeleccion", new { id = seleccion.IdSeleccion }, seleccion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeleccion(int id)
        {
            var seleccion = await _context.Seleccions.FindAsync(id);
            if (seleccion == null)
            {
                return NotFound();
            }

            _context.Seleccions.Remove(seleccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeleccionExists(int id)
        {
            return _context.Seleccions.Any(e => e.IdSeleccion == id);
        }
    }
}
