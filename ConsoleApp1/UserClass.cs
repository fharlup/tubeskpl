using System;
using Utama.Enum;

namespace Utama.Class
{
    public class Guru
    {
        private string namaGuru;
        private int umur;
        private string mpKeahlian;
        private PengerjaanState status;
    }

    public class Murid
    {
        private string namaMurid;
        private int umur;
        private string pendidikan;
        //private PengerjaanState status; 
    }

    public class JadwalPesanan
    {
        private string mataPelajaran;

        // diganti jadi date-time
        // private string tanggalPesanan;

        private Guru guru;
        private Murid murid;
        private StatusPemesanan statusPesanan;
    }
}