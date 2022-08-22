using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Product;

namespace Models.Recipe
{
    public interface IIngredient
    {
        IProduct Product { get; set; }
        double Quantity { get; set; }
    }
}
