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
using System.Threading;


namespace Card_Memorizing_Game
{
    public partial class Form1 : Form
    {
        List<PictureBox> PictureBoxesFace = new List<PictureBox>();
        List<PictureBox> PictureBoxesCover = new List<PictureBox>();
        List<int> BoxPairs = new List<int>();
        Panel pan;
        Label label, label2;
        Button StartStopButton;
        int WindowHighInGame;
        int WindowWidthInGame;
        int Tmins, Tsecs, TTmins, TTsecs,wait, Swait, TPreGame;
        string[] PicsPaths;
        public string mode;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            string temp;
            PicsPaths = Directory.GetFiles(GetSourcesPath());
            temp = PicsPaths[17];
            PicsPaths[17] = PicsPaths[18];
            PicsPaths[18] = temp;
            timer3.Tick += new EventHandler(CheckIfWonAfterMove);
            timer1.Tick += new EventHandler(CheckIfWonAfterMove);
        }


        private void CheckIfWonAfterMove(object sender, EventArgs e)
        {
            bool Won = true;
            foreach (PictureBox box in PictureBoxesFace)
                if (box.Visible == false)
                {
                    Won = false;
                    break;
                }
            if (Won)
            {
                timer1.Stop();
                timer3.Stop();
                GameResult("winner");
            }
            else if (Tmins == 0 && Tsecs == 0)
            {
                Thread.Sleep(500);
                timer1.Stop();
                timer3.Stop();
                GameResult("lost");
            }
        }


        private void GameResult(string r)
        {
            string result = r;
            Form Result = new Form3(result);
            pan.Enabled = false;
            foreach (PictureBox box in PictureBoxesCover)
                box.Enabled = false;
            Result.Show();
        }


