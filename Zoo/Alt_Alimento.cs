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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
            conexao.Open();

            tblalimentos = new DataTable();

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
                txt_cod = null;
                gb_1.Enabled = true;
                gb_2.Visible = false;
            }

        }

        private void Alt_Alimento_Load(object sender, EventArgs e)
        {
            gb_1.Enabled = true;
            gb_2.Visible = false;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

            gb_1.Enabled = true;
            gb_2.Visible = false;

        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
                conexao = new SqlConnection(strconex);
                conexao.Open();

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
