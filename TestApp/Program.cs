using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace TestApp
{

    public class Recipe
    {
        public string Id { get; set; }

        //[BsonElement("Topic")]
        public string name { get; set; }

        public List<Ingredient> ingredients { get; set; }

        public List<String> steps { get; set; }

    }

    public class Ingredient
    {
        public string name { get; set; }

        public double quantity { get; set; }

    }

    public class Repository
    {
        public string name { get; set; }
    }

    class Program
    {

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


            Recipe r = new Recipe();
            r.name = "Carbonara";
            r.steps = new List<string>();
            r.steps.Add("Ouvrir la boite");
            r.steps.Add("Cuire");
            JsonSerializer.Serialize(r);
            StringContent s = new StringContent(JsonSerializer.Serialize(r), System.Text.Encoding.UTF8, "application/json");



            var streamTask = await client.PostAsync("https://localhost:32778/api/recipe", s) ;

            //var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            //var streamTask = client.GetStreamAsync("https://localhost:32778/api/recipe");
            //var repositories = await JsonSerializer.DeserializeAsync<List<Recipe>>(await streamTask);

            //foreach (var repo in repositories)
            //    Console.WriteLine(repo.name);

        }

        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await ProcessRepositories();


        }

    }
}
