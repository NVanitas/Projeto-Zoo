using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Ex_Animais : Form
    {
        // Declarar as variáveis para a conexão
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private SqlCommand comando;
        private DataTable tblanimais;
        private DataTable tblalimentos;
        private string strsql, strconex;

        public Ex_Animais()
        {
            InitializeComponent();
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            // Fecha a tela
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void Ex_Animais_Load(object sender, EventArgs e)
        {
            CarregarAlimentos();
            HabilitarControles();
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {
                // Conexão ao servidor, substitua "NicolasPc\\SQLSERVER2022" pelo seu próprio servidor
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";
                using (conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão com o banco de dados MS SQL Server
                    conexao.Open();

                    tblanimais = new DataTable();

                    // Comando para receber os dados do SQL
                    strsql = "SELECT * FROM animais WHERE codanimal=@codanimal";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codanimal", txt_cod.Text);
                        adapter.Fill(tblanimais);
                    }

                    if (tblanimais.Rows.Count == 1)
                    {
                        DataRow row = tblanimais.Rows[0];

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

                        gb_1.Enabled = false;
                        gb_2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Registro não foi encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cod.Text = null;
                        gb_1.Enabled = true;
                        gb_2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na pesquisa." + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CarregarAlimentos()
        {
            try
            {
                // Conexão ao servidor, substitua "NicolasPc\\SQLSERVER2022" pelo seu próprio servidor
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";
                using (conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão
                    conexao.Open();

                    tblalimentos = new DataTable();

                    // Recebe os dados do SQL
                    strsql = "SELECT * FROM alimentos";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
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

        private void btn_excluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Conexão ao servidor, substitua "NicolasPc\\SQLSERVER2022" pelo seu próprio servidor
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";

                using (conexao = new SqlConnection(strconex))
                {
                    // Inicia a conexão com o banco de dados MS SQL Server
                    conexao.Open();

                    strsql = "SELECT * FROM Animais WHERE codanimal = @codanimal";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codanimal", txt_cod.Text);
                        tblanimais = new DataTable();
                        adapter.Fill(tblanimais);
                    }

                    if (tblanimais.Rows.Count > 0)
                    {
                        // Comando para deletar o animal do banco de dados
                        strsql = "DELETE FROM Animais WHERE codanimal = @codanimal";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codanimal", txt_cod.Text);
                            comando.ExecuteNonQuery();
                        }

                        gb_1.Enabled = true;
                        gb_2.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Elemento não encontrado!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão! " + ex.Message, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
