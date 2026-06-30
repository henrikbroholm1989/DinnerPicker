using RecipeEditor.Models;
using RecipeEditor.Services;

namespace RecipeEditor;

public partial class Form1 : Form
{
    private RecipeDatabase _db = new();
    private JsonService _json;
    private Recipe? _selectedRecipe;

    public Form1()
    {
        InitializeComponent();
        lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged;

        var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\data\recipes.json"));
        _json = new JsonService(path);

        LoadData();
    }

    private void LoadData()
    {
        _db = _json.Load();

        var selectedName = _selectedRecipe?.Name;

        lstRecipes.Items.Clear();

        foreach (var recipe in _db.Recipes)
        {
            lstRecipes.Items.Add(recipe.Name);
        }

        if (selectedName != null)
        {
            var index = lstRecipes.Items.IndexOf(selectedName);
            if (index >= 0)
                lstRecipes.SelectedIndex = index;
        }
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
    private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstRecipes.SelectedIndex == -1)
            return;

        var name = lstRecipes.SelectedItem.ToString();

        _selectedRecipe = _db.Recipes
            .FirstOrDefault(r => r.Name == name);

        if (_selectedRecipe == null)
            return;

        txtName.Text = _selectedRecipe.Name;
        txtTags.Text = string.Join(", ", _selectedRecipe.Tags);
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        if (_selectedRecipe == null)
            return;

        // 1. Opdatér model fra UI
        _selectedRecipe.Name = txtName.Text;

        _selectedRecipe.Tags = txtTags.Text
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Trim())
            .ToList();

        // 2. Gem hele databasen
        _json.Save(_db);

        // 3. Opdater listvisning
        LoadData();
    }
}