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
        private string CadenaConexión = "server=LAPTOP-PHTCMGVS\\SQLEXPRESS; database=CalculoFinancierodeReportes; integrated security=true;";
        //Servidor Naomy: LAPTOP-9G07MQQC\\SQLEXPRESS//
        //Servidor Arianna: LAPTOP-PHTCMGVS\SQLEXPRESS
        //Servidor Lia: LILY\SQLEXPRESS
        //Servidor Maria: DESKTOP-GBDI4S5\\SQLEXPRESS

        public SqlConnection ObtenerConexión()   
        {
            SqlConnection Conexión = new SqlConnection(CadenaConexión);
            Conexión.Open();
            return Conexión;
        }
    }
}
