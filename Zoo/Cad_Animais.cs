using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cad_Animais_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

                tblalimentos = new DataTable();

                strsql = "select * from alimentos";
                adapter = new SqlDataAdapter(strsql, conexao);
                adapter.Fill(tblalimentos);

                cb_tipo.DataSource = tblalimentos;
                cb_tipo.DisplayMember = "Alimento";
                cb_tipo.ValueMember = "codalimento";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados. " + ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

                strsql = "insert into Animais (Animal,Nome,PaisOrigem,AnoNasc,Genero,QuantGramas,CodAlimento) " +
                         "values (@Animal, @Nome, @PaisOrigem, @AnoNasc, @Genero, @QuantGramas, @CodAlimento)";

                comando = new SqlCommand(strsql, conexao);
                comando.Parameters.AddWithValue("@Animal", txt_animal.Text);
                comando.Parameters.AddWithValue("@Nome", txt_nome.Text);
                comando.Parameters.AddWithValue("@PaisOrigem", txt_origem.Text);
                comando.Parameters.AddWithValue("@AnoNasc", txt_nasc.Text);
                comando.Parameters.AddWithValue("@Genero", txt_genero.Text);
                comando.Parameters.AddWithValue("@QuantGramas", txt_gramas.Text);
                comando.Parameters.AddWithValue("@CodAlimento", cb_tipo.SelectedValue);

                comando.ExecuteNonQuery();

                MessageBox.Show("Animal Cadastrado!!! ",
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
