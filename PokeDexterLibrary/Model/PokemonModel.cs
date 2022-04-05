namespace PokeDexter.Model
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool IsLegendary { get; set; }
        public string SpriteUrl { get; set; }
    
        public PokemonModel(string name, string description, string habitat, bool isLegendary, string spriteUrl)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            SpriteUrl = spriteUrl;
        }

        public PokemonModel() { }
    }
}