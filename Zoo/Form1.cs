using System;
using System.Data;
using System.Data.SqlClient;
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
            // Intentionally left empty
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            // Intentionally left empty
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Intentionally left empty
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            // Intentionally left empty
        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=Login;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);

                using (conexao)
                {
                    conexao.Open();

                    tbllogin = new DataTable();

                    strsql = "SELECT * FROM usuario WHERE nome = @username AND senha = @password";

                    adapter = new SqlDataAdapter(strsql, conexao);
                    adapter.SelectCommand.Parameters.AddWithValue("@username", txt_username.Text.Replace("-", " "));
                    adapter.SelectCommand.Parameters.AddWithValue("@password", txt_pass.Text.Replace("-", " "));

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
