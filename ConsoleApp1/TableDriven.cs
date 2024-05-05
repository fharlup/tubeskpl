using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TableDriven 
    {
        public enum MataPelajaran
        {
            Matematika,
            Fisika,
            Kimia,
            Biologi,
            BahasaIndonesia,
            BahasaInggris,
            Sains,
            IPA,
            IPS
        }
        public static readonly Dictionary<string, MataPelajaran> matpel = new Dictionary<string, MataPelajaran>
        {
            {"Matematika", MataPelajaran.Matematika},
            {"Fisika",MataPelajaran.Fisika},
            {"Kimia" ,MataPelajaran.Kimia},
            {"Biologi",MataPelajaran.Biologi},
            {"Bahasa Indonesia", MataPelajaran.BahasaIndonesia},
            {"Bahasa Inggris", MataPelajaran.BahasaInggris},
            {"Sains", MataPelajaran.Sains},
            {"IPA", MataPelajaran.IPA},
            {"IPS", MataPelajaran.IPS},
        };
        public static MataPelajaran GetMatpel (String Matapelajaran)
        {
            return matpel [Matapelajaran];
        }
    }
   
}
