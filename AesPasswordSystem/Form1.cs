using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AesPasswordSystem
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArunaObfuscation aruna = new ArunaObfuscation();
            var s = aruna.Obfuscate("Okancan Coşar");
            var c = aruna.Enlighten(s);
        }
    }
}
