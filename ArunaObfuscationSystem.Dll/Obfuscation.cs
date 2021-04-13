using System;
using AesPasswordSystem;
using ArunaObfuscationSystem;

namespace ArunaObfuscationSystem.Dll
{
    public  class  Obfuscation
    {
       static  ArunaObfuscation aruna = new ArunaObfuscation();
        public static string ArunaObfuscation(string text)
        {
            var s = aruna.Obfuscate(text);
            text = s;
            return text;
        }
        public static string ArunaSolution(string text)
        {    
            var c = aruna.Enlighten(text);
            text = c;
            return text;
        }
    }
}
