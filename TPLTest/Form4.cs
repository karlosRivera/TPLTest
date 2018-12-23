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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var task1 = Task.Run(() => GetAllTheCats());
            var task2 = Task.Run(() => GetAllTheFood());
            var result = await Task.WhenAll(task1, task2);
        }

        /*
        public string GetAllTheCats()
        {
            // Do stuff, like hit the Db, spin around, dance, jump, etc...
            // It all takes some time.
            Thread.Sleep(1000);
            return "cat found";
        }

        public string GetAllTheFood()
        {
            // Do more stuff, like hit the Db, nom nom noms...
            // It all takes some time.
            Thread.Sleep(2000);
            return "food found";
        }
        */

        public async Task<string> GetAllTheCats()
        {
            // Do stuff, like hit the Db, spin around, dance, jump, etc...
            // It all takes some time.
            await Task.Delay(1000);
            return "cat found";
        }

        public async Task<string> GetAllTheFood()
        {
            // Do more stuff, like hit the Db, nom nom noms...
            // It all takes some time.
            await Task.Delay(2000);
            return "food found";
        }
    }
}
