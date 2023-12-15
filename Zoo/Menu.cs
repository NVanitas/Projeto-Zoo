using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
           
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cad_Animais cad_animais = new Cad_Animais();
            cad_animais.Show();
        }

        private void alimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cad_Alimento cad_alimento = new Cad_Alimento();
            cad_alimento.Show();
        }

        private void alimentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Alt_Alimento alt_alimento = new Alt_Alimento();
            alt_alimento.Show();
        }

        private void animaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Alt_Animais alt_animais = new Alt_Animais();
            alt_animais.Show();
        }

        private void animaisToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Ex_Animais ex_animais = new Ex_Animais();
            ex_animais.Show();
        }

        private void alimentosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Ex_Alimento ex_alimento = new Ex_Alimento();
            ex_alimento.Show();
           
        }
    }
}
