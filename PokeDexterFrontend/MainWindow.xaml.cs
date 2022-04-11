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
            searchFailedText.Text = PokemonController.PokemonDataGetSuccess ? "" : "Pokemon not found...";

            pokemonName.Text = $"{pokemonData.Name} (#{pokemonData.Id})".ToUpper();
            pokemonHabitat.Text = pokemonSpecies.Habitat.Name;
            pokemonIsLegendary.Text = pokemonSpecies.IsLegendary ? "Yes" : "No";
            pokemonSprite.Source = PokemonController.GetPokemonSprite(pokemonData);
            
            string originalDescriptionText = PokemonController.GetDescriptionText(pokemonSpecies);
            pokemonDescription.Text = originalDescriptionText;

            if (string.Equals(pokemonSpecies.Habitat.Name, "cave") || pokemonSpecies.IsLegendary)
            {
                var yodaText = await TranslatorController.
                    TranslateText(TranslatorController.TranslationModelType.Yoda, originalDescriptionText);

                if (TranslatorController.RequestGetSuccess)
                {
                    altDescription.Text = yodaText.Contents["translated"];
                }
            }
            else
            {
                var shakespeareText = await TranslatorController.
                    TranslateText(TranslatorController.TranslationModelType.Shakespeare, originalDescriptionText);

                if (TranslatorController.RequestGetSuccess)
                {
                    altDescription.Text = shakespeareText.Contents["translated"];
                }
               
            }

            searchFailedText.Opacity = TranslatorController.RequestGetSuccess ? 0 : 1;
            searchFailedText.Text = TranslatorController.RequestGetSuccess ? "" : "Too many API requests...";
        }
    }
}
