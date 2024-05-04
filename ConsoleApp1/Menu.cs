using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utama
{
    public class Menu
    {
        public void Header()
        {

        }

        public String AuthPage()
        {
            Console.WriteLine("Login atau Register");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            Console.Write("Pilih: ");
            return Console.ReadLine();
        }
        public String RolePage()
        {
            Console.WriteLine("Pilih Guru atau Murid");
            Console.WriteLine("1.Murid");
            Console.WriteLine("2.Guru");
            Console.WriteLine("0. Exit");
            Console.Write("Pilih: ");
            return Console.ReadLine();
        }

        public String MuridHomePage()
        {
            Console.WriteLine("1. Sewa Guru"); // search jadwal kosong yang dibuat guru dari mata pelajaran
            Console.WriteLine("2. Lihat Jadwal"); // lihat jadwal
            Console.WriteLine("0. Logout");
            Console.Write("Pilih: ");
            return Console.ReadLine();
        }

        public String GuruHomePage()
        {
            Console.WriteLine("1. Buat Jadwal");
            Console.WriteLine("2. Lihat Jadwal");
            Console.WriteLine("0. Logout");
            Console.Write("Pilih: ");
            return Console.ReadLine();
        }
    }
}
