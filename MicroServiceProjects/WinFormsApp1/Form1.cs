using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btn_Click(object sender, EventArgs e)
        {

            openFileDialog1.Multiselect = false;
            Hashtable hs = new Hashtable();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            openFileDialog1.Filter = "Zip File|*.zip";
            openFileDialog1.Title = "Please select the Oracle OPatch installer package";
            openFileDialog1.ShowDialog();
            var fileNames = openFileDialog1.FileName;
            Console.WriteLine(fileNames);
        }

        private void btn_Task_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //Interlocked.Increment(ref count);
            for (int i = 0; i < 20; i++)
            {
                int k = i;
                Task.Run(() =>
                {
                    Console.WriteLine($"i is {i}  k is {k}");
                });
            }
        }
    }
}
