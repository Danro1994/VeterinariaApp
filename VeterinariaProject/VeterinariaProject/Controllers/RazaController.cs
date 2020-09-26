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
    public class RazaController : ControllerBase
    {
        private readonly VeterinariaDataContext _baseDatos;

        //GET: /<controller>/
        public RazaController(VeterinariaDataContext context)
        {
            _baseDatos = context;

            if (_baseDatos.Mascotas.Count() == 0)
            {
                _baseDatos.Razas.Add(new Raza { Nombre = "Border Collie" });
                _baseDatos.Razas.Add(new Raza { Nombre = "Doberman" });
                _baseDatos.SaveChanges();
            }
        }

        //GET: api/Raza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raza>>> GetRaza()
        {
            return await _baseDatos.Razas.ToListAsync();
        }

        //GET: api/Raza/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(long id)
        {
            var mascota = await _baseDatos.Mascotas.Include(q => q.Raza).FirstOrDefaultAsync(q => q.Id == id);

            if (mascota == null)
            {
                return NotFound();
            }

            return mascota;
        }

        // POST: api/Raza
        [HttpPost]
        public async Task<ActionResult<Raza>> PostRaza(Raza item)
        {
            _baseDatos.Razas.Add(item);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaza), new { id = item.Id }, item);

        }

        //PUT: api/Raza/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaza(int id, Raza item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/Raza/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaza(int id)
        {
            var raza = await _baseDatos.Razas.FindAsync(id);

            if (raza == null)
            {
                return NotFound();
            }

            _baseDatos.Razas.Remove(raza);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

    }
}
