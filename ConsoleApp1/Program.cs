using System.Net.Http.Json;
using Utama.Class;

namespace Utama
{
    class Program
    {
        private static bool isLoggedIn = false;
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7231/"); // portnya sesuain

            Guru guru;
            Murid murid;

            HttpResponseMessage responseLogin;


            bool exit = false;
            string option,choice;
            Menu menu = new Menu();
            option = menu.AuthPage();
            while (!exit)
            {
                switch (option)
                {
                    case "1":
                        option = menu.RolePage();
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        if (option == "1")
                        {
                            Guru loginGuru = new Guru(username, password,"",0,"");
                            responseLogin = await httpClient.PostAsJsonAsync("api/Guru/login", loginGuru);
                            if (responseLogin.IsSuccessStatusCode)
                            {
                                string responseBodyLogin = await responseLogin.Content.ReadAsStringAsync();
                                isLoggedIn = true;
                                Console.WriteLine("Login berhasil");

                            }
                            else if (responseLogin.StatusCode == System.Net.HttpStatusCode.BadRequest || responseLogin.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Console.WriteLine("Username / Password tidak sesuai");
                            }
                            else
                            {
                                Console.WriteLine("Failed to login: " + responseLogin.StatusCode);
                            }

                        }
                        else if (option == "2")
                        {
                            // login murid
                        }
                        
                        break;
                    case "2":
                        option = menu.RolePage();
                        Console.Write("Username: ");
                        username = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        Console.Write("Nama: ");
                        string nama = Console.ReadLine();
                        Console.Write("Umur: ");
                        int umur = Convert.ToInt16(Console.ReadLine());
                        if (option == "1")
                        {
                            Console.Write("Pelajaran keahlian: ");
                            string mpKeahlian = Console.ReadLine();
                            Guru newGuru = new Guru(username, password, nama, umur, mpKeahlian);
                            HttpResponseMessage responseRegister = await httpClient.PostAsJsonAsync("api/Guru/register", newGuru);
                            if (responseRegister.IsSuccessStatusCode)
                            {
                                string responseBodyRegister = await responseRegister.Content.ReadAsStringAsync();
                                Console.WriteLine("Response Register:");
                                Console.WriteLine(responseBodyRegister);
                            }
                            else if (responseRegister.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                string errorMessage = await responseRegister.Content.ReadAsStringAsync();
                                Console.WriteLine("Failed to register: " + errorMessage);
                            }
                            else
                            {
                                string errorMessage = await responseRegister.Content.ReadAsStringAsync();
                                if (errorMessage.Contains("Username sudah terdaftar"))
                                {
                                    Console.WriteLine("Username sudah terdaftar");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to register: " + responseRegister.StatusCode);
                                }
                            }
                            break;
                        }
                        else if (option == "2")
                        {
                            // register murid
                        }
                        break;
                }
                option = menu.AuthPage();
            }


            //StateGuru Guru = new StateGuru();
            //PengerjaanState status = new PengerjaanState();

            //Guru.TambahGuru();
            //Console.Write("test");

            //Guru.TambahGuru();
            //Guru.PesanGuru();
        }
    }
}