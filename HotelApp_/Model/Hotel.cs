using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp_.Model
{
    class Hotel
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Edwin\\source\\repos\\HotelApp_\\HotelApp_\\Database1.mdf;" + "Integrated Security=True");
        Room room;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Picture Photo { get; set; }
        public int IdCity { get; set; }


        public string CitybyId(int id)
        {
            cn.Close();
            cn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM tblCity WHERE Id ='"+id+"'", cn);
            using (SqlDataReader selcity = sc.ExecuteReader())
            {
                while (selcity.Read())
                {
                    return selcity["Name"].ToString();
                }
            }
            
            return null;
            
        }
        public void ConsultAll()
        {
            cn.Open();
            SqlCommand query_hotel = new SqlCommand("SELECT * FROM tblHotel", cn);
            SqlDataReader reader_hotel = query_hotel.ExecuteReader();
            
                while (reader_hotel.Read())
                {
                    Console.WriteLine("Id: " + reader_hotel["Id"].ToString());
                    Console.WriteLine("Nombre: " + reader_hotel["Name"].ToString());
                    Console.WriteLine("Descripción: " + reader_hotel["Description"].ToString());
                    Console.WriteLine("Teléfono: " + reader_hotel["Phone"].ToString());
                    Console.WriteLine("Dirección: " + reader_hotel["Address"].ToString());
                    Console.WriteLine("Url foto: " + reader_hotel["Photo"].ToString());
                    int idcity = Int32.Parse(reader_hotel["IdCity"].ToString());
                     //reader_hotel.Close();
                    //Console.WriteLine("Ciudad: " + CitybyId(idcity));

            }
            cn.Close();
        }
        public void OptionsRoom()
        {
            Type type = new Type();
            
            string option = "S";

            do
            {
                Console.Clear();
                Console.WriteLine("Escriba 'C' para consultar habitaciones");
                Console.WriteLine("Escriba 'A' para añadir una habitación");
                Console.WriteLine("Escriba 'E' para eliminar una habitación ");
                Console.WriteLine("Escriba 'S' para volver al menú principal ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "C":
                        room = new Room() { IdHotel=Id };
                        room.ConsultAll();
                        Console.ReadKey();
                        break;
                    case "A":
                        Console.WriteLine("Escriba el precio por noche para la habitación");
                        string precioaux = Console.ReadLine();
                        int precio = Int32.Parse(precioaux);
                        Money money = new Money() {cantidad=precio };
                        Console.WriteLine("Escriba la descripción de la habitación");
                        string descripcion = Console.ReadLine();
                        Console.WriteLine("Escriba la url de la foto para la habitación");
                        string url = Console.ReadLine();
                        Picture photo = new Picture() { url=url};
                        type.ConsultAll();
                        Console.WriteLine("Escriba el numero que identifica al tipo de habitación a la que corresponde");
                        string idtypeaux = Console.ReadLine();
                        int idtype = Int32.Parse(idtypeaux);
                        room = new Room() { PriceNight=money, Description=descripcion,Photo=photo,IdType=idtype,IdHotel=Id};
                        room.Add();
                        Console.ReadKey();
                        break;
                    case "E":
                        Console.WriteLine("Escriba el Id de la habitación a eliminar");
                        string idHabaux = Console.ReadLine();
                        int idHab = Int32.Parse(idHabaux);
                        room = new Room() { Id= idHab,IdHotel=Id};
                        room.Delete();
                        Console.ReadKey();
                        break;
                    case "S":
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            while (option != "S");

            Console.ReadKey();
        }
        public void ConsultByCity()
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblHotel WHERE IdCity='"+IdCity+"'", cn);
            using (SqlDataReader rdr = cmd1.ExecuteReader())
            {
                while (rdr.Read())
                {

                    Console.WriteLine("Id: " + rdr["Id"].ToString());
                    Console.WriteLine("Nombre: " + rdr["Name"].ToString());
                    Console.WriteLine("Descripción: " + rdr["Description"].ToString());
                    Console.WriteLine("Teléfono: " + rdr["Phone"].ToString());
                    Console.WriteLine("Dirección: " + rdr["Address"].ToString());
                    Console.WriteLine("Url foto: " + rdr["Photo"].ToString());
                    SqlCommand sc = new SqlCommand("SELECT * FROM tblCity WHERE Id ='" + rdr["IdCity"] + "'", cn);
                    using (SqlDataReader selcity = sc.ExecuteReader())
                    {
                        while (selcity.Read())
                        {
                            Console.WriteLine("Ciudad: " + selcity["Name"].ToString());
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
            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblHotel values('" + Name + "','" + Description + "','" + Phone + "','" + Address + "','" + Photo.url + "','" + IdCity + "')", cn);

            int ex = cmd1.ExecuteNonQuery();
            if (ex > 0)
            {

                Console.WriteLine("Hotel "+Name + " insertado correctamente", cmd1);
            }
            cn.Close();
        }
        public void Modify()
        {  
            cn.Open();
            SqlCommand uc = new SqlCommand("UPDATE tblHotel SET Name ='" + Name + "', Description ='" + Description + ", Phone ='" + Phone + "'', Address ='" + Address + "', Photo ='" + Photo + "', IdCity ='" + IdCity + "' WHERE Id ='" + Id + "'", cn);
            uc.ExecuteNonQuery();
            SqlCommand sc = new SqlCommand("SELECT * FROM tblHotel WHERE Id ='" + Id + "'", cn);
            using (SqlDataReader selcity = sc.ExecuteReader())
            {
                while (selcity.Read())
                {
                    Console.WriteLine("Hotel actualizado");
                }
            }
            cn.Close();
        }
        public void Delete()
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tblHotel WHERE Id='" + Id + "'", cn);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Hotel eliminado");
            cn.Close();
            ConsultAll();
        }
    }

}
