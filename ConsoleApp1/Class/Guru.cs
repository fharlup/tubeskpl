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

        public Guru(string username, string password, string nama, int umur, string mpKeahlian) : base(username,password,nama,umur)
        {
            this.mpKeahlian = mpKeahlian;
            status = 0;
        }

        public Jadwal BuatJadwal()
        {
            Jadwal jadwal = new Jadwal();
            // implementasi guru bikin jadwal sekalian menu nya
            return jadwal;
        }
    }
}
