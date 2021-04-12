using System;
using System.Text;


namespace AesPasswordSystem
{
    class Base64Solution
    {
        public string Solition()
        {
            byte[] cozulenveri = Convert.FromBase64String(Base64Password.KeyPassword());
            string anametin = Encoding.ASCII.GetString(cozulenveri);
            return anametin;
        }
    }
}
