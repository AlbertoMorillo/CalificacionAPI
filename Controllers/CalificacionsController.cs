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
    public class CalificacionsController : ControllerBase
    {
        private readonly DataContext _context;

        public CalificacionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> GetCalificacions()
        {
            return await _context.Calificacions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion(int id)
        {
            var calificacion = await _context.Calificacions.FindAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return calificacion;
        }
        [HttpGet("{codigoProfesor}/{materia}/{grupo}/{semestre}")]
        public async Task<ActionResult<IEnumerable<Calificacion>>> getGalificacionCalificadasAsync(int codigoProfesor, string materia, int? grupo, int semestre)
        {
            return await _context.Calificacions.Where(h=>h.Codigoprof == codigoProfesor && h.Materia == int.Parse(materia) && h.Grupo == grupo && h.Semestre == semestre).ToListAsync();
        }

        [HttpGet("Init/{codigoProfesor}/{materia}/{semestre}")]
        public async Task<ActionResult<IEnumerable<Horario>>> getGalificacionCalificadasNotGrupoAsync(int codigoProfesor, string materia, int semestre)
        {
            return await _context.Horarios.Where(h => h.Usuario == codigoProfesor && h.Materia == int.Parse(materia) && h.Semestre == semestre).ToListAsync();
        }

        [HttpGet("{codigoProfesor}/{materia}/{grupo}/{semestre}/{matricula}")]
        public  ActionResult<Calificacion> getGalificacionCalificadasGrupoAsync(int codigoProfesor, string materia,int grupo, int semestre, string matricula)
        {
            return _context.Calificacions.Where(h => h.Codigoprof == codigoProfesor && h.Materia == int.Parse(materia) && h.Semestre == semestre && h.Codigoprof == codigoProfesor && h.Matriculan == matricula && h.Grupo == grupo).FirstOrDefault();
        }

        [HttpGet("{materia}/{grupo}/{semestre}")]
        public async Task<ActionResult<IEnumerable<Horario>>> GetCalificacionEstudiantes(string materia, int grupo, int semestre)
        {
            return await _context.Horarios.Where(h => h.Materia == int.Parse(materia) && h.Grupo == grupo && h.Semestre == semestre).ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, Calificacion calificacion)
        {
            if (id != calificacion.IdCalificacion)
            {
                return BadRequest();
            }

            _context.Entry(calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(id))
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
        public async Task<ActionResult<Calificacion>> PostCalificacion(Calificacion calificacion)
        {
            _context.Calificacions.Add(calificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificacion", new { id = calificacion.IdCalificacion }, calificacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificacions.Remove(calificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificacions.Any(e => e.IdCalificacion == id);
        }
    }
}
