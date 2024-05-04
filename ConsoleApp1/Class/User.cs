using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utama.Enum;

namespace Utama.Class
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string nama { get; set; }
        public int umur { get; set; }

        public User(string username, string password, string nama, int umur)
        {
            this.username = username;
            this.password = password;
            this.nama = nama;
            this.umur = umur;
        }
    }
}
