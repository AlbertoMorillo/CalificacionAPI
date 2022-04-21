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
    public class HorariosController : ControllerBase
    {
        private readonly DataContext _context;

        public HorariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Horario>> GetHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            return horario;
        }

        [HttpGet("{semestre}/{codigoProfesor}")]
        public List<string> GetHorarioDistinct(int semestre, int codigoProfesor)
        {
            var query = _context.Horarios.AsQueryable();
            query = query.Where(a => a.Semestre == semestre && a.Usuario == codigoProfesor && a.Estatus != "N");
            var horarios = query.Select(s => s.Materia.ToString()).Distinct().ToList();
            return horarios;
        }

        [HttpGet("{codigoMateria}/{semestre}/{codigoProfesor}")]
        public List<int?> GetGruposDistinct(int codigoMateria, int semestre, int codigoProfesor)
        {
            var query = _context.Horarios.AsQueryable();
            query = query.Where(s => s.Materia == codigoMateria && s.Semestre == semestre && s.Usuario == codigoProfesor);
            List<int?> grupos = query.Select(h => h.Grupo).Distinct().ToList();
            return grupos;
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(int id, Horario horario)
        {
            if (id != horario.IdHorarios)
            {
                return BadRequest();
            }

            _context.Entry(horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(id))
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
        public async Task<ActionResult<Horario>> PostHorario(Horario horario)
        {
            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorario", new { id = horario.IdHorarios }, horario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }

            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.IdHorarios == id);
        }
    }
}
