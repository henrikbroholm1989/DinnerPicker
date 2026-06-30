using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Models;

public class TagItem
{
    public string Id { get; init; } = "";
    public string Name { get; init; } = "";

    public override string ToString()
    {
        return Name;
    }
}