using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TPLTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => GetAllTheCats());
            await Task.Run(() => GetAllTheFood());
        }

        public string GetAllTheCats()
        {
            // Do stuff, like hit the Db, spin around, dance, jump, etc...
            // It all takes some time.
            Thread.Sleep(2000);
            return "";
        }

        public string GetAllTheFood()
        {
            // Do more stuff, like hit the Db, nom nom noms...
            // It all takes some time.
            Thread.Sleep(2000);

            return "";
        }

     
    }
}
