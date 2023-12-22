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
            //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
     
        private void Cad_Animais_Load(object sender, EventArgs e)
        {
            try
            {
                //inicia a conexão com o banco de dados ms sql server
                conexao.Open();

                tblalimentos = new DataTable();

                //comando para receber os dados de alimentos no sql
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
                //finaliza a conexão
                conexao.Close();
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //inicia a conexão com o banco de dados ms sql server

                conexao.Open();

                //o comando de inserir dados que será executado no sql
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
                //finaliza a conexão
                conexao.Close();
            }
        }
    }
}
