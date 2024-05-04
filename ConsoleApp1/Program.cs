using System.Net.Http.Json;

namespace Utama
{
    class Program
    {
        private static bool isLoggedIn = false;
        static async Task Main()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7231/"); // portnya sesuain

            bool exit = false;
            string option;
            Menu menu = new Menu();

            // bikin menu


            //StateGuru Guru = new StateGuru();
            //PengerjaanState status = new PengerjaanState();

            //Guru.TambahGuru();
            //Console.Write("test");

            //Guru.TambahGuru();
            //Guru.PesanGuru();
        }
    }
}