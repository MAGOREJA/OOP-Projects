using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.Utilities
{
    class Utility
    {
        private static string ConnectionString = "Data Source=DESKTOP-KHTABAF\\SQLEXPRESS;Initial Catalog=LibraryMS;Integrated Security=True";

        private SqlConnection con;
        private static Utility instance;
        private Utility()
        {
            con = new SqlConnection(ConnectionString);

        }
        public static Utility GetInstance()
        {

            if (instance == null)
            {
                instance = new Utility();
            }
            return instance;
        }
        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public SqlConnection GetConnection()
        {
            OpenConnection();
            return con;
        }
    }
}
