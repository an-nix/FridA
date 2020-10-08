using MongoDB.Driver;
using RecipesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Services
{
    public class RecipeService
    {
        private readonly IMongoCollection<Recipe> _recipes;

        public RecipeService(IRecipesBookDatabaseSettings settings)
        {
            //var client = new MongoClient(settings.ConnectionString);
            var client = new MongoClient("mongodb+srv://frida:solsJP9rzPajSPqJ@cluster0.m8cdz.azure.mongodb.net/FridA?retryWrites=true&w=majority&sslVerifyCertificate=false");

            //var database = client.GetDatabase("test");

            var database = client.GetDatabase(settings.DatabaseName);

            _recipes = database.GetCollection<Recipe>(settings.RecipesBookCollectionName);
        }

        public List<Recipe> Get() =>
            _recipes.Find(recipe => true).ToList();

        public Recipe Get(string id) =>
            _recipes.Find<Recipe>(recipe => recipe.Id == id).FirstOrDefault();

        public Recipe Create(Recipe recipe)
        {
            _recipes.InsertOne(recipe);
            return recipe;
        }

        public void Update(string id, Recipe recipeIn) =>
            _recipes.ReplaceOne(recipe => recipe.Id == id, recipeIn);

        public void Remove(Recipe recipeIn) =>
            _recipes.DeleteOne(recipe => recipe.Id == recipeIn.Id);

        public void Remove(string id) =>
            _recipes.DeleteOne(recipe => recipe.Id == id);
    }
}
