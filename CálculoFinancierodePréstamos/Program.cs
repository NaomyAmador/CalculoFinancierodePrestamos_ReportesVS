
using CálculoFinancierodePréstamos.Prestamos;
using CálculoFinancierodePréstamos.Principal;
using CálculoFinancierodePréstamos.Reportes;
using Entidades;
using CálculoFinancierodePréstamos.Clientes;
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


            //Application.Run(new FrmLogin());
            //Application.Run(new CálculoFinancierodePréstamos.Pagos.frmDatosParaPago());
            //Application.Run(new FrmHistorialPrestamos());
            //Application.Run(new FrmPago(10));
            //Application.Run(new CálculoFinancierodePréstamos.ActualizarClientes.FrmActualizarCliente());
            Application.Run(new FrmReportes());
            //Application.Run(new CálculoFinancierodePréstamos.Clientes.FrmClientes("Admin"));
            //Application.Run(new Prestamos.Prestamo(new User_Login()));


            //Application.Run(new FrmLogin()
            //{

            // });

        }
    }
}
