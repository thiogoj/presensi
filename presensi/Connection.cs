using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presensi
{
    internal class Connection
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source= LAPTOP-2J88KB4O\\SQLEXPRESS01; initial catalog= presensi; integrated security= true;";
            return Conn;
        }
    }
}
