using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace fawuhfkawjhjkf
{
    public partial class App : Form
    {

        StreamWriter SW;
        Random rnd = new Random();

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {

        }

        void checkRadioButton(object sender, EventArgs e)
        {
            if(numbers.Checked)
            {
                numbersGroup.Enabled = true;
                textGroup.Enabled = false;
            }
            else
            {
                numbersGroup.Enabled = false;
                textGroup.Enabled = true;
            }

        }

        private void Write_Click(object sender, EventArgs e)
        {

            if ((fileName.Text.Split('.').Last()) == "txt") fileName.Text = fileName.Text.Remove(fileName.Text.Length - 4);

            if (numbers.Checked == true)
            {
                int[] array = new int[(int)numbersTotal.Value];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next((int)numbersMin.Value, (int)numbersMax.Value);
                }

                if (NumberSplitter.Text == "") NumberSplitter.Text = " ";

                using (SW = new StreamWriter($"{fileName.Text}.txt"))
                {
                    if (IsNumberColumn.Checked)
                    {
                        SW.WriteLine(String.Join(NumberSplitter.Text, array));
                    }
                    else
                    {
                    SW.Write(String.Join(NumberSplitter.Text, array));
                    }
                }
            }

        }
    }
}
