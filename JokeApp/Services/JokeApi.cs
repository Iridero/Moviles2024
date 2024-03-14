using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace JokeApp.Services
{
    public class JokeApi
    {
        private string url = "https://v2.jokeapi.dev/";
        HttpClient client;
        public async Task<List<String>> GetCategories()
        {
            client = new HttpClient();
            var respuesta = await client.GetAsync($"{url}categories");
            respuesta.EnsureSuccessStatusCode();
            var json = await respuesta.Content.ReadAsStringAsync();
            var categoryData = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoriesData>(json);
            return categoryData.Categories;
        }

        public async Task<string> GetJoke(string Category)
        {
            var respuesta = await client.GetAsync($"{url}joke/{Category}");
            respuesta.EnsureSuccessStatusCode();
            var json = await respuesta.Content.ReadAsStringAsync();
            var jokeData = Newtonsoft.Json.JsonConvert
                .DeserializeObject<JokeData>(json);
            return (jokeData.Type == "single" ? jokeData.Joke
                : $"{jokeData.Setup} {jokeData.Delivery}");
        }
    }
}
