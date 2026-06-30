using RecipeEditor.Models;
using RecipeEditor.Services;
using System.Linq;
using static System.Windows.Forms.AxHost;

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
        PopulateTagList();
    }

    private void LoadData()
    {
        _db = _json.Load();

        var selectedName = _selectedRecipe?.Name;

        lstRecipes.Items.Clear();

        foreach (var recipe in _db.Recipes.OrderBy(r => r.Name))
        {
            lstRecipes.Items.Add(recipe.Name);
        }

        if (selectedName != null)
        {
            var index = lstRecipes.Items.IndexOf(selectedName);
            if (index >= 0)
                lstRecipes.SelectedIndex = index;
        }

        UpdateTagChecks();
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
        LoadData();
        PopulateTagList();
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
        UpdateTagChecks();
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        if (_selectedRecipe == null)
            return;

        // 1. Opdatér model fra UI
        _selectedRecipe.Name = txtName.Text;

        _selectedRecipe.Tags = clbTags.CheckedItems
    .Cast<TagItem>()
    .Select(t => t.Id)
    .ToList();

        // 2. Gem hele databasen
        _json.Save(_db);

        // 3. Opdater listvisning
        LoadData();
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        var newRecipe = new Recipe
        {
            Name = "New recipe",
            Tags = new List<string>()
        };

        _db.Recipes.Add(newRecipe);

        _json.Save(_db);

        LoadData();

        // select newly added
        lstRecipes.SelectedItem = newRecipe.Name;
        txtName.Focus();
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedRecipe == null)
            return;

        var result = MessageBox.Show(
            $"Delete '{_selectedRecipe.Name}'?",
            "Confirm delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        _db.Recipes.Remove(_selectedRecipe);
        _selectedRecipe = null;

        txtName.Text = "";

        _json.Save(_db);

        LoadData();
    }
    private void PopulateTagList()
    {
        clbTags.Items.Clear();

        foreach (var tag in _db.Tags.OrderBy(t => t.Value))
        {
            clbTags.Items.Add(new TagItem
            {
                Id = tag.Key,
                Name = tag.Value
            });
        }
    }
    private void UpdateTagChecks()
    {
        if (_selectedRecipe == null)
            return;

        // Nulstil alle markeringer
        for (int i = 0; i < clbTags.Items.Count; i++)
        {
            clbTags.SetItemChecked(i, false);
        }

        for (int i = 0; i < clbTags.Items.Count; i++)
        {
            var tag = (TagItem)clbTags.Items[i];

            System.Diagnostics.Debug.WriteLine(
                $"Tag: {tag.Id}, Recipe has: {string.Join(", ", _selectedRecipe!.Tags)}");

            clbTags.SetItemChecked(
                i,
                _selectedRecipe!.Tags.Contains(tag.Id));
        }
    }

    private void btnManageTags_Click(object sender, EventArgs e)
    {
        using var form = new TagManagerForm(_db);

        if (form.ShowDialog() == DialogResult.OK)
        {
            _json.Save(_db);

            PopulateTagList();

            if (_selectedRecipe != null)
                UpdateTagChecks();
        }
    }
}