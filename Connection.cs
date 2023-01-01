using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLNS
{
    class Connection
    {
       /* private static String ConnectionString = @"Data Source=MSI\VANH;Initial Catalog=BTL;Integrated Security=True";*/
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //dung de select
        public static DataTable ExecuteDataTable_SQL(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter dad = new SqlDataAdapter(sql, con))
                {
                    using (DataSet dst = new DataSet())
                    {
                        dad.Fill(dst);
                        return dst.Tables[0];
                    }
                }
            }
        }
        //dung de insert
        public static void ExecuteNonData(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                    com.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }
    }
}
