namespace LibraryApp
{
    partial class Form_MainUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yourBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowABookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnABookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PeachPuff;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1059, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to the LibraryApp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PeachPuff;
            this.label2.Font = new System.Drawing.Font("Lucida Handwriting", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 87);
            this.label2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PeachPuff;
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Handwriting", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yourBooksToolStripMenuItem,
            this.catalogueToolStripMenuItem,
            this.borrowABookToolStripMenuItem,
            this.returnABookToolStripMenuItem,
            this.backToLoginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1151, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yourBooksToolStripMenuItem
            // 
            this.yourBooksToolStripMenuItem.Name = "yourBooksToolStripMenuItem";
            this.yourBooksToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.yourBooksToolStripMenuItem.Text = "Your books";
            this.yourBooksToolStripMenuItem.Click += new System.EventHandler(this.yourBooksToolStripMenuItem_Click);
            // 
            // catalogueToolStripMenuItem
            // 
            this.catalogueToolStripMenuItem.Name = "catalogueToolStripMenuItem";
            this.catalogueToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.catalogueToolStripMenuItem.Text = "Catalogue";
            this.catalogueToolStripMenuItem.Click += new System.EventHandler(this.catalogueToolStripMenuItem_Click);
            // 
            // borrowABookToolStripMenuItem
            // 
            this.borrowABookToolStripMenuItem.Name = "borrowABookToolStripMenuItem";
            this.borrowABookToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.borrowABookToolStripMenuItem.Text = "Borrow a book";
            this.borrowABookToolStripMenuItem.Click += new System.EventHandler(this.borrowABookToolStripMenuItem_Click);
            // 
            // returnABookToolStripMenuItem
            // 
            this.returnABookToolStripMenuItem.Name = "returnABookToolStripMenuItem";
            this.returnABookToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.returnABookToolStripMenuItem.Text = "Return a book";
            this.returnABookToolStripMenuItem.Click += new System.EventHandler(this.returnABookToolStripMenuItem_Click);
            // 
            // backToLoginToolStripMenuItem
            // 
            this.backToLoginToolStripMenuItem.Name = "backToLoginToolStripMenuItem";
            this.backToLoginToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.backToLoginToolStripMenuItem.Text = "Back to Login";
            this.backToLoginToolStripMenuItem.Click += new System.EventHandler(this.backToLoginToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form_MainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1151, 753);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_MainUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainUser_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrowABookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnABookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yourBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToLoginToolStripMenuItem;
    }
}