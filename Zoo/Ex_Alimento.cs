using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Ex_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private SqlCommand comando;
        private DataTable tblalimentos, tblanimais;
        private string strsql, strconex;

        public Ex_Alimento()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //cancela o a ação excluir
            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Close();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";

                using (conexao = new SqlConnection(strconex))
                {
                    //inicia a conexão com o banco de dados ms sql server
                    conexao.Open();

                    strsql = "SELECT * FROM alimentos WHERE codalimento = @codalimento";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                        tblanimais = new DataTable();
                        adapter.Fill(tblanimais);
                    }

                    if (tblanimais.Rows.Count > 0)
                    {
                        //comando para modificar os dados para nulo ,quando os animais tem seu alimento removido do sql
                        strsql = "UPDATE Animais SET codalimento = NULL WHERE codalimento = @codalimento";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                            comando.ExecuteNonQuery();
                        }

                        //comando para deletar o alimento do banco de dados
                        strsql = "DELETE FROM alimentos WHERE codalimento = @codalimento";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);
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

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {
                //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                using (conexao = new SqlConnection(strconex))
                {
                    //inicia a conexão com o banco de dados ms sql server
                    conexao.Open();

                    tblalimentos = new DataTable();

                    //comando para receber os dados do sql
                    strsql = "SELECT * FROM alimentos WHERE codalimento = @codalimento";
                    using (adapter = new SqlDataAdapter(strsql, conexao))
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
                        MessageBox.Show("Elemento não encontrado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        gb_1.Enabled = true;
                        gb_2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão!" + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