        private void ModeSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Easy":
                    ModeMenu.Hide();
                    WindowHighInGame = 4 * 130 + 5 * 20;
                    WindowWidthInGame = 4 * 110 + 4 * 20 + 200;
                    this.Size = new Size(WindowWidthInGame, WindowHighInGame);
                    AddPanelAndItsItems("3:00");
                    mode = "Easy";
                    Tmins = TTmins = 3;
                    Tsecs = TTsecs = 0;
                    wait = Swait = 1;
                    TPreGame = 10;
                    BoxesMaker(16);
                    BoxesSwaper(16);
                    BoxesOrganizer();
                    InfoMssg("you have 10 seconds to look at the picture!, you have to match the whole pics within 3 mins");
                    break;
                case "Meduim":
                    ModeMenu.Hide();
                    WindowHighInGame = 4 * 130 + 5 * 20;
                    WindowWidthInGame = 4 * 110 + 4 * 20 + 200;
                    this.Size = new Size(WindowWidthInGame, WindowHighInGame);
                    AddPanelAndItsItems("2:00");
                    mode = "Meduim";
                    Tmins = TTmins = 2;
                    Tsecs = TTsecs = 0;
                    wait = Swait = 1;
                    TPreGame = 5;
                    BoxesMaker(16);
                    BoxesSwaper(16);
                    BoxesOrganizer();
                    InfoMssg("you have 5 seconds to look at the picture!, you have to match the whole pics within 2 mins");
                    break;
                case "Hard":
                    ModeMenu.Hide();
                    WindowHighInGame = 4 * 130 + 5 * 20;
                    WindowWidthInGame = 8 * 110 + 8 * 20 + 200;
                    this.Size = new Size(WindowWidthInGame, WindowHighInGame);
                    this.Location = new Point(50, 50);
                    AddPanelAndItsItems("1:30");
                    mode = "Hard";
                    Tmins = TTmins = 1;
                    Tsecs = TTsecs = 30;
                    wait = Swait = 1;
                    TPreGame = 3;
                    BoxesMaker(32);
                    BoxesSwaper(32);
                    BoxesOrganizer();
                    InfoMssg("you have 10 seconds to look at the picture!, you have to match the whole pics within 3 mins");
                    break;
            }
        }


        private void AddPanelAndItsItems(string time)
        {
            pan = new Panel();
            label = new Label();
            label2 = new Label();
            StartStopButton = new Button();
            pan.Location = new Point(WindowWidthInGame - 200, 0);
            pan.Size = new Size(185, WindowHighInGame);
            pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.Location = new Point(50, 200);
            label.Font = new Font("murtuza", 20);
            label.ForeColor = System.Drawing.Color.Black;
            label.Text = time;
            label.Size = new Size(100, 40);
            label2.Location = new Point(55, 100);
            label2.Font = new Font("murtuza", 30);
            label2.Text = "";
            label2.Size = new Size(90, 50);
            StartStopButton.Location = new Point(55, 250);
            StartStopButton.Font = new Font("murtuza", 8);
            StartStopButton.Text = "Start";
            StartStopButton.Size = new Size(55, 20);
            StartStopButton.Click += new EventHandler(StartOrStopTimer);
            pan.Controls.Add(label);
            pan.Controls.Add(label2);
            pan.Controls.Add(StartStopButton);
            this.Controls.Add(pan);
        }


        private void InfoMssg(string mssg)
        {
            Form2 info = new Form2(mssg);
            info.Show();
        }


        private PictureBox CreateNewWithAttributes(PictureBox box)
        {
            return new PictureBox {
                Image = box.Image, ImageLocation = box.ImageLocation,
                Location = box.Location, Size = box.Size, Cursor = box.Cursor,
                SizeMode = box.SizeMode
            };
        }


        private void BoxesSwaper(int n)
        {
            Random rnd = new Random();
            List<int> UsedNums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int num = rnd.Next(0, n);
                if(!UsedNums.Contains(num))
                    UsedNums.Add(num);
                else
                    while (UsedNums.Contains(num))
                        {
                            num = rnd.Next(0, n);
                            if (!UsedNums.Contains(num))
                                {
                                    UsedNums.Add(num);
                                    break;
                                }
                        }
            }

            for (int i = 0; i < n; i+=2)
            {
                PictureBox box = CreateNewWithAttributes(PictureBoxesFace[UsedNums[i + 1]]);
                PictureBoxesFace[UsedNums[i + 1]] = PictureBoxesFace[UsedNums[i]];
                PictureBoxesFace[UsedNums[i]] = box;
            }
        }


        private void BoxesOrganizer()
        {
            int x = 10, y = 10;
            for(int i = 0; i < PictureBoxesFace.Count(); i++)
            {
                PictureBoxesFace[i].Size = new System.Drawing.Size(110, 130);
                PictureBoxesFace[i].SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBoxesFace[i].Location = new Point(x, y);
                PictureBoxesCover[i].Size = new System.Drawing.Size(110, 130);
                PictureBoxesCover[i].SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBoxesCover[i].Location = new Point(x, y);
                PictureBoxesCover[i].Cursor = Cursors.Hand;
                PictureBoxesCover[i].Click += new EventHandler(ToggleCard);
                if(mode != "Hard")
                    if ((i + 1) % 4 == 0)
                    {
                        y += 140;
                        x = 10;
                    }
                    else
                        x += 120;
                else
                    if ((i + 1) % 8 == 0)
                    {
                        y += 140;
                        x = 10;
                    }
                else
                    x += 120;
                this.Controls.Add(PictureBoxesFace[i]);
                PictureBoxesFace[i].Hide();
                PictureBoxesCover[i].Enabled = false;
                this.Controls.Add(PictureBoxesCover[i]);
            }
        }


        private void ToggleCard(object sender, EventArgs e)
        {
            if (BoxPairs.Count() == 2)
                return;
            PictureBox box = (PictureBox)sender;
            if (PictureBoxesCover.Contains(box))
            {
                int index = PictureBoxesCover.IndexOf(box);
                PictureBoxesFace[index].Show();
                box.Hide();
                BoxPairs.Add(index);
            }
            if (BoxPairs.Count() == 2)
            {
                foreach (PictureBox box1 in PictureBoxesCover)
                    box1.Enabled = false;
                timer3.Start();
            }
        }



        private void ToggleWholeCards(int flip)
        {
            foreach (PictureBox box in PictureBoxesCover)
                if (flip == 1)
                    box.Hide();
                else
                    box.Show();
            foreach (PictureBox box in PictureBoxesFace)
                if (flip == 1)
                    box.Show();
                else
                    box.Hide();
        }


        private void HideGameStuff()
        {
            foreach (PictureBox box in PictureBoxesFace)
                box.Hide();
            foreach (PictureBox box in PictureBoxesCover)
                box.Hide();
            pan.Hide();
        }


        private void BoxesMaker(int BoxesNum)
        {
            Random rnd = new Random();
            int num = 0;
            List<int> UsedIndexes = new List<int>();
            for(int i = 0; i < BoxesNum ; i += 2)
            {
                while(UsedIndexes.Contains(num))
                    num = rnd.Next(0, 18);
                UsedIndexes.Add(num);
                string path = PicsPaths[num];
                for(int j = 0; j < 2; j++)
                {
                    PictureBoxesFace.Add(new PictureBox());
                    PictureBoxesCover.Add(new PictureBox());
                    PictureBoxesFace[i + j].Image = Image.FromFile(path);
                    PictureBoxesCover[i + j].Image = Image.FromFile(PicsPaths[18]);
                    PictureBoxesFace[i + j].ImageLocation = PicsPaths[num];
                    PictureBoxesCover[i + j].ImageLocation = PicsPaths[18];
                }
            }
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
            HideGameStuff();
            PictureBoxesFace.Clear();
            PictureBoxesCover.Clear();
            BoxPairs.Clear();
            pan = null;
            label = label2 = null;
            this.Size = new Size(382, 393);
            ModeMenu.Show();
        }


        private void StartOrStopTimer(object sender, EventArgs e)
        {
            if (TPreGame != -1)
            {
                ToggleWholeCards(1);
                timer2.Start();
                StartStopButton.Enabled = false;
            }
            else if (StartStopButton.Text == "Start")
            {
                foreach (PictureBox box in PictureBoxesCover)
                    box.Enabled = true;
                if(Tsecs == TTsecs && Tmins == TTmins )
                    ToggleWholeCards(0);
                timer1.Start();
                StartStopButton.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                StartStopButton.Text = "Start";
                foreach (PictureBox box in PictureBoxesCover)
                    box.Enabled = false;
            }

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (Tmins == 0 && Tsecs == 0)
            {
                timer1.Stop();
                StartStopButton.Text = "Start";
                Tsecs = TTsecs;
                Tmins = TTmins;
                return;
            }
            else if (Tmins >= 1 && Tsecs == 0)
            {
                Tmins--;
                Tsecs = 59;
            }
            else if (Tsecs > 0)
                Tsecs--;
            UpdateTime();
        }


        private void UpdateTime()
        {
            if (Tsecs <= 10 && Tmins < 1)
                label.ForeColor = System.Drawing.Color.Red;
            if (Tsecs < 10)
                label.Text = (Tmins + " : 0" + Tsecs);
            else
                label.Text = (Tmins + " : " + Tsecs);
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            if(wait == 0)
            {
                if (PictureBoxesFace[BoxPairs[0]].ImageLocation != PictureBoxesFace[BoxPairs[1]].ImageLocation)
                {
                    PictureBoxesFace[BoxPairs[0]].Hide();
                    PictureBoxesFace[BoxPairs[1]].Hide();
                    PictureBoxesCover[BoxPairs[0]].Show();
                    PictureBoxesCover[BoxPairs[1]].Show();
                }
                BoxPairs.Clear();
                timer3.Stop();
                wait = Swait;
                foreach (PictureBox box in PictureBoxesCover)
                    box.Enabled = true;
                return;
            }
                wait--;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if(TPreGame < 0)
            {
                timer2.Stop();
                label2.Text = "";
                StartStopButton.Enabled = true;
                StartStopButton.PerformClick();
                return;
            }
            if (TPreGame == 0)
                label2.Text = "Go!";
            if (TPreGame != 0)
                label2.Text = TPreGame.ToString();
            TPreGame--;
        }
    }
}
