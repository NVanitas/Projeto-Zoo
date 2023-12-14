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
    public partial class Alt_Animais : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private SqlCommand comando;
        private DataTable tblanimais;
        private DataTable tblalimentos;
        private string strsql, strconex;


        public Alt_Animais()
        {
            InitializeComponent();
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
            conexao = new SqlConnection(strconex);
            conexao.Open();

            tblanimais = new DataTable();

            strsql = "select * from animais where codanimal='" + txt_cod.Text + "'";
            adapter = new SqlDataAdapter(strsql, conexao);
            adapter.Fill(tblanimais);

            if (tblanimais.Rows.Count == 1)
            {
                txt_animal.Text = tblanimais.Rows[0]["Animal"].ToString();
                txt_nome.Text = tblanimais.Rows[0]["Nome"].ToString();
                txt_origem.Text = tblanimais.Rows[0]["PaisOrigem"].ToString();
                txt_nasc.Text = tblanimais.Rows[0]["AnoNasc"].ToString();
                txt_genero.Text = tblanimais.Rows[0]["Genero"].ToString();
                txt_gramas.Text = tblanimais.Rows[0]["quantgramas"].ToString();             

                gb_1.Enabled = false;
                gb_2.Visible = true;
            }
            else
            {

                MessageBox.Show("Registro não foi encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Text = null;
                gb_1.Enabled = true;
                gb_2.Visible = false;
            }




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

                strsql = "update animais set animal='" + txt_animal.Text + "',nome='" + txt_nome.Text + "',paisorigem='" + txt_origem.Text + "',anonasc='" + txt_nasc.Text + "',genero='" + txt_genero.Text + "',quantgramas='" + txt_gramas.Text + "', codalimento='" + cb_tipo.SelectedIndex + "' where codanimal ='" + txt_cod.Text + "'";
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

    

    private void Alt_Animais_Load(object sender, EventArgs e)
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

            gb_1.Enabled = true;
            gb_2.Visible = false;
        }
    }
}
