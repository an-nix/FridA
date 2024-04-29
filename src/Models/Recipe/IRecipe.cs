using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models.Recipe
{
    public interface IRecipe
    {
    
        Dictionary<string, string>? Description { get; set; }
        List<IIngredient>? Ingredients { get; set; }
        List<IStep>? Steps { get; set; }

    }


    public class Recipe : IRecipe
    {
        public Dictionary<string, string>? Description { get; set; }
        public List<IIngredient>? Ingredients { get; set; }
        public List<IStep>? Steps { get; set; }
    }
}
