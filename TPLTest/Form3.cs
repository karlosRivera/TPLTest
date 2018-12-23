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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var count = 0;

            await Task.Run(() =>
            {
                for (var i = 0; i <= 500; i++)
                {
                    count = i;
                    BeginInvoke((Action)(() =>
                    {
                        label1.Text = i.ToString();

                    }));
                   Thread.Sleep(100);
                }
            });

            label1.Text = @"Counter " + count;
            button1.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var count = 0;

            for (var i = 0; i <= 500000000; i++)
            {
                count = i;
                label2.Text = i.ToString();
                await Task.Delay(50);         // do async I/O or Task.Run() here
            }    
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            var count = 0;

            // The Progress<T> constructor captures UI context,
            // so the lambda will be run on the UI thread.
            IProgress<int> progress = new Progress<int>(value =>
            {
                label3.Text = value.ToString();
            });

            await Task.Run(() =>
            {
                for (var i = 0; i <= 30; i++)
                {
                    count = i;
                    progress.Report(i);
                    Thread.Sleep(100);
                }
            });

            //label3.Text = @"Counter " + count;
            button3.Enabled = true;
        }
    }
}
