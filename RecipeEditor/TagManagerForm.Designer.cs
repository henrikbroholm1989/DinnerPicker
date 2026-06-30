namespace RecipeEditor
{
    partial class TagManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lstTags = new ListBox();
            lblTagId = new Label();
            txtTagId = new TextBox();
            txtDisplayName = new TextBox();
            lblDisplayName = new Label();
            btnDelete = new Button();
            btnClose = new Button();
            buttonTagSaveEdit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Eksisterende tags";
            // 
            // lstTags
            // 
            lstTags.FormattingEnabled = true;
            lstTags.Location = new Point(12, 32);
            lstTags.Name = "lstTags";
            lstTags.Size = new Size(185, 364);
            lstTags.TabIndex = 1;
            lstTags.SelectedIndexChanged += lstTags_SelectedIndexChanged;
            // 
            // lblTagId
            // 
            lblTagId.AutoSize = true;
            lblTagId.Location = new Point(203, 32);
            lblTagId.Name = "lblTagId";
            lblTagId.Size = new Size(51, 20);
            lblTagId.TabIndex = 2;
            lblTagId.Text = "Tag ID";
            // 
            // txtTagId
            // 
            txtTagId.Location = new Point(203, 55);
            txtTagId.Name = "txtTagId";
            txtTagId.Size = new Size(193, 27);
            txtTagId.TabIndex = 3;
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(203, 108);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(193, 27);
            txtDisplayName.TabIndex = 5;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new Point(203, 85);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(94, 20);
            lblDisplayName.TabIndex = 4;
            lblDisplayName.Text = "Visningsnavn";
            
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 409);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(185, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Slet";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(293, 409);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(103, 29);
            btnClose.TabIndex = 8;
            btnClose.Text = "Luk";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // buttonTagSaveEdit
            // 
            buttonTagSaveEdit.Location = new Point(203, 141);
            buttonTagSaveEdit.Name = "buttonTagSaveEdit";
            buttonTagSaveEdit.Size = new Size(90, 29);
            buttonTagSaveEdit.TabIndex = 9;
            buttonTagSaveEdit.Text = "Opdater";
            buttonTagSaveEdit.UseVisualStyleBackColor = true;
            buttonTagSaveEdit.Click += buttonTagSaveEdit_Click;
            // 
            // TagManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 450);
            Controls.Add(buttonTagSaveEdit);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(txtDisplayName);
            Controls.Add(lblDisplayName);
            Controls.Add(txtTagId);
            Controls.Add(lblTagId);
            Controls.Add(lstTags);
            Controls.Add(label1);
            Name = "TagManagerForm";
            Text = "TagManagerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstTags;
        private Label lblTagId;
        private TextBox txtTagId;
        private TextBox txtDisplayName;
        private Label lblDisplayName;
        private Button btnDelete;
        private Button btnClose;
        private Button buttonTagSaveEdit;
    }
}