using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utama.Enum;

namespace Utama.Class
{
    public class Guru : User
    {
        public string mpKeahlian { get; set; }
        public PengerjaanState status { get; set; }

        // bikin konstruktor buat akun guru

        public Jadwal BuatJadwal()
        {
            Jadwal jadwal = new Jadwal();
            // implementasi guru bikin jadwal sekalian menu nya
            return jadwal;
        }
    }
}
