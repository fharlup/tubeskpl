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

        public Guru(string namaGuru, int umur, string mpKeahlian, PengerjaanState status) {
            this.namaGuru = namaGuru;
            this.umur = umur;
            this.mpKeahlian = mpKeahlian;
            this.status = status;
        }
    }

    public class Murid
    {
        public string namaMurid { get; set; }
        public int umur { get; set; }
        public string pendidikan { get; set; }
        //public PengerjaanState status; 
    }

    public class JadwalPesanan
    {
        public string mataPelajaran { get; set; }

        // diganti jadi date-time
        // public string tanggalPesanan;

        public Guru guru { get; set; }
        public Murid murid { get; set; }
        public StatusPemesanan statusPesanan { get; set; }
    }
}