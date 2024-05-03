using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.WriteLine("test");
        StateGuru Guru = new StateGuru();

        Guru.TambahGuru(2);
        Console.Write("test");

        Guru.TambahGuru(2);
        Guru.PesanGuru();
    }
}
