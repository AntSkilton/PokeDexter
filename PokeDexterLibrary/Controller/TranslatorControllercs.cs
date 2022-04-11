using System.Net.Http;
using System.Threading.Tasks;
using PokeDexter.Model;

namespace PokeDexter.Controller
{
    public static class TranslatorController
    {
        public enum TranslationModelType
        {
            Shakespeare = 0,
            Yoda = 1,
        }
        
        public static bool RequestGetSuccess = true;
        
        public static async Task<FunTranslationsModel> TranslateText(TranslationModelType value, string textToTranslate)
        {
            FunTranslationsModel model = null;
            switch (value)
            {
                case TranslationModelType.Shakespeare:
                {
                    model = await GetWebRequest("shakespeare", textToTranslate);
                    break;
                }
                
                case TranslationModelType.Yoda:
                    model = await GetWebRequest("yoda", textToTranslate);
                    break;
            }

            return model;
        }

        private static async Task<FunTranslationsModel> GetWebRequest(string resourceText, string textToTranslate)
        {
            FunTranslationsModel model = new FunTranslationsModel();
            string url = $"https://api.funtranslations.com/translate/{resourceText}.json?text={textToTranslate}";

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                RequestGetSuccess = true;
                model = await response.Content.ReadAsAsync<FunTranslationsModel>();
            }
            else
            {
                RequestGetSuccess = false;
                return model;
            }

            return model;
        }
    }
}