using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Cad_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlCommand comando;
        private string strsql, strconex;

        public Cad_Alimento()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022", para seu próprio servidor!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //inicia a conexão com o banco de dados ms sql server
                conexao.Open();

                //o comando de inserir dados que será executado no sql
                strsql = "insert into Alimentos (alimento,descricao) values (@alimento, @descricao)";
                comando = new SqlCommand(strsql, conexao);
                comando.Parameters.AddWithValue("@alimento", txt_alimento.Text);
                comando.Parameters.AddWithValue("@descricao", txt_desc.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show("Alimento Cadastrado!!! ",
                                    "Atenção!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nos dados digitados. " + ex.Message,
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            }
            finally
            {
                //finaliza a conexão
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Close();
        }
        
    }
}
