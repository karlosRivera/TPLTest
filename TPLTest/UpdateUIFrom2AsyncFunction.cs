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
    public partial class UpdateUIFrom2AsyncFunction : Form
    {
        public UpdateUIFrom2AsyncFunction()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var task1 = Task.Run(() => UpdateLabel1());
            var task2 = Task.Run(() => UpdateLabel2());
            var result = await Task.WhenAll(task1, task2);
        }

        public async Task<bool> UpdateLabel1()
        {
            await Task.Run(() =>
            {
                for (var i = 0; i <= 200; i++)
                {
                    BeginInvoke((Action)(() =>
                    {
                        label1.Text = i.ToString();

                    }));

                    Thread.Sleep(100);
                }
            });

            return true;
        }

        public async Task<bool> UpdateLabel2()
        {
            await Task.Run(() =>
            {
                for (var i = 0; i <= 100; i++)
                {
                    BeginInvoke((Action)(() =>
                    {
                        label2.Text = i.ToString();

                    }));

                    Thread.Sleep(100);
                }
            });
            return true;
        }
    }
}
