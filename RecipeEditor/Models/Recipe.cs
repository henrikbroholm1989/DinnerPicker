using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Models;

public class Recipe
{
    public string Name { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
}
