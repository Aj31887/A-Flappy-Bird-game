using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdWForms
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool gameEnded = false;



        public Form1()
        {
            InitializeComponent();
            gameOverLabel.Text = "";
            restartLabel.Text = "";

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            
            
            


            scoreText.Text = "SCORE: " + score.ToString();

            if (pipeBottom.Left < -75)
            {
                pipeBottom.Left += 600;
                score++;
                pipeSpeed += 1;
            }
            
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 700;
                score++;

            }

            if(ground1.Right <= 0)
            { ground1.Left = 314; }






            if (
                flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground1.Bounds) ||
                flappyBird.Top < -25
                )
            {
                endGame();
            }


        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -25;
            }

            if (e.KeyCode == Keys.Return && gameEnded)
            {

                RestartGame();

            }


        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }




        }

        private void endGame()
        {
            gameTimer.Stop();
            //scoreText.Text += "         GAME OVER";
            gameOverLabel.Text = "GAME OVER";
            restartLabel.Text = "Press Enter to play again...";
            gameEnded = true;
        }

        private void RestartGame()
        {
            gameEnded = false;
            pipeSpeed = 8;
            gameOverLabel.Text = "";
            restartLabel.Text = "";
            score = 0;
            flappyBird.Top = 50;
            pipeTop.Left = 600;
            pipeBottom.Left = 500;
            gameTimer.Start();
        }


    }

}
