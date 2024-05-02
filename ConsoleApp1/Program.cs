using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.WriteLine("test");
        StateGuru Guru = new StateGuru();

        Guru.TambahGuru();
        Console.Write("test");

        Guru.TambahGuru();
        Guru.PesanGuru();
    }
}
