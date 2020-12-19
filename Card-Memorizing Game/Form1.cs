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
using System.Resources;


namespace Card_Memorizing_Game
{
    public partial class Form1 : Form
    {
        List<PictureBox> PictureBoxes = new List<PictureBox>();
        string[] PicsPaths;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            string temp;
            PicsPaths = Directory.GetFiles(GetSourcesPath());
            temp = PicsPaths[11];
            PicsPaths[11] = PicsPaths[12];
            PicsPaths[12] = temp;
        }


        private void ModeSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Easy":
                    ModeMenu.Hide();
                    BoxesMaker(12);
                    InfoMssg("you have 10 seconds to look at the picture!, you have to match the whole pics within 3 mins");
                    break;
                case "Meduim":
                    ModeMenu.Hide();
                    BoxesMaker(12);
                    InfoMssg("you have 10 seconds to look at the picture!, you have to match the whole pics within 3 mins");
                    break;
                case "Hard":
                    ModeMenu.Hide();
                    BoxesMaker(20);
                    InfoMssg("you have 10 seconds to look at the picture!, you have to match the whole pics within 3 mins");
                    break;
            }
        }


        private void InfoMssg(string mssg)
        {
            Form2 info = new Form2(mssg);
            info.Show();
        }



        private void BoxesMaker(int BoxesNum)
        {
            Random rnd = new Random();
            for(int i = 0; i < BoxesNum; i++)
            {
                PictureBoxes.Add(new PictureBox());
                PictureBoxes[i].Image = Image.FromFile(PicsPaths[12]);
            }

            this.PictureBoxes[0].Size = new System.Drawing.Size(100, 100);
            this.PictureBoxes[0].SizeMode = PictureBoxSizeMode.Zoom;
            this.PictureBoxes[0].Location = new Point(200, 200);
            this.Controls.Add(PictureBoxes[0]);
        }

        private string GetSourcesPath()
        {
            string str = System.IO.Directory.GetCurrentDirectory();
            int lastIndex = str.LastIndexOf("bin");
            string beginString = str.Substring(0, lastIndex);
            string result = beginString + "Resources";
            for (int i = 0; i < result.Length; i++)
                if (result[i] == '\\' && result[i - 1] != '\\')
                    result = result.Insert(i, "\\");
            return result;
        }

        public void Reset()
        {
            ModeMenu.Show();
        }

    }
}
