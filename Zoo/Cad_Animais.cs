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
    public partial class Cad_Animais : Form
    {
        private SqlConnection conexao;
        private SqlCommand comando;
        private string strsql, strconex;
        private SqlDataAdapter adapter;
        private DataTable tblalimentos;

        public Cad_Animais()
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
            this.Close();
        }

        private void Cad_Animais_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    tblalimentos = new DataTable();

                    string strsql = "SELECT * FROM alimentos";
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
                MessageBox.Show("Erro ao carregar dados. " + ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    string strsql = "INSERT INTO Animais (Animal, Nome, PaisOrigem, AnoNasc, Genero, QuantGramas, CodAlimento) " +
                                    "VALUES (@Animal, @Nome, @PaisOrigem, @AnoNasc, @Genero, @QuantGramas, @CodAlimento)";

                    using (SqlCommand comando = new SqlCommand(strsql, conexao))
                    {
                        comando.Parameters.AddWithValue("@Animal", txt_animal.Text);
                        comando.Parameters.AddWithValue("@Nome", txt_nome.Text);
                        comando.Parameters.AddWithValue("@PaisOrigem", txt_origem.Text);
                        comando.Parameters.AddWithValue("@AnoNasc", txt_nasc.Text);
                        comando.Parameters.AddWithValue("@Genero", txt_genero.Text);
                        comando.Parameters.AddWithValue("@QuantGramas", txt_gramas.Text);
                        comando.Parameters.AddWithValue("@CodAlimento", cb_tipo.SelectedValue);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Animal Cadastrado!!! ",
                                    "Atenção!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nos dados digitados. " + ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
    }
}