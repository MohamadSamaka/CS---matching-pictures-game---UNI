using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Card_Memorizing_Game
{
    public partial class Form2 : Form
    {
        string mssg;
        public Form2(string label)
        {
            mssg = label;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetLabel(mssg);
        }


        private void Continue(object sender, EventArgs e)
        {
            this.Close();
        }



        private void GoBack(object sender, EventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).Reset();
            this.Close();
        }


        private void SetLabel(string str)
        {
            label1.Text = str;
        }

    }
}
