using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelApp_.Model;
using HotelApp_.Controller;

namespace HotelApp_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string option = "0";
            
             do
             {
                Console.Clear();
                Console.WriteLine("Integraciones");
                Console.WriteLine("Digite el número de la opción que desee");
                Console.WriteLine("0 Para salir");
                Console.WriteLine("1 Para agregar modificar o eliminar ciudades");
                Console.WriteLine("2 Para agregar modificar o eliminar hoteles y sus habitaciones");
                Console.WriteLine("3 Para Separar una url por ,");

                option = Console.ReadLine();
                Principal pr = new Principal();
                 switch (option)
                 {
                     case "0":
                         Console.ReadKey();
                         break;
                     case "1":
                        pr.OptionsCity();
                        Console.ReadKey();
                        break;
                     case "2":
                        pr.OptionsHotel();
                        Console.ReadKey();
                        break;
                    case "3":
                        pr.SeparateUrl();
                        Console.ReadKey();
                        break;
                    default:
                         Console.WriteLine("Opción no válida");
                         break;
                 }
             }
             while (option != "0");

             Console.ReadKey();
            
             /*string username, password;
             Console.WriteLine("Enter Username and password");
             username = Console.ReadLine();
             password = Console.ReadLine();
             SqlCommand cmd = new SqlCommand("insert into tblLogin values('"+username+"','"+password+"')", cn);
             int i= cmd.ExecuteNonQuery();
             if (i>0)
             {
                 Console.WriteLine("Insertion succesfull");
             }
             cn.Close();*/
        }
        
    }
}
