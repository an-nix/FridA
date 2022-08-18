using System;
using System.Collections.Generic;
using System.Text;
using SharedModels.Product;

namespace SharedModels.Recipe
{
    public interface IIngredient
    {
        double Quantity { get; set; }
        IProduct Product { get; set; }
    }
}
