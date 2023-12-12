namespace Zoo
{
    partial class Alt_Alimento
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_alimento = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.btn_procurar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.btn_retornar = new System.Windows.Forms.Button();
            this.gb_1.SuspendLayout();
            this.gb_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alterar Alimentos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alimento:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cógido:";
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(118, 105);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(311, 123);
            this.txt_desc.TabIndex = 4;
            // 
            // txt_alimento
            // 
            this.txt_alimento.Location = new System.Drawing.Point(118, 20);
            this.txt_alimento.Name = "txt_alimento";
            this.txt_alimento.Size = new System.Drawing.Size(311, 31);
            this.txt_alimento.TabIndex = 5;
            // 
            // txt_cod
            // 
            this.txt_cod.Location = new System.Drawing.Point(118, 40);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(206, 31);
            this.txt_cod.TabIndex = 6;
            // 
            // btn_procurar
            // 
            this.btn_procurar.Location = new System.Drawing.Point(330, 40);
            this.btn_procurar.Name = "btn_procurar";
            this.btn_procurar.Size = new System.Drawing.Size(99, 31);
            this.btn_procurar.TabIndex = 7;
            this.btn_procurar.Text = "Procurar";
            this.btn_procurar.UseVisualStyleBackColor = true;
            this.btn_procurar.Click += new System.EventHandler(this.btn_procurar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(118, 273);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(133, 42);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(298, 273);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(131, 42);
            this.btn_alterar.TabIndex = 9;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.btn_retornar);
            this.gb_1.Controls.Add(this.btn_procurar);
            this.gb_1.Controls.Add(this.txt_cod);
            this.gb_1.Controls.Add(this.label4);
            this.gb_1.Location = new System.Drawing.Point(58, 117);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(503, 114);
            this.gb_1.TabIndex = 10;
            this.gb_1.TabStop = false;
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.btn_alterar);
            this.gb_2.Controls.Add(this.btn_cancelar);
            this.gb_2.Controls.Add(this.txt_alimento);
            this.gb_2.Controls.Add(this.txt_desc);
            this.gb_2.Controls.Add(this.label3);
            this.gb_2.Controls.Add(this.label2);
            this.gb_2.Location = new System.Drawing.Point(58, 252);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(502, 332);
            this.gb_2.TabIndex = 11;
            this.gb_2.TabStop = false;
            // 
            // btn_retornar
            // 
            this.btn_retornar.Location = new System.Drawing.Point(330, 72);
            this.btn_retornar.Name = "btn_retornar";
            this.btn_retornar.Size = new System.Drawing.Size(99, 36);
            this.btn_retornar.TabIndex = 12;
            this.btn_retornar.Text = "Cancelar";
            this.btn_retornar.UseVisualStyleBackColor = true;
            this.btn_retornar.Click += new System.EventHandler(this.btn_retornar_Click);
            // 
            // Alt_Alimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 675);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Helvetica", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Alt_Alimento";
            this.Text = "Alterar Alimentos";
            this.Load += new System.EventHandler(this.Alt_Alimento_Load);
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.gb_2.ResumeLayout(false);
            this.gb_2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.TextBox txt_alimento;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.Button btn_procurar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.Button btn_retornar;
    }
}