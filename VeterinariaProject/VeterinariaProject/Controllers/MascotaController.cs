using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaProject.DataContext;
using VeterinariaProject.Models;

namespace VeterinariaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly VeterinariaDataContext _baseDatos;

        //GET: /<controller>/
        public MascotaController(VeterinariaDataContext context)
        {
            _baseDatos = context;

            if(_baseDatos.Mascotas.Count() == 0)
            {
                _baseDatos.Mascotas.Add(new Mascota { Nombre = "Koro" });
                _baseDatos.SaveChanges();
            }
        }

        //GET: api/Mascota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetMascota()
        {
            return await _baseDatos.Mascotas.Include(q => q.Raza).ToListAsync();
        }

        //GET: api/Estudiante/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(long id)
        {
            var mascota = await _baseDatos.Mascotas.Include(q => q.Raza).FirstOrDefaultAsync(q => q.Id == id);

            if(mascota == null)
            {
                return NotFound();
            }

            return mascota;
        }

        // POST: api/Mascota
        [HttpPost]
        public async Task<ActionResult<Mascota>> PostMascota(Mascota item)
        {
            _baseDatos.Mascotas.Add(item);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMascota), new { id = item.Id }, item);
        }

        // POST Rango: api/Mascota
        [HttpPost("rango")]
        public async Task<ActionResult<Mascota>> PostMascota(IEnumerable<Mascota> items)
        {
            _baseDatos.Mascotas.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMascota), items);
        }

        //PUT: api/Mascota/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            Raza raza = await _baseDatos.Razas.FirstOrDefaultAsync(q => q.Id == item.RazaId);
            if (raza == null)
            {
                return NotFound("La Raza no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/Mascota/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var mascota = await _baseDatos.Mascotas.FindAsync(id);

            if (mascota == null)
            {
                return NotFound();
            }

            _baseDatos.Mascotas.Remove(mascota);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        //DELETE Range: api/Mascota/5
        [HttpDelete("rango")]
        public async Task<ActionResult> DeleteMascotas(IEnumerable<int> ids)
        {
            IEnumerable<Mascota> mascotas = _baseDatos.Mascotas.Where(q => ids.Contains(q.Id));

            if (mascotas == null)
            {
                return NotFound();
            }

            _baseDatos.Mascotas.RemoveRange(mascotas);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

    }
}
