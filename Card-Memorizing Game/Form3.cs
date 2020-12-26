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
    public partial class Form3 : Form
    {
        string Result;
        public Form3(string result)
        {
            InitializeComponent();
            Result = result; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SetResultLabel();
        }

        private void SetResultLabel()
        {
            if(Result == "winner")
                GameResult.ForeColor = System.Drawing.Color.Green;
            else
                GameResult.ForeColor = System.Drawing.Color.Red;
            GameResult.Font = new Font("murtuza", 20);
            GameResult.Text = Result;
        }

        private void GoToMenu_Click(object sender, EventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).Reset();
            this.Close();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            var F = System.Windows.Forms.Application.OpenForms["Form1"] as Form1;
            F.Reset();
            switch(F.mode){
                case "Easy":
                    F.Easy.PerformClick();
                    break;
                case "Meduim":
                    F.Meduim.PerformClick();
                    break;
                case "Hard":
                    F.Hard.PerformClick();
                    break;
            }
            this.Close();
        }
    }
}
