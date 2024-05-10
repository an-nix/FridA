using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public interface IProduct
    {
        Dictionary<string,string>? Description { get; set; }
        string? Barcode { get; set; }
    }

    public class Product : IProduct
    {
        public Dictionary<string,string>? Description { get; set; }
        public string? Barcode { get; set; }

    }
}
