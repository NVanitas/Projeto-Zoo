namespace Zoo
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.alterarToolStripMenuItem,
            this.excluirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisToolStripMenuItem,
            this.alimentosToolStripMenuItem});
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            // 
            // animaisToolStripMenuItem
            // 
            this.animaisToolStripMenuItem.Name = "animaisToolStripMenuItem";
            this.animaisToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.animaisToolStripMenuItem.Text = "Animais";
            this.animaisToolStripMenuItem.Click += new System.EventHandler(this.animaisToolStripMenuItem_Click);
            // 
            // alimentosToolStripMenuItem
            // 
            this.alimentosToolStripMenuItem.Name = "alimentosToolStripMenuItem";
            this.alimentosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.alimentosToolStripMenuItem.Text = "Alimentos";
            this.alimentosToolStripMenuItem.Click += new System.EventHandler(this.alimentosToolStripMenuItem_Click);
            // 
            // alterarToolStripMenuItem
            // 
            this.alterarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisToolStripMenuItem1,
            this.alimentosToolStripMenuItem1});
            this.alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
            this.alterarToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.alterarToolStripMenuItem.Text = "Alterar";
            // 
            // animaisToolStripMenuItem1
            // 
            this.animaisToolStripMenuItem1.Name = "animaisToolStripMenuItem1";
            this.animaisToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.animaisToolStripMenuItem1.Text = "Animais";
            // 
            // alimentosToolStripMenuItem1
            // 
            this.alimentosToolStripMenuItem1.Name = "alimentosToolStripMenuItem1";
            this.alimentosToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.alimentosToolStripMenuItem1.Text = "Alimentos";
            this.alimentosToolStripMenuItem1.Click += new System.EventHandler(this.alimentosToolStripMenuItem1_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisToolStripMenuItem2,
            this.alimentosToolStripMenuItem2});
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.excluirToolStripMenuItem.Text = "Excluir";
            // 
            // animaisToolStripMenuItem2
            // 
            this.animaisToolStripMenuItem2.Name = "animaisToolStripMenuItem2";
            this.animaisToolStripMenuItem2.Size = new System.Drawing.Size(159, 26);
            this.animaisToolStripMenuItem2.Text = "Animais ";
            // 
            // alimentosToolStripMenuItem2
            // 
            this.alimentosToolStripMenuItem2.Name = "alimentosToolStripMenuItem2";
            this.alimentosToolStripMenuItem2.Size = new System.Drawing.Size(159, 26);
            this.alimentosToolStripMenuItem2.Text = "Alimentos";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alimentosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem alimentosToolStripMenuItem2;
    }
}