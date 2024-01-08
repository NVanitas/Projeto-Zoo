using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Login : Form
    {
        private DataTable tbllogin;
        private string strsql, strconex;

        public Login()
        {
            InitializeComponent();
            InicializarConexaoLogin();
        }
        private void InicializarConexaoLogin()
        {
            //Altere NicolasPc\\SQLSERVER2022 para o seu próprio server de banco de dados!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=Login;Integrated Security = SSPI;TrustServerCertificate=True;";
        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    tbllogin = new DataTable();

                    strsql = "SELECT * FROM usuario WHERE nome = @username AND senha = @password";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        string username = txt_username.Text.Replace("-", " ");
                        string password = txt_pass.Text.Replace("-", " ");

                        adapter.SelectCommand.Parameters.AddWithValue("@username", username);
                        adapter.SelectCommand.Parameters.AddWithValue("@password", password);

                        adapter.Fill(tbllogin);
                    }

                    if (tbllogin.Rows.Count == 1)
                    {
                        NavigateToMenu();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao autenticar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToMenu()
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}