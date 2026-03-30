using CálculoFinancierodePréstamos.Clientes;
using CálculoFinancierodePréstamos.Principal;
using System;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDatosParaPago()
            {

            });
        }
    }
}
