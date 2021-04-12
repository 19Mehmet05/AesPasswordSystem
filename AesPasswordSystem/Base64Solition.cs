using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AesPasswordSystem
{
    class Base64Solition
    {
        public string Solition()
        {
            byte[] cozulenveri = Convert.FromBase64String(Base64Password.KeyPassword());
            string anametin = ASCIIEncoding.ASCII.GetString(cozulenveri);
            return anametin;
        }
    }
}
