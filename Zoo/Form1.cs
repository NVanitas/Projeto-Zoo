using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Form1 : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tbllogin;
        private string strsql, strconex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {

                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=Login;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);
                conexao.Open();

                tbllogin = new DataTable();

                strsql = "select * from usuario where nome='" + txt_username.Text.Replace("-", " ") + "' and senha = '" + txt_pass.Text.Replace("-", " ") + "'";

                adapter = new SqlDataAdapter(strsql, conexao);
                adapter.Fill(tbllogin);

                if (tbllogin.Rows.Count == 1)
                {

                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                   
                }

                else
                {
                    MessageBox.Show("Usuário ou senha incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Coloque apenas letras!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
