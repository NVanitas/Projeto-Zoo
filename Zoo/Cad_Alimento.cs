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
    public partial class Cad_Alimento : Form
    {
        private SqlConnection conexao;
        private SqlCommand comando;
        private string strsql, strconex;

        public Cad_Alimento()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022", para seu próprio servidor!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    string strsql = "INSERT INTO Alimentos (alimento, descricao) VALUES (@alimento, @descricao)";

                    using (SqlCommand comando = new SqlCommand(strsql, conexao))
                    {
                        comando.Parameters.AddWithValue("@alimento", txt_alimento.Text);
                        comando.Parameters.AddWithValue("@descricao", txt_desc.Text);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Alimento Cadastrado!!!",
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

        private void button2_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Close();
        }

    }
}
