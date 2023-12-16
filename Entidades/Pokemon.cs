namespace WebApiPokemon.Entidades
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string pokemonName { get; set; }

        public int entrenadorID { get; set; }
        
        public Entrenador entrenador { get; set; }
    }
}
