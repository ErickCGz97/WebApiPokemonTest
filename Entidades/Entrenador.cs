namespace WebApiPokemon.Entidades
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Pokemon> Pokemon { get; set; }
    }
}
