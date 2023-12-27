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
    public partial class Ex_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private SqlCommand comando;
        private DataTable tblAlimentos, tblAnimais;
        private string strsql, strconex;

        public Ex_Alimento()
        {
            InitializeComponent();
            InicializarConexao();
        }

        private void InicializarConexao()
        {
            strconex = ConfiguracaoConexao.StrConexao;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            // Cancela a ação de excluir
            LimparCampos();
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            // Fecha a tela
            this.Close();
        }

        private void Ex_Alimento_Load(object sender, EventArgs e)
        {
            gb_2.Visible = false;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    strsql = "SELECT * FROM alimentos WHERE codalimento = @codalimento";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                        tblAnimais = new DataTable();
                        adapter.Fill(tblAnimais);
                    }

                    if (tblAnimais.Rows.Count > 0)
                    {
                        // Comando para modificar os dados para nulo quando os animais têm seu alimento removido do SQL
                        strsql = "UPDATE Animais SET codalimento = NULL WHERE codalimento = @codalimento";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                            comando.ExecuteNonQuery();
                        }

                        // Comando para deletar o alimento do banco de dados
                        strsql = "DELETE FROM alimentos WHERE codalimento = @codalimento";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                            comando.ExecuteNonQuery();
                        }

                        MessageBox.Show("Alimento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Elemento não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão! " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {
                using (conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    tblAlimentos = new DataTable();

                    strsql = "SELECT * FROM alimentos WHERE codalimento = @codalimento";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                        adapter.Fill(tblAlimentos);
                    }

                    if (tblAlimentos.Rows.Count == 1)
                    {
                        txt_cod.Text = tblAlimentos.Rows[0]["codalimento"].ToString();
                        txt_alimento.Text = tblAlimentos.Rows[0]["alimento"].ToString();
                        txt_desc.Text = tblAlimentos.Rows[0]["descricao"].ToString();

                        gb_1.Enabled = false;
                        gb_2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Elemento não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão!" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            // Limpa os campos
            txt_cod.Text = null;
            txt_alimento.Text = null;
            txt_desc.Text = null;

            gb_1.Enabled = true;
            gb_2.Visible = false;
        }
    }
}