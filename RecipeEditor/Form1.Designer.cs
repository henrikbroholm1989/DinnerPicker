using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeEditor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox lstRecipes;
        private Button btnReload;

        private Label lblName;
        private TextBox txtName;

        private Button btnSave;
        private Button btnAdd;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lstRecipes = new ListBox();
            btnReload = new Button();
            lblName = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            clbTags = new CheckedListBox();
            btnManageTags = new Button();
            SuspendLayout();
            // 
            // lstRecipes
            // 
            lstRecipes.FormattingEnabled = true;
            lstRecipes.Location = new Point(12, 12);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(300, 364);
            lstRecipes.TabIndex = 0;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(318, 382);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(154, 30);
            btnReload.TabIndex = 1;
            btnReload.Text = "Reload List";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(318, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 20);
            lblName.TabIndex = 4;
            lblName.Text = "Navn";
            // 
            // txtName
            // 
            txtName.Location = new Point(318, 29);
            txtName.Name = "txtName";
            txtName.Size = new Size(312, 27);
            txtName.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(478, 382);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 382);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(147, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add recipe";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(165, 382);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(147, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // clbTags
            // 
            clbTags.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbTags.CheckOnClick = true;
            clbTags.ColumnWidth = 150;
            clbTags.FormattingEnabled = true;
            clbTags.Location = new Point(318, 73);
            clbTags.MultiColumn = true;
            clbTags.Name = "clbTags";
            clbTags.Size = new Size(312, 268);
            clbTags.TabIndex = 9;
            // 
            // btnManageTags
            // 
            btnManageTags.Location = new Point(478, 347);
            btnManageTags.Name = "btnManageTags";
            btnManageTags.Size = new Size(152, 29);
            btnManageTags.TabIndex = 10;
            btnManageTags.Text = "Tilføj tags";
            btnManageTags.UseVisualStyleBackColor = true;
            btnManageTags.Click += btnManageTags_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 425);
            Controls.Add(btnManageTags);
            Controls.Add(clbTags);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(lstRecipes);
            Controls.Add(btnReload);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnSave);
            Name = "Form1";
            Text = "Recipe Editor";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbTags;
        private Button btnManageTags;
    }
}