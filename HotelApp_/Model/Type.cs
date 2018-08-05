using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp_.Model
{
    class Type
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Edwin\\source\\repos\\HotelApp_\\HotelApp_\\Database1.mdf;" + "Integrated Security=True");

        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public void ConsultAll()
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblType", cn);
            using (SqlDataReader rdr = cmd1.ExecuteReader())
            {
                while (rdr.Read())
                {

                    Console.WriteLine(rdr["Id"].ToString());
                    Console.WriteLine(rdr["Name"].ToString());
                    Console.WriteLine("\n");
                }
            }
            int ex = cmd1.ExecuteNonQuery();
            cn.Close();
        }
    }
}
