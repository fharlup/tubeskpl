using System.Runtime.InteropServices;

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
