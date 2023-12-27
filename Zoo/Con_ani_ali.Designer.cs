namespace Zoo
{
    partial class Con_ani_ali
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
            this.btn_one = new System.Windows.Forms.Button();
            this.btn_two = new System.Windows.Forms.Button();
            this.btn_three = new System.Windows.Forms.Button();
            this.btn_four = new System.Windows.Forms.Button();
            this.lbl_contador = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.grid_data = new System.Windows.Forms.DataGridView();
            this.btn_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Ali:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alimento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição:";
            // 
            // btn_one
            // 
            this.btn_one.Location = new System.Drawing.Point(58, 304);
            this.btn_one.Name = "btn_one";
            this.btn_one.Size = new System.Drawing.Size(54, 38);
            this.btn_one.TabIndex = 3;
            this.btn_one.Text = "<<";
            this.btn_one.UseVisualStyleBackColor = true;
            this.btn_one.Click += new System.EventHandler(this.btn_one_Click);
            // 
            // btn_two
            // 
            this.btn_two.Location = new System.Drawing.Point(273, 304);
            this.btn_two.Name = "btn_two";
            this.btn_two.Size = new System.Drawing.Size(54, 38);
            this.btn_two.TabIndex = 4;
            this.btn_two.Text = "<";
            this.btn_two.UseVisualStyleBackColor = true;
            this.btn_two.Click += new System.EventHandler(this.btn_two_Click);
            // 
            // btn_three
            // 
            this.btn_three.Location = new System.Drawing.Point(585, 304);
            this.btn_three.Name = "btn_three";
            this.btn_three.Size = new System.Drawing.Size(54, 38);
            this.btn_three.TabIndex = 5;
            this.btn_three.Text = ">";
            this.btn_three.UseVisualStyleBackColor = true;
            this.btn_three.Click += new System.EventHandler(this.btn_three_Click);
            // 
            // btn_four
            // 
            this.btn_four.Location = new System.Drawing.Point(753, 304);
            this.btn_four.Name = "btn_four";
            this.btn_four.Size = new System.Drawing.Size(54, 38);
            this.btn_four.TabIndex = 6;
            this.btn_four.Text = ">>";
            this.btn_four.UseVisualStyleBackColor = true;
            this.btn_four.Click += new System.EventHandler(this.btn_four_Click);
            // 
            // lbl_contador
            // 
            this.lbl_contador.AutoSize = true;
            this.lbl_contador.Location = new System.Drawing.Point(422, 311);
            this.lbl_contador.Name = "lbl_contador";
            this.lbl_contador.Size = new System.Drawing.Size(66, 24);
            this.lbl_contador.TabIndex = 7;
            this.lbl_contador.Text = "1 de 9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(231, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "Consultar Animal por Alimento";
            // 
            // txt_cod
            // 
            this.txt_cod.Enabled = false;
            this.txt_cod.Location = new System.Drawing.Point(165, 255);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(100, 31);
            this.txt_cod.TabIndex = 9;
            // 
            // txt_nome
            // 
            this.txt_nome.Enabled = false;
            this.txt_nome.Location = new System.Drawing.Point(165, 91);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(642, 31);
            this.txt_nome.TabIndex = 10;
            // 
            // txt_desc
            // 
            this.txt_desc.Enabled = false;
            this.txt_desc.Location = new System.Drawing.Point(165, 154);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(642, 81);
            this.txt_desc.TabIndex = 11;
            // 
            // grid_data
            // 
            this.grid_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_data.Location = new System.Drawing.Point(58, 366);
            this.grid_data.Name = "grid_data";
            this.grid_data.RowHeadersWidth = 51;
            this.grid_data.RowTemplate.Height = 24;
            this.grid_data.Size = new System.Drawing.Size(749, 272);
            this.grid_data.TabIndex = 12;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(694, 255);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(113, 31);
            this.btn_cancelar.TabIndex = 13;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Con_ani_ali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 675);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.grid_data);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.txt_cod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_contador);
            this.Controls.Add(this.btn_four);
            this.Controls.Add(this.btn_three);
            this.Controls.Add(this.btn_two);
            this.Controls.Add(this.btn_one);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Helvetica", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Con_ani_ali";
            this.Text = "Consultar Animal por Alimento";
            this.Load += new System.EventHandler(this.Con_ani_ali_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_one;
        private System.Windows.Forms.Button btn_two;
        private System.Windows.Forms.Button btn_three;
        private System.Windows.Forms.Button btn_four;
        private System.Windows.Forms.Label lbl_contador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.DataGridView grid_data;
        private System.Windows.Forms.Button btn_cancelar;
    }
}