using System;
using System.Text;
using System.Security.Cryptography;

namespace AesPasswordSystem
{
    public class ArunaObfuscation
    {

        private const string Aes_Server = @"!&+QWSDF!123126+";
        public string Aes_Key = Base64Password.KeyPassword();
        AesCryptoServiceProvider aesProvider = null;
        public ArunaObfuscation()
        {
            aesProvider = new AesCryptoServiceProvider();
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 128;

            aesProvider.IV = Encoding.UTF8.GetBytes(Aes_Server);
            aesProvider.Key = Encoding.UTF8.GetBytes(Aes_Key);
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;
        }

        public string Obfuscate(string text)
        {
            byte[] source = Encoding.Unicode.GetBytes(text);
            using (ICryptoTransform encrypt = aesProvider.CreateEncryptor())
            {
                byte[] hedef = encrypt.TransformFinalBlock(source, 0, source.Length);
                return Convert.ToBase64String(hedef);
            }
        }
        public string Enlighten(string passwordtext)
        {
            byte[] source = Convert.FromBase64String(passwordtext);
            using (ICryptoTransform decryptor = aesProvider.CreateDecryptor())
            {
                byte[] hedef = decryptor.TransformFinalBlock(source, 0, source.Length);
                return Encoding.Unicode.GetString(hedef);
            }
        }
    }
}
