using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models
{
    public class RecipesBookDatabaseSettings : IRecipesBookDatabaseSettings
    {

            public string RecipesBookCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
     }

        public interface IRecipesBookDatabaseSettings
    {
            string RecipesBookCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }

 }

