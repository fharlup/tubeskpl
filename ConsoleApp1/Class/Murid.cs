using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utama.Enum;

namespace Utama.Class
{
    public class Murid
    {
        public string namaMurid { get; set; }
        public int umur { get; set; }
        public string pendidikan { get; set; }
        //public PengerjaanState status { get; set; }

        public void CariGuru()
        {
            // cari guru berdasarkan mata pelajaran
        }

        public void SewaGuru(Jadwal jadwal)
        {
            // panggil fungsi pembayaran abistu ganti state SudahDiPesan
        }
    }
}
