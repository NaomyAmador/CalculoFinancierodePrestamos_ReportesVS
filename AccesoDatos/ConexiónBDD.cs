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
        private string CadenaConexión = "server=DESKTOP-GBDI4S5\\SQLEXPRESS; database=CalculoFinancierodeReportes; integrated security=true;";

        public SqlConnection ObtenerConexión()   
        {
            SqlConnection Conexión = new SqlConnection(CadenaConexión);
            Conexión.Open();
            return Conexión;
        }
    }
}
