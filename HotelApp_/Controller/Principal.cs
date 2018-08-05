using HotelApp_.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp_.Controller
{
    class Principal
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Edwin\\source\\repos\\HotelApp_\\HotelApp_\\Database1.mdf;" + "Integrated Security=True");
        City city;
        Hotel hotel;
        Room room;
        public void OptionsCity()
        {
            city= new City();
            string option = "S";
            
            do
            {
                Console.Clear();
                Console.WriteLine("Escriba 'C' para consultar ciudades");
                Console.WriteLine("Escriba 'A' para añadir una ciudad ");
                Console.WriteLine("Escriba 'M' para modificar una ciudad ");
                Console.WriteLine("Escriba 'E' para eliminar una ciudad ");
                Console.WriteLine("Escriba 'S' para volver al menú principal ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "C":
                        city.ConsultAll();
                        Console.ReadKey();
                        break;
                    case "A":
                        Console.WriteLine("Escriba el nombre de la ciudad a agregar");
                        string namecity = Console.ReadLine();
                        city = new City() { Name=namecity};
                        city.Add();
                        Console.ReadKey();
                        break;
                    case "M":
                        Console.WriteLine("Escriba el Id de la ciudad a modificar");
                        city.ConsultAll();
                        string idaux = Console.ReadLine();
                        int id = Int32.Parse(idaux);
                        Console.WriteLine("Escriba el nuevo nombre de la ciudad");
                        string namecity1 = Console.ReadLine();
                        city = new City() { Id=id, Name = namecity1 };
                        city.Modify();
                        Console.ReadKey();
                        break;
                    case "E":
                        Console.WriteLine("Escriba el Id de la ciudad a eliminar");
                        city.ConsultAll();
                        string idaux1 = Console.ReadLine();
                        int id1 = Int32.Parse(idaux1);
                        city = new City() { Id=id1};
                        city.Delete();
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
        public void OptionsHotel()
        {
            city = new City();
            hotel = new Hotel();
            string option = "S";
            do
            {
                Console.Clear();
                Console.WriteLine("Escriba 'C' para consultar todos los hoteles");
                Console.WriteLine("Escriba 'CC' para consultar un hotel por ciudad");
                Console.WriteLine("Escriba 'A' para añadir un hotel ");
                Console.WriteLine("Escriba 'M' para modificar un hotel ");
                Console.WriteLine("Escriba 'E' para eliminar un hotel ");
                Console.WriteLine("Escriba 'S' para volver al menú principal ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "C":
                        hotel.ConsultAll();
                        int optionConsult = 0;
                        int idhotel = 0;
                        do
                        {
                            Console.WriteLine("Escriba 0 para salir o 1 para consultar,insertar, actualizar y eliminar habitaciones por hotel");
                            string optionconsultaux = Console.ReadLine();
                            optionConsult = Int32.Parse(optionconsultaux);
                            if (optionConsult == 0)
                            {
                                break;
                            }
                            else if (optionConsult == 1)
                            {
                                Console.WriteLine("Escriba el numero que identifica el hotel que desee, para consultar, añadir o eliminar habitaciones");
                                string idhotel4 = Console.ReadLine();
                                idhotel = Int32.Parse(idhotel4);
                                hotel = new Hotel() { Id = idhotel };
                                hotel.OptionsRoom();
                            }
                            else
                            {
                                Console.WriteLine("Opción no válida");

                            }

                        }
                        while (optionConsult != 0);

                        Console.ReadKey();
                        break;
                    case "c":
                        hotel.ConsultAll();
                        int optionConsult1 = 0;
                        int idhotel1=0;
                        do
                        {
                            Console.WriteLine("Escriba 0 para salir o 1 para consultar,insertar, actualizar y eliminar habitaciones por hotel");
                            string optionconsultaux = Console.ReadLine();
                            optionConsult = Int32.Parse(optionconsultaux);
                            if (optionConsult==0)
                            {
                                break;
                            }
                            else if(optionConsult == 1)
                            {
                                Console.WriteLine("Escriba el numero que identifica el hotel que desee, para ver habitaciones");
                                string idhotel4 = Console.ReadLine();
                                idhotel = Int32.Parse(idhotel4);
                                hotel = new Hotel() {Id=idhotel };
                                hotel.OptionsRoom();
                            }
                            else
                            {
                                Console.WriteLine("Opción no válida");

                            }

                        }
                        while (optionConsult !=0);

                        Console.ReadKey();
                        break;
                    case "CC":
                        Console.WriteLine("Escriba el identificador de la ciudad para consultar hoteles");
                        string idCityAux = Console.ReadLine();
                        int idCity = Int32.Parse(idCityAux);
                        hotel = new Hotel() {IdCity=idCity};
                        hotel.ConsultByCity();
                        
                        do
                        {
                            Console.WriteLine("Escriba 0 para salir o 1 para consultar,insertar, actualizar y eliminar habitaciones por hotel");
                            string optionconsultaux = Console.ReadLine();
                            optionConsult = Int32.Parse(optionconsultaux);
                            if (optionConsult == 0)
                            {
                                break;
                            }
                            else if (optionConsult == 1)
                            {
                                Console.WriteLine("Escriba el numero que identifica el hotel que desee, para ver habitaciones");
                                string idhotel4 = Console.ReadLine();
                                idhotel = Int32.Parse(idhotel4);
                                hotel = new Hotel() { Id = idhotel };
                                hotel.OptionsRoom();
                            }
                            else
                            {
                                Console.WriteLine("Opción no válida");

                            }

                        }
                        while (optionConsult != 0);

                        Console.ReadKey();
                        break;
                    case "A":
                        Console.WriteLine("Escriba el nombre del hotel");
                        string name = Console.ReadLine();
                        Console.WriteLine("Escriba la descripcion del hotel");
                        string description = Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo teléfono del hotel");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Escriba la dirección del hotel");
                        string address = Console.ReadLine();
                        Console.WriteLine("Escriba una url de la foto del hotel");
                        string photo = Console.ReadLine();
                        Picture photohotel = new Picture() {url=photo };
                        city.ConsultAll();
                        Console.WriteLine("Escriba el identificador de la ciudad a la que pertenece el hotel");
                        string idCityAux3 = Console.ReadLine();
                        int idCity1 = Int32.Parse(idCityAux3);
                        hotel = new Hotel() { Name = name, Description = description, Phone = phone , Address=address, Photo=photohotel, IdCity=idCity1};
                        hotel.Add();
                        Console.ReadKey();
                        break;
                    case "a":
                        Console.WriteLine("Escriba el nombre del hotel");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Escriba la descripcion del hotel");
                        string description2 = Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo teléfono del hotel");
                        string phone2 = Console.ReadLine();
                        Console.WriteLine("Escriba la dirección del hotel");
                        string address2 = Console.ReadLine();
                        Console.WriteLine("Escriba una url de la foto del hotel");
                        string photo2 = Console.ReadLine();
                        Picture photohotel2 = new Picture() { url = photo2 };
                        city.ConsultAll();
                        Console.WriteLine("Escriba el identificador de la ciudad a la que pertenece el hotel");
                        string idCityAux2 = Console.ReadLine();
                        int idCity2 = Int32.Parse(idCityAux2);
                        hotel = new Hotel() { Name = name2, Description = description2, Phone = phone2, Address = address2, Photo = photohotel2, IdCity = idCity2 };
                        hotel.Add();
                        Console.ReadKey();
                        break;
                    case "M":
                        hotel.ConsultAll();
                        Console.WriteLine("Escriba el Id del hotel a modificar");
                        string idaux = Console.ReadLine();
                        int id = Int32.Parse(idaux);
                        Console.WriteLine("Escriba el nuevo nombre del hotel");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva descripcion hotel");
                        string description1 = Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo teléfono del hotel");
                        string phone1 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva dirección del hotel");
                        string address1 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva url de la foto del hotel");
                        string photoaux1 = Console.ReadLine();
                        Picture photo1 = new Picture() {url=photoaux1 };
                        city.ConsultAll();
                        Console.WriteLine("Escriba el identificador de la ciudad a la que pertenece el hotel");
                        string idCityAux1= Console.ReadLine();
                        int idCity3 = Int32.Parse(idCityAux1);
                        hotel = new Hotel() {Id=id, Name=name1, Description=description1, Phone=phone1, Address= address1, Photo=photo1, IdCity= idCity3 };

                        break;
                    case "m":
                        hotel.ConsultAll();
                        Console.WriteLine("Escriba el Id del hotel a modificar");
                        string idaux3 = Console.ReadLine();
                        int id3 = Int32.Parse(idaux3);
                        Console.WriteLine("Escriba el nuevo nombre del hotel");
                        string name3 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva descripcion hotel");
                        string description3 = Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo teléfono del hotel");
                        string phone3 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva dirección del hotel");
                        string address3 = Console.ReadLine();
                        Console.WriteLine("Escriba la nueva url de la foto del hotel");
                        string photoaux3 = Console.ReadLine();
                        Picture photo3 = new Picture() { url = photoaux3 };
                        city.ConsultAll();
                        Console.WriteLine("Escriba el identificador de la ciudad a la que pertenece el hotel");
                        string idCityAux4 = Console.ReadLine();
                        int idCity4 = Int32.Parse(idCityAux4);
                        hotel = new Hotel() { Id = id3, Name = name3, Description = description3, Phone = phone3, Address = address3, Photo = photo3, IdCity = idCity4 };

                        break;
                    case "E":
                        hotel.ConsultAll();
                        Console.WriteLine("Escriba el Id del hotel a eliminar");
                        string idhotelaux = Console.ReadLine();
                        int idhotel2 = Int32.Parse(idhotelaux);
                        hotel = new Hotel() { Id=idhotel2};
                        hotel.Delete();
                        break;
                    case "e":
                        hotel.ConsultAll();
                        Console.WriteLine("Escriba el Id del hotel a eliminar");
                        string idhotelaux1 = Console.ReadLine();
                        int idhotel5 = Int32.Parse(idhotelaux1);
                        hotel = new Hotel() { Id = idhotel5 };
                        hotel.Delete();
                        break;
                }
                    

            }
            while (option != "S" && option != "s");

            Console.ReadKey();
        }
        public void SeparateUrl()
        {
            Console.WriteLine("Ingrese la url a separar");
            string url = Console.ReadLine();
            string[] urlArr = null;
            int count = 0;
            char[] splitchar = { ',' };
            urlArr = url.Split(splitchar);
            for (count = 0; count <= urlArr.Length - 1; count++)
            {
                Console.WriteLine(urlArr[count]);
            }
        }


    }
   
}
