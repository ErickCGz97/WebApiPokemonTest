using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPokemon.Entidades;

namespace WebApiPokemon.Controllers
{
    [ApiController]
    [Route("api/entrenadores")]
    public class EntrenadoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EntrenadoresController(ApplicationDbContext context) 
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Entrenador>>> Get()
        {
            return await _context.Entrenador.Include(x => x.Pokemon).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Entrenador entrenador)
        {
            _context.Add(entrenador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/entrenadores/id
        public async Task<ActionResult> Put(Entrenador entrenador, int id)
        {
            if(entrenador.Id != id)
            {
                return BadRequest("El id del entrenador Pokemon no coincide con el id de la URL");
            }
            
            var existe = await _context.Entrenador.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            _context.Update(entrenador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Entrenador.AnyAsync(x => x.Id == id);
            if(!existe)
            {
                return NotFound();
            }

            _context.Remove(new Entrenador() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
