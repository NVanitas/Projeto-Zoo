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
using static Zoo.Menu;

namespace Zoo
{
    public partial class Cad_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlCommand comando;
        private string strconex;

        public Cad_Alimento()
        {
            InitializeComponent();
            InicializarConexao();
        }

        private void InicializarConexao()
        {
            strconex = ConfiguracaoConexao.StrConexao;

            // Inicializa a instância de conexão
            conexao = new SqlConnection(strconex);

            // Inicializa a instância de comando
            comando = new SqlCommand();
            comando.Connection = conexao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

                // Define o comando SQL
                comando.CommandText = "INSERT INTO Alimentos (alimento, descricao) VALUES (@alimento, @descricao)";

                // Adiciona parâmetros ao comando
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@alimento", txt_alimento.Text);
                comando.Parameters.AddWithValue("@descricao", txt_desc.Text);

                // Executa o comando
                comando.ExecuteNonQuery();

                MessageBox.Show("Alimento Cadastrado!!!",
                                "Atenção!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
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
                // Fecha a conexão, independentemente de ter ocorrido uma exceção ou não
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Fecha a tela
            this.Close();
        }
    }
}