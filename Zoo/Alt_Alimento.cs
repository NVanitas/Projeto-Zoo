using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Alt_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private SqlCommand comando;
        private DataTable tblalimentos;
        private string strsql, strconex;

        public Alt_Alimento()
        {
            InitializeComponent();
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {  
                //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);
                //inicia a conexão
                conexao.Open();

                tblalimentos = new DataTable();

                //recebe os dados do banco de dados!
                strsql = "select * from alimentos where codalimento='" + txt_cod.Text + "'";
                adapter = new SqlDataAdapter(strsql, conexao);
                adapter.Fill(tblalimentos);

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
            catch (Exception ex)
            {
                MessageBox.Show("Erro na pesquisa." + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Alt_Alimento_Load(object sender, EventArgs e)
        {
            gb_1.Enabled = true;
            gb_2.Visible = false;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //
            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;

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
                conexao = new SqlConnection(strconex);
                //inicia a conexão
                conexao.Open();

                //altera os dados do banco de dados
                strsql = "update alimentos set alimento='" + txt_alimento.Text + "',descricao='" + txt_desc.Text + "' where codalimento ='" + txt_cod.Text + "'";
                comando = new SqlCommand(strsql, conexao);
                comando.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro nos dados digitados." + ex.Message, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;

        }
    }
}
