using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//0什么都没有 1蛇上 2蛇下 3蛇左 4蛇右 5食物 6墙
namespace Snakeat
{
    public partial class Form1 : Form
    {
        public int[][] Base = new int[20][];
        public int pn=2;
        public static int W=20, H=20;//背景的宽 高
      
        private Snake snake;
        private Food food = new Food(W, H);

        public enum Direction { Left, Right, Up, Down };//定义上下左右方向
        public Direction snakeDirection = Direction.Right;//设置蛇初始方向

        public bool isGamePalying = false;//标记游戏开始
        public bool isGameOver = false;//标记游戏结束
        public bool isDirChanged = false;//标志改变蛇的运动方向

        //public PaintEventArgs ee;
        //public Graphics ff;//画图
        public Form1()
        {
            InitializeComponent();
            this.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)//事件的初始状态
        {
            for(int i = 0; i < 20; i++)
            {
                Base[i] = new int[20];
                if (i == 0 || i == 20) 
                {
                    for(int j = 0; j < 20; j++)
                    {
                        Base[i][j] = 6;//表示墙
                    }
                }
                else
                {
                    Base[i][0] = Base[i][19] = 6;
                    for(int j = 1; j < 19; j++)
                    {
                        Base[i][j] = 0;
                    }
                }
            }
           
            snake = new Snake(W, H, 10, 9, Base);//蛇的初始位置
            food = food.NewFood(Base);//食物随机出现的位置
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;//与上一事件间隔时间  蛇的速度
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label1.Visible = false;
           // this.label3.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isGamePalying) return;
            if (!isGameOver)
            {
                isDirChanged = false;
                if (snakeDirection == Direction.Right)
                {
                    snake.moveR();
                }
                else if (snakeDirection == Direction.Down)
                {
                    snake.moveD();
                }
                else if (snakeDirection == Direction.Left)
                {
                    snake.moveL();
                }
                else if (snakeDirection == Direction.Up)
                {
                    snake.moveU();
                }
                if (snake.Head.X >= 19 || snake.Head.X <= 0 ||
                    snake.Head.Y >= 19 || snake.Head.Y <= 0)
                {
                    isGameOver = true;
                    this.label2.Visible = true;
                    return;
                }
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    food.clear(this.CreateGraphics(), this.BackColor);
                    food = food.NewFood(Base);
                    food.Draw(this.CreateGraphics(), Color.Pink);//重画食物
                    GameLevel.Score += 10;
                    GameLevel.score1 += 10;
                    this.label3.Text = GameLevel.Level.ToString();
                    this.label4.Text = GameLevel.score1.ToString();
                    switch (GameLevel.Level)
                    {
                        case 1:
                            this.timer1.Interval = 500;
                            break;
                        case 2:
                            this.timer1.Interval = 400;
                            break;
                        case 3:
                            this.timer1.Interval = 350;
                            break;
                        case 4:
                            this.timer1.Interval = 300;
                            break;
                        default:
                            this.timer1.Interval = 250;
                            break;
                    }
                }
                else
                {
                    snake.MoveTail(this.CreateGraphics(), this.BackColor, Base);
                }
                snake.MoveHead(this.CreateGraphics(), Color.Blue, Base);                   
            }
    }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGamePalying) return;
            else
            {
                if (isDirChanged == true)
                {
                    return;
                }
            }
            if (isDirChanged == true)
            {
            }
            else
            {
                if (e.KeyCode == Keys.Up && snakeDirection != Direction.Down)
                {
                    snakeDirection = Direction.Up;
                    isDirChanged = true;
                }
                if (e.KeyCode == Keys.Down && snakeDirection != Direction.Up)
                {
                    snakeDirection = Direction.Down;
                    isDirChanged = true;
                }
                if (e.KeyCode == Keys.Left && snakeDirection != Direction.Right)
                {
                    snakeDirection = Direction.Left;
                    isDirChanged = true;
                }
                if (e.KeyCode == Keys.Right && snakeDirection != Direction.Left)
                {
                    snakeDirection = Direction.Right;
                    isDirChanged = true;
                }
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
            isGamePalying = true;
            if (isGameOver)
            {
                snake.Clear(this.CreateGraphics(), this.BackColor,Base);
                snake = new Snake(W, H, 10, 9, Base);
                snake.Draw(this.CreateGraphics(), Color.Blue);
                //重置food
                food.clear(this.CreateGraphics(), this.BackColor);//食物所在矩形内部为背景色
                food = food.NewFood(Base);
                food.Draw(this.CreateGraphics(), Color.Pink);//画食物
                //重置分数
                GameLevel.Score = 0;
                GameLevel.score1 = 0;
                this.label3.Text = GameLevel.Level.ToString();
                this.label4.Text = GameLevel.score1.ToString();
                //重置方向为right
                snakeDirection = Direction.Right;
                this.label2.Visible = false;
                isGameOver = false;
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            isGamePalying = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void 登录_Click(object sender, EventArgs e)
        {
                label1.Visible = true;
                //label2.Visible = true;
               // label3.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                按钮.Visible = false;
                KeyPreview = true;//将焦点还给Key，很重要
                Bitmap bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                Graphics g = Graphics.FromImage(bitmap);
                //for (int i = 0; i < 30; i++)
                //{
                //    g.DrawLine(new Pen(Color.LightGray), new Point(20 * i, 0), new Point(20 * i, 600));
                //    g.DrawLine(new Pen(Color.LightGray), new Point(0, 20 * i), new Point(600, 20 * i));
                //}
               
                snake.Draw(g, Color.Blue);
                food.Draw(g, Color.Pink);
                Graphics fg = this.CreateGraphics();
                fg.DrawImage(bitmap, this.ClientRectangle);            
        }
    }
}
