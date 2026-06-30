using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Models
{
    public class RecipeDatabase
    {
        public Dictionary<string, string> Tags { get; set; } = new();
        public List<Recipe> Recipes { get; set; } = new();
    }
}
