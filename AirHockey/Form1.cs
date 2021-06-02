/* Esther Bae 
 * Mr. T
 * June 2, 2021
 * Air Hockey game
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        //global variables
        Rectangle player1 = new Rectangle(170, 150, 30, 30);
        Rectangle player2 = new Rectangle(400, 150, 30, 30);
        Rectangle puck = new Rectangle(290, 155, 10, 10);
        Rectangle p1Net = new Rectangle(-55, 105, 105, 105);
        Rectangle p2Net = new Rectangle(550, 105, 105, 105);
        Rectangle p1Top, p1Left, p1Bottom, p1Right, p2Top, p2Left, p2Bottom, p2Right;

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;
        int puckXSpeed = -5;
        int puckYSpeed = 5;

        int p1X, p1Y, p2X, p2Y, puckX, puckY;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool leftArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;

        Pen whitePen = new Pen(Color.White, 6);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush blueBrush = new SolidBrush(Color.CornflowerBlue);
        SolidBrush purpleBrush = new SolidBrush(Color.DarkViolet);

        //SoundPlayer hitWall = new SoundPlayer(Properties.Resources.hitWall);
        //SoundPlayer goal = new SoundPlayer(Properties.Resources.goal);
        //SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        //SoundPlayer hitPlayer = new SoundPlayer(Properties.Resources.hitPlayer);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //x + y values of paddles and puck
            p1X = player1.X;
            p1Y = player1.Y;
            p2X = player2.X;
            p2Y = player2.Y;
            puckX = puck.X;
            puckY = puck.Y;

            //move puck
            puck.X += puckXSpeed;
            puck.Y += puckYSpeed;

            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (dDown == true && player1.X < this.Width / 2 - player1.Width)
            {
                player1.X += playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //puck collision with walls (exl. net)
            if (puck.Y < 20 || puck.Y > this.Height - puck.Height - 20)
            {
                puckYSpeed *= -1;

                //hitWallSound.Play();
            }
            else if (puck.X < 20 || puck.X > this.Width - puck.Width - 20)
            {
                puckXSpeed *= -1;

                //hitWallSound.Play();
            }

            //player paddle sides
            p1Top = new Rectangle(player1.X, player1.Y, player1.Width, player1.Height);
            p1Left = new Rectangle(player1.X, player1.Y, player1.Width, player1.Height);
            p1Bottom = new Rectangle(player1.X, player1.Y, player1.Width, player1.Height);
            p1Right = new Rectangle(player1.X, player1.Y, player1.Width, player1.Height);

            p2Top = new Rectangle(player2.X, player2.Y, player2.Width, player2.Height);
            p2Left = new Rectangle(player2.X, player2.Y, player2.Width, player2.Height);
            p2Bottom = new Rectangle(player2.X, player2.Y, player2.Width, player2.Height);
            p2Right = new Rectangle(player2.X, player2.Y, player2.Width, player2.Height);

            //puck collision with player!!!
            if (p1Top.IntersectsWith(puck))
            {
                puckYSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p1Left.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p1Bottom.IntersectsWith(puck))
            {
                puckYSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p1Right.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }

            if (p2Top.IntersectsWith(puck))
            {
                puckYSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p2Left.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p2Bottom.IntersectsWith(puck))
            {
                puckYSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }
            else if (p2Right.IntersectsWith(puck))
            {
                puckXSpeed *= -1;
                puck.X = puckX;
                puck.Y = puckY;

                player1.X = p1X;
                player1.Y = p1Y;

                //playerHitSound.Stop();
                //playerHitSound.Play();
            }

            //points scored
            if (puck.IntersectsWith(p1Net))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                puck.X = 290;
                puck.Y = 155;

                player1.Y = 150;
                player2.Y = 150;

                //playerHitSound.Stop();
                //goalSound.Play();
            }
            else if (puck.IntersectsWith(p2Net))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                puck.X = 290;
                puck.Y = 155;

                player1.Y = 150;
                player2.Y = 150;

                //playerHitSound.Stop();
                //goalSound.Play();
            }

            //player who wins 3 points first wins!!! (stop game)
            if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //show all graphics (players + puck + lines)
            e.Graphics.DrawLine(whitePen, 295, 500, 295, 0);
            e.Graphics.DrawEllipse(whitePen, -55, 105, 105, 105);
            e.Graphics.DrawEllipse(whitePen, 550, 105, 105, 105);
            e.Graphics.FillRectangle(blackBrush, puck);
            e.Graphics.FillRectangle(blueBrush, player1.X, player1.Y, player1.Width, player1.Height);
            e.Graphics.FillRectangle(purpleBrush, player2.X, player2.Y, player2.Width, player2.Height);
        }
    }
}