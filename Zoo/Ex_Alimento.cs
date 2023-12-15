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
            txt_cod.Text = null;
            gb_1.Enabled = true;
            gb_2.Visible = false;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ex_Alimento_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";

                using (conexao = new SqlConnection(strconex))
                {
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
                        strsql = "UPDATE Animais SET codalimento = NULL WHERE codalimento = @codalimento";
                        using (comando = new SqlCommand(strsql, conexao))
                        {
                            comando.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                            comando.ExecuteNonQuery();
                        }

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
                        MessageBox.Show("The record was not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in the entered data. " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                using (conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    tblalimentos = new DataTable();

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
                        MessageBox.Show("Record not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        gb_1.Enabled = true;
                        gb_2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in the entered data. " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
