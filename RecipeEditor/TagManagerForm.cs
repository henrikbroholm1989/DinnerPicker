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
        private void SaveTag()
        {
            string id = txtTagId.Text.Trim().ToLower();
            string name = txtDisplayName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Udfyld både ID og navn.");
                return;
            }

            // Hvis vi ændrer et eksisterende tag
            if (lstTags.SelectedItem is TagListItem selected)
            {
                // Hvis ID er ændret → vi skal håndtere nøgle-skift
                if (selected.Id != id)
                {
                    if (_db.Tags.ContainsKey(id))
                    {
                        MessageBox.Show("Tag ID findes allerede.");
                        return;
                    }

                    // flyt værdi
                    _db.Tags.Remove(selected.Id);
                    _db.Tags[id] = name;
                }
                else
                {
                    _db.Tags[id] = name;
                }
            }
            else
            {
                // nyt tag
                if (_db.Tags.ContainsKey(id))
                {
                    MessageBox.Show("Tag ID findes allerede.");
                    return;
                }

                _db.Tags.Add(id, name);
            }

            _hasChanges = true;

            RefreshTagList();
        }

        private void buttonTagSaveEdit_Click(object sender, EventArgs e)
        {
            SaveTag();
        }
    }
}
