using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp_.Model
{
    class Room
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Edwin\\source\\repos\\HotelApp_\\HotelApp_\\Database1.mdf;" + "Integrated Security=True");
        Type type;
        public int Id { get; set; }
        public Money PriceNight { get; set; }
        public string Description { get; set; }
        public Picture Photo { get; set; }
        public int IdType { get; set; }
        public int IdHotel { get; set; }

        public void ConsultAll()
        {
            cn.Open();
            type = new Type();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblRoom WHERE IdHotel='"+IdHotel+"'", cn);
            using (SqlDataReader rdr = cmd1.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine("Habitación #: " + rdr["Id"].ToString());
                    Console.WriteLine("Precio por noche: " + rdr["PriceNight"].ToString());
                    Console.WriteLine("Descripción: " + rdr["Description"].ToString());
                    Console.WriteLine("Photo: " + rdr["Photo"].ToString());
                    SqlCommand type = new SqlCommand("SELECT * FROM tblType WHERE Id='" + IdType + "'", cn);
                    rdr.Close();
                    using (SqlDataReader rdr1 = type.ExecuteReader())
                    {
                        while (rdr1.Read())
                        {
                            Console.WriteLine("tipo: " + rdr1["Name"].ToString());
                        }
                    }

                           
                    Console.WriteLine("\n");
                }

            }

            cn.Close();
        }
        public void Add()
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblRoom values('" + PriceNight.cantidad + "','"+Description+"','"+Photo.url+"','"+IdType+"','"+IdHotel+"')", cn);

            int ex = cmd1.ExecuteNonQuery();
            if (ex > 0)
            {

                Console.WriteLine("Habitación "+Id+" insertada correctamente", cmd1);
            }
            cn.Close();
        }
        public void Delete()
        {

            cn.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tblRoom WHERE Id='" + Id + "'", cn);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Habitación "+Id+" eliminada");
            cn.Close();
            ConsultAll();
        }

    }
}
