using ActividadAutoaprendizaje.Data;
using ActividadAutoaprendizaje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActividadAutoaprendizaje.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        // GET: api/Contactos/buscar?texto=ana
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Contacto>>> BuscarContactos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return await _context.Contactos.ToListAsync();
            }

            var contactos = await _context.Contactos
                .Where(c => c.Nombre.Contains(texto) ||
                            c.Apellido.Contains(texto))
                .ToListAsync();

            return contactos;
        }


        // GET: api/Contactos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        // POST: api/Contactos
        [HttpPost]
        public async Task<ActionResult<Contacto>> CrearContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetContacto),
                new { id = contacto.Id },
                contacto);
        }

        // PUT: api/Contactos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarContacto(int id, Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExiste(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Contactos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExiste(int id)
        {
            return _context.Contactos.Any(e => e.Id == id);
        }
    }
}