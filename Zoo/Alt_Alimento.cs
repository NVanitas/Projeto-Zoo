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
    public partial class Alt_Alimento : Form
    {
        private string strconex;

        public Alt_Alimento()
        {
            InitializeComponent();
            InicializarConexao(); // Chama a função para inicializar a conexão
        }

        // Função para inicializar a conexão
        private void InicializarConexao()
        {
            strconex = ConfiguracaoConexao.StrConexao;
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            // Validar entrada do usuário antes de acessar o banco de dados
            if (string.IsNullOrEmpty(txt_cod.Text))
            {
                MessageBox.Show("Por favor, forneça um código antes de pesquisar.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão
                    conexao.Open();

                    DataTable tblalimentos = new DataTable();

                    // Recebe os dados do banco de dados usando parâmetros
                    string strsql = "SELECT * FROM alimentos WHERE codalimento = @codalimento";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                        adapter.Fill(tblalimentos);
                    }

                    if (tblalimentos.Rows.Count == 1)
                    {
                        txt_cod.Text = tblalimentos.Rows[0]["codalimento"].ToString();
                        txt_alimento.Text = tblalimentos.Rows[0]["alimento"].ToString();
                        txt_desc.Text = tblalimentos.Rows[0]["descricao"].ToString();

                        gb_1.Enabled = false;
                        gb_2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Registro não foi encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        gb_1.Enabled = true;
                        gb_2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na pesquisa. " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Alt_Alimento_Load(object sender, EventArgs e)
        {
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            // Fecha a tela
            this.Close();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            // Validar entrada do usuário antes de alterar o banco de dados
            if (string.IsNullOrEmpty(txt_alimento.Text) || string.IsNullOrEmpty(txt_desc.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de alterar.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão
                    conexao.Open();

                    // Altera os dados no banco de dados usando parâmetros
                    string strsql = "UPDATE alimentos SET alimento = @alimento, descricao = @descricao WHERE codalimento = @codalimento";

                    using (SqlCommand comando = new SqlCommand(strsql, conexao))
                    {
                        comando.Parameters.AddWithValue("@alimento", txt_alimento.Text);
                        comando.Parameters.AddWithValue("@descricao", txt_desc.Text);
                        comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados alterados com sucesso!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nos dados digitados. " + ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }
    }
}