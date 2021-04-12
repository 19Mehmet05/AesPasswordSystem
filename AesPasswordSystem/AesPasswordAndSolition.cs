using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AesPasswordSystem
{
    public class AesPasswordAndSolition
    {

        private const string Aes_Server = @"!&+QWSDF!123126+";
        public string Aes_Key = Base64Password.KeyPassword();
        AesCryptoServiceProvider aesProvider = null;
        public AesPasswordAndSolition()
        {
            aesProvider = new AesCryptoServiceProvider();
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 128;

            aesProvider.IV = Encoding.UTF8.GetBytes(Aes_Server);
            aesProvider.Key = Encoding.UTF8.GetBytes(Aes_Key);
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;
        }

        public string AesSifrele(string text)
        {
            byte[] source = Encoding.Unicode.GetBytes(text);
            using (ICryptoTransform encrypt = aesProvider.CreateEncryptor())
            {
                byte[] hedef = encrypt.TransformFinalBlock(source, 0, source.Length);
                return Convert.ToBase64String(hedef);
            }
        }
        public string AesSifre_Coz(string passwordtext)
        {
            byte[] source = System.Convert.FromBase64String(passwordtext);
            using (ICryptoTransform decryptor = aesProvider.CreateDecryptor())
            {
                byte[] hedef = decryptor.TransformFinalBlock(source, 0, source.Length);
                return Encoding.Unicode.GetString(hedef);
            }
        }
    }
}
