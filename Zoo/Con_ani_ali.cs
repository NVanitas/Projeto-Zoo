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
    public partial class Con_ani_ali : Form
    {
        private int linhas = 0;
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tblalimentos, tblanimais;
        private String strsql, strconex;

        public Con_ani_ali()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            //conexão ao servidor!, substitua "NicolasPc\\SQLSERVER2022, para seu próprio servidor!
            strconex = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;\r\n";
        }


        private void Con_ani_ali_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(strconex))
                {
                    conexao.Open();

                    tblalimentos = new DataTable();

                    string strsql = "SELECT * FROM alimentos";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conexao))
                    {
                        adapter.Fill(tblalimentos);
                    }

                    Preencher();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btn_one_Click(object sender, EventArgs e)
        {
            linhas = 0;
            Preencher();

        }


        private void btn_two_Click(object sender, EventArgs e)
        {
            if (linhas > 0)
            {

                linhas--;
                Preencher();
            }
            else
            {
                MessageBox.Show("Este é o primeiro registro.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        private void btn_three_Click(object sender, EventArgs e)
        {
            if (linhas < tblalimentos.Rows.Count - 1)
            {
                linhas++;
                Preencher();
            }
            else
            {
                MessageBox.Show("Este é o último registro.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_four_Click(object sender, EventArgs e)
        {
            linhas = tblalimentos.Rows.Count - 1;
            Preencher();

        }

        private void Preencher()
        {

            txt_cod.Text = tblalimentos.Rows[linhas]["codalimento"].ToString();
            txt_nome.Text = tblalimentos.Rows[linhas]["alimento"].ToString();
            txt_desc.Text = tblalimentos.Rows[linhas]["descricao"].ToString();

            tblanimais = new DataTable();

            strsql = "select * from animais where codalimento='" + txt_cod.Text + "'";
            adapter = new SqlDataAdapter(strsql, conexao);
            adapter.Fill(tblanimais);
            grid_data.DataSource = (tblanimais);

            lbl_contador.Text = linhas + 1 + " de " + tblalimentos.Rows.Count;

        }

    }
}
