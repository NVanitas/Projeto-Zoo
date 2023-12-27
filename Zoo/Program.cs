using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

    }
    public static class ConfiguracaoConexao
    {
        //altere a string de conexão,mude : "Nicolas\\SQLSERVER2022" para o seu próprio banco de dados!
        public static string StrConexao { get; } = "Server=NicolasPc\\SQLSERVER2022;Database=zoologico;Trusted_Connection=True;";
    }
}
