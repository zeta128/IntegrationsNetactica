using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp_.Model
{

    class City
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Edwin\\source\\repos\\HotelApp_\\HotelApp_\\Database1.mdf;" + "Integrated Security=True");

        public int Id { get; set; }
        public string Name { get; set; }

        public void ConsultAll()
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblCity", cn);
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

        public void Add()
        {
            
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblCity values('" + Name + "')", cn);

            int ex = cmd1.ExecuteNonQuery();
            if (ex > 0)
            {

                Console.WriteLine(Name + " insertada correctamente", cmd1);
            }
            cn.Close();
        }
        public void Modify()
        {   
            cn.Open();

            SqlCommand uc = new SqlCommand("UPDATE tblCity SET tblCity.Name ='"+Name+ "' WHERE tblCity.Id ='" + Id+"'", cn);
            uc.ExecuteNonQuery();
            SqlCommand sc = new SqlCommand("SELECT * FROM tblCity WHERE Id ='" +Id+ "'", cn);
            using (SqlDataReader selcity = sc.ExecuteReader())
            {
                while (selcity.Read())
                {
                    Console.WriteLine("Ciudad actualizada a " + selcity["Name"].ToString());
                }
            }
            cn.Close();
        }
        public void Delete()
        {
            
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tblCity WHERE Id='"+Id+"'", cn);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Ciudad eliminada");
            cn.Close();
            ConsultAll();   
        }
    }
}
