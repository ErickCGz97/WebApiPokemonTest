using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPokemon.Entidades;

namespace WebApiPokemon.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonController(ApplicationDbContext context) 
        {
            this._context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            return await _context.Pokemon.Include(x => x.entrenador).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pokemon pokemon)
        {
            var existeEntrenador = await _context.Entrenador.AnyAsync(x => x.Id == pokemon.entrenadorID);

            if(!existeEntrenador)
            {
                return BadRequest($"No existe el autor de ID: {pokemon.entrenadorID}");
            }

            _context.Add(pokemon);
            await _context.SaveChangesAsync();
             return Ok();
        }
    }
}
