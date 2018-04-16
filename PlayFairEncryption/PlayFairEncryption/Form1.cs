using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PlayFairEncryption
{
    public partial class Form1 : Form
    {
        char[] message;
        OpenFileDialog ofd;
        [DllImport("PlayfairAssembly.dll")]
        private static extern void FillPlayfair([In]char[] src, int sz);
        [DllImport("PlayfairAssembly.dll")]
        private static extern void Encrypt([In]char[] src, int sz,[Out]char[] target);
        [DllImport("PlayfairAssembly.dll")]
        private static extern void Decrypt([In]char[] src, int sz, [Out]char[] target);
        [DllImport("PlayfairAssembly.dll")]
        private static extern void WriteToAFile([In]char[] filename,[In]char[] src, int sz);
        [DllImport("PlayfairAssembly.dll")]
        private static extern void ReadFromAFile([In]char[] filename, [Out]char[] src);
        char[] path = @"C:\Users\user\Documents\visual studio 2012\Projects\PlayFairEncryption\PlayFairEncryption\bin\Debug\encdec.txt".ToCharArray();
        private void clear(char[] carray)
        {
            for (int i = 0; i < carray.Length; i++)
                carray[i] = '\0';
        }
        public Form1()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
            message = new char[1000];
        }

        private void keywordbtn_Click(object sender, EventArgs e)
        {
            if (keywordtxt.Text == "")
                return;
            
            FillPlayfair(keywordtxt.Text.ToCharArray(), keywordtxt.Text.Length);
            MessageBox.Show("Keyword has been entered");
        }

        private void cipherbtn_Click(object sender, EventArgs e)
        {
            clear(message);
            if (cipherbtn.Text == "Encrypt")
            { 
                    Encrypt(ciphersrctxt.Text.ToCharArray(), ciphersrctxt.Text.Length, message);
            }
            else
            {
                Decrypt(ciphersrctxt.Text.ToCharArray(), ciphersrctxt.Text.Length, message);
            }
            resulttxt.Text = new string(message);
            if (writechk.Checked)
                WriteToAFile(path, message, resulttxt.Text.Length);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                cipherbtn.Text = "Encrypt";
            else
                cipherbtn.Text = "Decrypt";
        }

        private void readbtn_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            string pathread = ofd.FileName;
            clear(message);
            ReadFromAFile(pathread.ToCharArray(), message);
            ciphersrctxt.Text = new string(message);
            return;
        }

    }
}
