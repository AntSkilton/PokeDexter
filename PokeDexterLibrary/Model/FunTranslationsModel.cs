using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeDexter.Model
{
    public class FunTranslationsModel
    {
        [JsonProperty("contents")]
        public Dictionary<string, string> Contents { get; set; }
    }
}