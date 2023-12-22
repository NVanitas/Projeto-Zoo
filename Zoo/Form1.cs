using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Form1 : Form
    {
        //declaração de variáveis para a conexão
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tbllogin;
        private string strsql, strconex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=Login;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);

                using (conexao)
                {
                    //inicia a conexão com o banco de dados ms sql server
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
