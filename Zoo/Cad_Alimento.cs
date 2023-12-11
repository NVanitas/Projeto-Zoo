using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Cad_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlCommand comando;
        private string strsql, strconex;
        public Cad_Alimento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);
                conexao.Open();

                strsql = "insert into Alimentos (alimento,descricao) values ('" + txt_alimento.Text + "','" + txt_desc.Text + "')";
                comando = new SqlCommand(strsql, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Alimento Cadastrado!!! ",
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                    conexao = new SqlConnection(strconex);
                    conexao.Open();

                    strsql = "insert into Alimentos (alimento,descricao) values ('" + txt_alimento.Text + "','" + txt_desc.Text + "')";
                    comando = new SqlCommand(strsql, conexao);
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Alimento Cadastrado!!! ",
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
            }
        }
    }
}