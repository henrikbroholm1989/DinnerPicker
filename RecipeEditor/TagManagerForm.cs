using RecipeEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeEditor
{
    public partial class TagManagerForm : Form
    {
        private readonly RecipeDatabase _db;
        private bool _hasChanges = false;

        public TagManagerForm(RecipeDatabase db)
        {
            InitializeComponent();

            _db = db;

            RefreshTagList();
        }
        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTags.SelectedItem is not TagListItem tag)
                return;

            txtTagId.Text = tag.Id;
            txtDisplayName.Text = tag.Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = _hasChanges
        ? DialogResult.OK
        : DialogResult.Cancel;

            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtTagId.Text.Trim().ToLower();
            string name = txtDisplayName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Begge felter skal udfyldes.");
                return;
            }

            if (_db.Tags.ContainsKey(id))
            {
                MessageBox.Show("Tag ID findes allerede.");
                return;
            }

            _db.Tags.Add(id, name);

            RefreshTagList();

            txtTagId.Clear();
            txtDisplayName.Clear();

            _hasChanges = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _hasChanges = true;
        }
        private void RefreshTagList()
        {
            lstTags.Items.Clear();

            foreach (var tag in _db.Tags.OrderBy(t => t.Value))
            {
                lstTags.Items.Add(new TagListItem
                {
                    Id = tag.Key,
                    Name = tag.Value
                });
            }
        }
    }
}
