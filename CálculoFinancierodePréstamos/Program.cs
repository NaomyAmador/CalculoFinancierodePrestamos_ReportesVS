using CálculoFinancierodePréstamos.Principal;
using CálculoFinancierodePréstamos.Reportes;
using Entidades;
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

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            Application.Run(new FrmReportes());
            //Application.Run(new Prestamos.Prestamo(new User_Login()));
        }
    }
}
