using System.Runtime.InteropServices;
using Utama.Enum;
using Utama.State;

namespace Utama
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("test");
            StateGuru Guru = new StateGuru();
            PengerjaanState status = new PengerjaanState();

            Guru.TambahGuru();
            Console.Write("test");

            Guru.TambahGuru();
            Guru.PesanGuru();
        }
    }
}