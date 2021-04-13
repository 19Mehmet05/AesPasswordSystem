using System;
using AesPasswordSystem;
using ArunaObfuscationSystem;

namespace ArunaObfuscationSystem.Dll
{
    public  class  ArunaObfuscation
    {
       static AesPasswordSystem.ArunaObfuscation aruna = new AesPasswordSystem.ArunaObfuscation();
        public static string Obfuscation(string text)
        {
            var s = aruna.Obfuscate(text);
            text = s;
            return text;
        }
        public static string Enlighten(string text)
        {    
            var c = aruna.Enlighten(text);
            text = c;
            return text;
        }
    }
}
