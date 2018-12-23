using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLTest
{
    public partial class LongRunningOperationForm : Form
    {
        public LongRunningOperationForm()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            Task<int> result = MyMethodAsync();
            MessageBox.Show(result.ToString());
            int x = 0;
        }

        public async Task<int> MyMethodAsync()
        {
            Task<int> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            //Console.WriteLine(result);
            return result;
        }

        public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            await Task.Delay(2000); // 1 second delay
            return 1;
        }
    }
}
