using System;

using System.Text;


namespace AesPasswordSystem
{
   public static class Base64Password
    {
        public static string KeyPassword()
        {
            string mastertext = Operation.Value();
            byte[] dataarray = Encoding.ASCII.GetBytes(mastertext);
            string passwordtext = Convert.ToBase64String(dataarray);
            string cup = passwordtext.Substring(9, 16);
            passwordtext = cup;
            return passwordtext;
        }
    }
}
