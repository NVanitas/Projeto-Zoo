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
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

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
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cad_Alimento_Load(object sender, EventArgs e)
        {
            // Any additional initialization code can be placed here.
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

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
                conexao.Close();
            }
        }
    }
}
