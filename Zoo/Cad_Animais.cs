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
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
            conexao.Open();

            tblalimentos = new DataTable();

            strsql = "select * from alimentos";
            adapter = new SqlDataAdapter(strsql, conexao);
            adapter.Fill(tblalimentos);

            cb_tipo.DataSource = tblalimentos;
            cb_tipo.DisplayMember = "Alimento";
            cb_tipo.ValueMember = "codalimento";
   

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);
                conexao.Open();


                strsql = "insert into Animais (Animal,Nome,PaisOrigem,AnoNasc,Genero,QuantGramas,CodAlimento) values ('" + txt_animal.Text + "','" + txt_nome.Text + "','" + txt_origem.Text + "','" + txt_nasc.Text + "','" + txt_genero.Text + "','" + txt_gramas.Text + "','" + cb_tipo.SelectedValue + "')";
                comando = new SqlCommand(strsql, conexao);
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

        }
    }
}
