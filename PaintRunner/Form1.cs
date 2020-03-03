using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintRunner
{
    public partial class PaintRunnerForm : Form
    {
        //Picture Box
        PictureBox[] Food;

        //Player Location
        int XPlayer = 947;
        int YPlayer = 26;

        //Player Speed
        int PlayerSpeed = 3;

        //EnemySpeed
        int Enemy01Speed = 1;
        int XEnemy02Speed = -3;
        int YEnemy02Speed = -3;
        int Enemy03Speed = 0;
        int Enemy04Speed = 0;

        //FoodCollection Points
        int Food01CollectionPoints = 50;
        int Food02CollectionPoints = 50;
        int Food03CollectionPoints = 50;
        int Food04CollectionPoints = 50;
        int Food05CollectionPoints = 50;
        int Food06CollectionPoints = 50;

        //Food Score
        int AppleScore = 0;
        int PearScore = 0;
        int LemonScore = 0;
        int CherryScore = 0;
        int GrapeScore = 0;
        int PineappleScore = 0;

        //Powerup Radomizer
        int Powerup01Random = 0;
        int Powerup02Random = 0;
        int Powerup03Random = 0;
        int Powerup04Random = 0;
        int Powerup05Random = 0;
        int Powerup06Random = 0;

        //PowerupActive
        bool SpeedBoostActive = false;
        bool ShieldActive = false;

        //PowerupTimer
        int wait = 10;
        int wait2 = 5;

        //Enemy Location
        int XEnemy01 = 1070;
        int YEnemy01 = 793;
        int XEnemy02 = 1050;
        int YEnemy02 = 894;
        bool Enemy02First = false;
        int XEnemy03 = 1340;
        int YEnemy03 = 763;
        int XEnemy04 = 1340;
        int YEnemy04 = 884;

        //Score
        int score = 0;

        //Lost
        bool lost = false;

        //Pause
        bool pause = false;

        //Random Generator
        Random random = new Random();

        //Constructor
        public PaintRunnerForm()
        {
            InitializeComponent();
        }

        private void PaintRunnerForm_Load(object sender, EventArgs e)
        {
            //Load Player Images
            Image Player = Image.FromFile("asserts\\Player.png");
            Image PlayerShielded = Image.FromFile("asserts\\PlayerShielded.png");

            //Load Food Images
            Image Apple = Image.FromFile("asserts\\Apple.png");
            Image Pear = Image.FromFile("asserts\\Pear.png");
            Image Lemon = Image.FromFile("asserts\\Lemon.png");
            Image Cherry = Image.FromFile("asserts\\Cherry.png");
            Image Grape = Image.FromFile("asserts\\Grape.png");
            Image Pineapple = Image.FromFile("asserts\\Pineapple.png");

            //Load Powerup Images
            Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
            Image Shield = Image.FromFile("asserts\\Shield.png");

            //Create PictureBox Array
            Food = new PictureBox[7];

            //Initialize Food PictureBoxes
            for (int i = 0; i < Food.Length; i++)
            {
                Food[i] = new PictureBox();
                Food[i].Size = new Size(40, 40);
                Food[i].SizeMode = PictureBoxSizeMode.Zoom;
                Food[i].Visible = true;
                this.Controls.Add(Food[i]);
                Food[i].Location = new Point(random.Next(67, 908), random.Next(67, 908));
                Food[i].Image = Apple;
            }
        }

        //Reseting the Game
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            PaintRunnerForm_Load(e, e);
        }

        //Pausing the Game
        private void PauseButton_Click(object sender, EventArgs e)
        {

        }

        //Exiting the Game
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //Key Detector
        private void PaintRunnerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (lost == false)
            {
                if (pause == false)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        MoveUpTimer.Start();

                        MoveDownTimer.Stop();
                        MoveLeftTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        MoveLeftTimer.Start();

                        MoveUpTimer.Stop();
                        MoveDownTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        MoveDownTimer.Start();

                        MoveUpTimer.Stop();
                        MoveLeftTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.D)
                    {
                        MoveRightTimer.Start();

                        MoveUpTimer.Stop();
                        MoveDownTimer.Stop();
                        MoveLeftTimer.Stop();
                    }
                }
            }
        }

        //Moving Up
        private void MoveUpTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 17)
            {
                Player.Top -= PlayerSpeed;
            }
        }

        //Moving Down
        private void MoveDownTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 958)
            {
                Player.Top += PlayerSpeed;
            }
        }

        //Moving Left
        private void MoveLeftTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 17)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        //Moving Right
        private void MoveRightTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 958)
            {
                Player.Left += PlayerSpeed;
            }
        }

        //Collision with Food
        private void FoodCollision()
        {
            for (int i = 0; i < Food.Length; i++)
            {
                if (Food[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    
                }
            }
        }

    }
}
