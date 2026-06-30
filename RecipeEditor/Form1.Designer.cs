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

        private Label lblTags;
        private TextBox txtTags;

        private Button btnSave;

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

            lblTags = new Label();
            txtTags = new TextBox();

            SuspendLayout();

            // 
            // lstRecipes
            // 
            lstRecipes.FormattingEnabled = true;
            lstRecipes.ItemHeight = 20;
            lstRecipes.Location = new Point(12, 12);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(300, 380);
            lstRecipes.TabIndex = 0;

            // 
            // btnReload
            // 
            btnReload.Location = new Point(330, 12);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(120, 30);
            btnReload.TabIndex = 1;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstRecipes);
            Controls.Add(btnReload);
            Name = "Form1";
            Text = "Recipe Editor";
            Load += Form1_Load;

            // 
            // lblName
            // 
            lblName = new Label();
            lblName.Text = "Navn";
            lblName.Location = new Point(330, 60);
            lblName.AutoSize = true;

            // 
            // txtName
            // 
            txtName = new TextBox();
            txtName.Location = new Point(330, 80);
            txtName.Size = new Size(300, 25);

            // 
            // lblTags
            // 
            lblTags = new Label();
            lblTags.Text = "Tags (kommasepareret)";
            lblTags.Location = new Point(330, 120);
            lblTags.AutoSize = true;

            // 
            // txtTags
            // 
            txtTags = new TextBox();
            txtTags.Location = new Point(330, 140);
            txtTags.Size = new Size(300, 25);

            btnSave = new Button();

            btnSave.Location = new Point(330, 180);
            btnSave.Size = new Size(120, 30);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;

            // IMPORTANT: add AFTER creation
            Controls.Add(lstRecipes);
            Controls.Add(btnReload);

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblTags);
            Controls.Add(txtTags);

            Controls.Add(btnSave);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Recipe Editor";

            ResumeLayout(false);
        }

        #endregion
    }
}