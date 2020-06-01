using SnakeGame.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Boolean IsGameOver = true;

        Int32 squareSize = 60;
        Int32 numSquaresX = 10;
        Int32 numSquaresY = 10;

        Snake7 snake;

        Image img = null;
        Graphics imgGraph = null;
        Graphics graph = null;

        public Form1()
        {
            InitializeComponent();

            img = new Bitmap(squareSize * numSquaresX, squareSize * numSquaresY);
            imgGraph = Graphics.FromImage(img);
            graph = screen.CreateGraphics();

            snake = new Snake7(numSquaresX, numSquaresY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textGameOver.Visible = false;

            this.timer1.Interval = 200;
            timer1.Start();
        }

        private void ChangeGameState()
        {
            IsGameOver = !IsGameOver;

            this.textGameOver.Visible = IsGameOver;
            this.buttonStart.Visible = IsGameOver;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            snake = new Snake7(numSquaresX, numSquaresY);

            ChangeGameState();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!IsGameOver)
            {
                snake.Move();
                Draw();

                if (snake.IsCrossed())
                {
                    BeginInvoke(new Action(() => ChangeGameState()));
                }
            }
        }

        private void Draw()
        {
            imgGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, squareSize * numSquaresX, squareSize * numSquaresY);

            var gridBrush = new SolidBrush(Color.LightGray);
            var gridPen = new Pen(gridBrush);

            for (int i = 1; i < numSquaresX; ++i)
                imgGraph.DrawLine(gridPen, 0, i * squareSize, squareSize * numSquaresX, i * squareSize);

            for (int i = 1; i < numSquaresX; ++i)
                imgGraph.DrawLine(gridPen, i * squareSize, 0, i * squareSize, squareSize * numSquaresY);

            var snakeColor = new SolidBrush(Color.Black);
            for (int i = 0; i < snake.Points.Count; ++i)
                imgGraph.FillRectangle(snakeColor, squareSize * snake.Points[i].X, squareSize * snake.Points[i].Y, squareSize - 1, squareSize - 1);

            var foodColor = new SolidBrush(Color.Red);
            imgGraph.FillEllipse(foodColor, squareSize * snake.Food.X, squareSize * snake.Food.Y, squareSize, squareSize);

            imgGraph.DrawString("Snake Size: " + snake.Points.Count.ToString(), new Font("Arial", 10), gridBrush, 0, 0);

            graph.DrawImage(img, 0, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                snake.SetDirection(Direction.Up);
            else if (e.KeyCode == Keys.Down)
                snake.SetDirection(Direction.Down);
            else if (e.KeyCode == Keys.Right)
                snake.SetDirection(Direction.Right);
            else if (e.KeyCode == Keys.Left)
                snake.SetDirection(Direction.Left);
        }
    }
}
