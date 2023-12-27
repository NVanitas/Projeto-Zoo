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
using static Zoo.Menu;

namespace Zoo
{
    public partial class Con_ani_ali : Form
    {
        private int linhaAtual = 0;
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tblAlimentos, tblAnimais;
        private string strsql, strconex;

        public Con_ani_ali()
        {
            InitializeComponent();
            InicializarConexao();
        }

        private void InicializarConexao()
        {
            strconex = ConfiguracaoConexao.StrConexao;
            conexao = new SqlConnection(strconex); // Inicialize a conexão aqui
        }

        private void Con_ani_ali_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open(); // Abra a conexão aqui

                tblAlimentos = new DataTable();

                string strsql = "SELECT * FROM alimentos";

                using (adapter = new SqlDataAdapter(strsql, conexao))
                {
                    adapter.Fill(tblAlimentos);
                }

                Preencher();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close(); // Feche a conexão aqui, garantindo que ela seja fechada mesmo em caso de exceção
            }
        }

        private void btn_one_Click(object sender, EventArgs e)
        {
            linhaAtual = 0;
            Preencher();
        }

        private void btn_two_Click(object sender, EventArgs e)
        {
            if (linhaAtual > 0)
            {
                linhaAtual--;
                Preencher();
            }
            else
            {
                MessageBox.Show("Este é o primeiro registro.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_three_Click(object sender, EventArgs e)
        {
            if (linhaAtual < tblAlimentos.Rows.Count - 1)
            {
                linhaAtual++;
                Preencher();
            }
            else
            {
                MessageBox.Show("Este é o último registro.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_four_Click(object sender, EventArgs e)
        {
            linhaAtual = tblAlimentos.Rows.Count - 1;
            Preencher();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preencher()
        {
            if (linhaAtual >= 0 && linhaAtual < tblAlimentos.Rows.Count)
            {
                txt_cod.Text = tblAlimentos.Rows[linhaAtual]["codalimento"].ToString();
                txt_nome.Text = tblAlimentos.Rows[linhaAtual]["alimento"].ToString();
                txt_desc.Text = tblAlimentos.Rows[linhaAtual]["descricao"].ToString();

                tblAnimais = new DataTable();

                strsql = "SELECT * FROM animais WHERE codalimento = @codalimento";
                using (adapter = new SqlDataAdapter(strsql, conexao))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@codalimento", txt_cod.Text);
                    adapter.Fill(tblAnimais);
                }

                grid_data.DataSource = tblAnimais;

                lbl_contador.Text = (linhaAtual + 1) + " de " + tblAlimentos.Rows.Count;
            }
        }
    }
}