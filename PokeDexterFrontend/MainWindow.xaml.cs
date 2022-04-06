using System;
using System.Threading.Tasks;
using System.Windows;
using PokeDexter;
using PokeDexter.Controller;

namespace PokeDexterApp
{
    public partial class MainWindow
    {
       public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

       private async void Window_Loaded(object sender, RoutedEventArgs e)
       {
           await Task.CompletedTask;
       }

       private async void pokemonSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pokemonSearchTextBox.Text))
            {
                throw new ArgumentException();
            }
            
            await PopulatePokemonData(pokemonSearchTextBox.Text.ToLower());
        }

       private async Task PopulatePokemonData(string name)
        {
            var pokemonData = await PokemonController.LoadPokemonData(name);
            var pokemonSpecies = await PokemonController.LoadPokemonSpeciesData(pokemonData.Id);

            searchFailedText.Opacity = PokemonController.PokemonDataGetSuccess ? 0 : 1;
            
            pokemonName.Text = $"{pokemonData.Name} (#{pokemonData.Id})".ToUpper();
            pokemonHabitat.Text = pokemonSpecies.Habitat.Name;
            pokemonIsLegendary.Text = pokemonSpecies.IsLegendary ? "Yes" : "No";
            pokemonDescription.Text = PokemonController.GetDescriptionText(pokemonSpecies);
            pokemonSprite.Source = PokemonController.GetPokemonSprite(pokemonData);
        }
    }
}
