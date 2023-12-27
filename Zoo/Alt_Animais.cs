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
    public partial class Alt_Animais : Form
    {
        //declarar as variaveis para a conexão
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tblanimais;
        private DataTable tblalimentos;
        private string strsql, strconex;

        public Alt_Animais()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {
                using (conexao = new SqlConnection(strconex))
                {
                    //inicia a conexão com o banco de dados ms sql server
                    conexao.Open();

                    tblanimais = new DataTable();

                    //comando para receber os dados do sql
                    strsql = "select * from animais where codanimal=@codanimal";
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Close();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                //altera os dados do sql
                strsql = "update animais set animal=@animal, nome=@nome, paisorigem=@paisorigem, anonasc=@anonasc, genero=@genero, quantgramas=@quantgramas, codalimento=@codalimento where codanimal=@codanimal";
                using (conexao = new SqlConnection(strconex))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nos dados digitados." + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                LimparCampos();
            }
        }

        private void Alt_Animais_Load(object sender, EventArgs e)
        {
            CarregarAlimentos();
            HabilitarControles();
        }

        private void CarregarAlimentos()
        {
            try
            {
                using (conexao = new SqlConnection(strconex))
                {
                    //Inicia a conexão
                    conexao.Open();

                    tblalimentos = new DataTable();

                    //recebe os dados do sql
                    strsql = "select * from alimentos";
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

        private void LimparCampos()
        {
            //limpa os cambos!
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
