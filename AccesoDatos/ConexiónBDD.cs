using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ConexiónBDD
    {
        private string CadenaConexión = "server=LAPTOP-9G07MQQC\\SQLEXPRESS; database=CalculoFinancierodeReportes;; integrated security=true;";

        public SqlConnection ObtenerConexión()
        {
            SqlConnection Conexión = new SqlConnection(CadenaConexión);
            Conexión.Open();
            return Conexión;
        }
    }
}
