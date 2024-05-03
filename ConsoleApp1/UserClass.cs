using System;
using Utama.Enum;

namespace Utama.Class
{
    public class Guru
    {
        public string namaGuru { get; set; }
        public int umur { get; set; }
        public string mpKeahlian { get; set; }
        public PengerjaanState status { get; set; }
    }

    public class Murid
    {
        public string namaMurid { get; set; }
        public int umur { get; set; }
        public string pendidikan { get; set; }
        //public PengerjaanState status { get; set; }
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