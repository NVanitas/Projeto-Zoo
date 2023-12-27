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
    public partial class Alt_Animais : Form
    {
        private string strconex;
        private DataTable tblalimentos;

        public Alt_Animais()
        {
            InitializeComponent();
            InicializarConexao(); // Chama a função para inicializar a conexão
            CarregarAlimentos(); // Carrega os alimentos ao iniciar o formulário
            HabilitarControles();
        }

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

                    DataTable tblanimais = new DataTable();

                    // Comando para receber os dados do SQL
                    string strsql = "select * from animais where codanimal=@codanimal";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codanimal", txt_cod.Text);
                        adapter.Fill(tblanimais);
                    }

                    if (tblanimais.Rows.Count == 1)
                    {
                        DataRow row = tblanimais.Rows[0];

                        PreencherCampos(row);

                        gb_1.Enabled = false;
                        gb_2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Registro não foi encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na pesquisa. " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PreencherCampos(DataRow row)
        {
            txt_animal.Text = row["Animal"].ToString();
            txt_nome.Text = row["Nome"].ToString();
            txt_origem.Text = row["PaisOrigem"].ToString();
            txt_nasc.Text = row["AnoNasc"].ToString();
            txt_genero.Text = row["Genero"].ToString();
            txt_gramas.Text = row["quantgramas"].ToString();

            if (row["codalimento"] != DBNull.Value)
            {
                cb_tipo.SelectedValue = row["codalimento"];
            }
            else
            {
                cb_tipo.SelectedIndex = -1;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            // Fecha a tela
            this.Close();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            // Validar entrada do usuário antes de alterar o banco de dados
            if (string.IsNullOrEmpty(txt_animal.Text) || string.IsNullOrEmpty(txt_nome.Text))
            {
                MessageBox.Show("Por favor, preencha os campos obrigatórios antes de alterar.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                // Altera os dados no SQL
                string strsql = "update animais set animal=@animal, nome=@nome, paisorigem=@paisorigem, anonasc=@anonasc, genero=@genero, quantgramas=@quantgramas, codalimento=@codalimento where codanimal=@codanimal";
                using (SqlConnection conexao = new SqlConnection(strconex))
                using (SqlCommand comando = new SqlCommand(strsql, conexao))
                {
                    conexao.Open();
                    comando.Parameters.AddWithValue("@codanimal", txt_cod.Text);
                    comando.Parameters.AddWithValue("@animal", txt_animal.Text);
                    comando.Parameters.AddWithValue("@nome", txt_nome.Text);
                    comando.Parameters.AddWithValue("@paisorigem", txt_origem.Text);
                    comando.Parameters.AddWithValue("@anonasc", txt_nasc.Text);
                    comando.Parameters.AddWithValue("@genero", txt_genero.Text);
                    comando.Parameters.AddWithValue("@quantgramas", txt_gramas.Text);
                    comando.Parameters.AddWithValue("@codalimento", cb_tipo.SelectedValue);

                    comando.ExecuteNonQuery();
                }

                MessageBox.Show("Dados alterados com sucesso!",
                                "Aviso",
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
                LimparCampos();
            }
        }

        private void CarregarAlimentos()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão
                    conexao.Open();

                    tblalimentos = new DataTable();

                    // Recebe os dados do SQL
                    string strsql = "select * from alimentos";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.Fill(tblalimentos);
                    }

                    cb_tipo.DataSource = tblalimentos;
                    cb_tipo.DisplayMember = "Alimento";
                    cb_tipo.ValueMember = "codalimento";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados." + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HabilitarControles()
        {
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }

        private void LimparCampos()
        {
            // Limpa os campos
            txt_cod.Text = null;
            txt_animal.Text = null;
            txt_nome.Text = null;
            txt_origem.Text = null;
            txt_nasc.Text = null;
            txt_genero.Text = null;
            txt_gramas.Text = null;
            cb_tipo.SelectedIndex = -1;

            HabilitarControles();
        }
    }
}
