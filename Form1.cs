using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RussianRoulette
{
    public partial class Form1 : Form
    {
        Operations myOperations = new Operations();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStartRound_Click(object sender, EventArgs e)
        {
            StartRound();

            // Hide Dialog
            LblDialog1.Enabled = false;
            LblDialog1.Visible = false;
            LblDialog2.Enabled = false;
            LblDialog2.Visible = false;
        }

        private void Balloon_Click(object sender, EventArgs e)
        {
            PopBalloon(sender); // Future proofing
        }

        private void PopBalloon(object sender)
        {
            // Define PoppedBalloon Resources -- Should Array be define somewhere else?
            Image[] PoppedBalloon = new Image[6];
            PoppedBalloon[0] = Properties.Resources.PoppedBlack;
            PoppedBalloon[1] = Properties.Resources.PoppedBlue;
            PoppedBalloon[2] = Properties.Resources.PoppedGreen;
            PoppedBalloon[3] = Properties.Resources.PoppedPurple;
            PoppedBalloon[4] = Properties.Resources.PoppedRed;
            PoppedBalloon[5] = Properties.Resources.PoppedYellow;

            // Define which PictureBox was clicked
            PictureBox TempImg = (PictureBox)sender;
            // Strip balloon name for identifier 
            int BalloonNum = int.Parse((TempImg.Name).Substring((TempImg.Name).Length - 1));

            // Update balloon image and
            TempImg.Image = PoppedBalloon[BalloonNum];
            // Disable click on this balloon
            TempImg.Enabled = false;
            // Plays BalloonPop sound
            SoundPlayer BalloonPop = new SoundPlayer(Properties.Resources.BalloonPop);
            BalloonPop.Play();

            // Compares popped balloon to BadBalloon (Back end)
            if (myOperations.PopBalloon(BalloonNum))
            {
                RoundLose();
            }
            else
            {
                if (myOperations.CheckPopCount())
                {
                    RoundWin();
                }
                else
                {
                    // If PopCount is Less than 4 then continue as normal.
                }
            }
        }

        private void StartRound()
        {
            // Disable Start Round Button
            BtnStartRound.Enabled = false;
            BtnStartRound.Visible = false;

            // Disable Round Loss Label
            LblRoundLoss.Enabled = false;
            LblRoundLoss.Visible = false;

            // Disable Round Win Label
            LblRoundWin.Enabled = false;
            LblRoundWin.Visible = false;

            // Define Balloon Resources
            Image[] Balloon = new Image[6];
            Balloon[0] = Properties.Resources.BalloonBlack;
            Balloon[1] = Properties.Resources.BalloonBlue;
            Balloon[2] = Properties.Resources.BalloonGreen;
            Balloon[3] = Properties.Resources.BalloonPurple;
            Balloon[4] = Properties.Resources.BalloonRed;
            Balloon[5] = Properties.Resources.BalloonYellow;

            // Make Images Visible
            Balloon0.Visible = true;
            Balloon1.Visible = true;
            Balloon2.Visible = true;
            Balloon3.Visible = true;
            Balloon4.Visible = true;
            Balloon5.Visible = true;

            // Enable Images
            Balloon0.Enabled = true;
            Balloon1.Enabled = true;
            Balloon2.Enabled = true;
            Balloon3.Enabled = true;
            Balloon4.Enabled = true;
            Balloon5.Enabled = true;

            // Reset Images
            Balloon0.Image = Balloon[0];
            Balloon1.Image = Balloon[1];
            Balloon2.Image = Balloon[2];
            Balloon3.Image = Balloon[3];
            Balloon4.Image = Balloon[4];
            Balloon5.Image = Balloon[5];

            // Call StartRound (Back End Operations)
            myOperations.StartRound();
        }
        public void RoundWin()
        {
            // Disable Images
            Balloon0.Enabled = false;
            Balloon1.Enabled = false;
            Balloon2.Enabled = false;
            Balloon3.Enabled = false;
            Balloon4.Enabled = false;
            Balloon5.Enabled = false;

            // Play Victory Sound
            SoundPlayer Victory = new SoundPlayer(Properties.Resources.Victory);
            Victory.Play();

            // Enable Round Win Label
            LblRoundWin.Enabled = true;
            LblRoundWin.Visible = true;

            // Enable Start Round Button
            BtnStartRound.Text = "Play Again!";
            BtnStartRound.Enabled = true;
            BtnStartRound.Visible = true;

            // Update Front End Win Count
            LblWins.Text = "Wins: " + myOperations.UpdateLoses().ToString();

        }
        public void RoundLose()
        {
            // Disable Images
            Balloon0.Enabled = false;
            Balloon1.Enabled = false;
            Balloon2.Enabled = false;
            Balloon3.Enabled = false;
            Balloon4.Enabled = false;
            Balloon5.Enabled = false;

            // Play Loss Sound
            SoundPlayer BalloonExplode = new SoundPlayer(Properties.Resources.BalloonExplode);
            BalloonExplode.Play();

            // Enable Round Loss Label
            LblRoundLoss.Enabled = true;
            LblRoundLoss.Visible = true;

            // Enable Start Round Button
            BtnStartRound.Text = "Play Again!";
            BtnStartRound.Enabled = true;
            BtnStartRound.Visible = true;

            // Update Front End Loss Count
            LblLoses.Text = "Loses: " + myOperations.UpdateWins().ToString();
        }
    }
}
