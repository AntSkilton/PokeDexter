using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PokeApiNet;

namespace PokeDexter.Processor
{
    public static class PokemonProcessor
    {
        static PokeApiClient s_pokeClient = new PokeApiClient();
        
        public static async Task<Pokemon> LoadPokemonData(string name)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{name}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await s_pokeClient.GetResourceAsync<Pokemon>(name);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public static async Task<PokemonSpecies> LoadPokemonSpeciesData(int id)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await s_pokeClient.GetResourceAsync<PokemonSpecies>(id);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public static ImageSource GetPokemonSprite(Pokemon pokemon)
        {
            var lookupUrl = pokemon.Sprites.FrontDefault;
            var uriSource = new Uri(lookupUrl, UriKind.Absolute);
            
            return new BitmapImage(uriSource);
        }

        public static string GetDescriptionText(PokemonSpecies species)
        {
            for (int index = 0; index < species.FlavorTextEntries.Count; index++)
            {
                if (species.FlavorTextEntries[index].Language.Name == "en")
                {
                    string removedN = species.FlavorTextEntries[index].FlavorText.Replace("\n", " ");
                    string cleanedString = removedN.Replace("\f", " ");
                    return cleanedString;
                }
            }

            return "No English description text found.";
        }
    }
}