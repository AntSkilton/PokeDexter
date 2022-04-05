using System;
using System.Threading.Tasks;
using System.Windows;
using PokeDexter;
using PokeDexter.Processor;

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
           
       }

       private async void pokemonSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pokemonSearchTextBox.Text))
            {
                throw new ArgumentException();
            }
            
            await PopulatePokemonData(pokemonSearchTextBox.Text);
        }

       private async Task PopulatePokemonData(string name)
        {
            var pokemonData = await PokemonProcessor.LoadPokemonData(name);
            var pokemonSpecies = await PokemonProcessor.LoadPokemonSpeciesData(pokemonData.Id);

            pokemonName.Text = pokemonData.Name.ToUpper();
            pokemonHabitat.Text = pokemonSpecies.Habitat.Name;
            pokemonIsLegendary.Text = pokemonSpecies.IsLegendary.ToString();
            pokemonSprite.Source = PokemonProcessor.GetPokemonSprite(pokemonData);
            pokemonDescription.Text = PokemonProcessor.GetDescriptionText(pokemonSpecies);
        }
    }
}
