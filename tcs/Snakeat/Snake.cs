using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snakeat
{
    class Snake
    {
        public List<Black> SL=new List<Black>();
        public Point Head=new Point();
        public int W, H;
        public int Forld;//朝向，1蛇上 2蛇下 3蛇左 4蛇右也可以用来认知下一个蛇方块的位置
        public Snake() { }
        public Snake(int w, int h,int u, int v,int[][] Base) {
            W = w; H = h;
            //初始化蛇 集合
            Head = new Point(u, v);
            SL.Add(new Black(Head.X-2,Head.Y,W,H));
            SL.Add(new Black(Head.X-1,Head.Y,W,H));
            SL.Add(new Black(Head.X,Head.Y,W,H));
            //蛇的初始方向 //初始方向
             Base[SL[0].Y][SL[0].X] = 4;
            Base[SL[1].Y][SL[1].X] = 4;
            Base[SL[2].Y][SL[2].X] = 4;
            Forld = 4;
        }
        public void Draw(Graphics g, Color c)
        {
            foreach (Black b in SL)
            {
                b.Draw(g, c);
            }
        }
        public void Clear(Graphics g, Color c,int[][] Base)
        {
            foreach (Black b in SL)
            {
                Base[b.Y][b.X]=0;
                b.clear(g, c);
            }
        }
        public void MoveTail(Graphics g, Color c,int[][] Base)
        {
            Base[SL[0].Y][SL[0].X] = 0;
            SL[0].clear(g,c);
            SL.RemoveAt(0);
        }
        public void MoveHead(Graphics g, Color c,int[][] Base)
        {
            Black B = new Black(Head.X,Head.Y,W,H);
            SL.Add(B);
            if (Base[B.Y][B.X] == 0)
            Base[B.Y][B.X] = Forld;
            else
            {
                Base[B.Y][B.X] = 7;
            }
            B.Draw(g, c);
        }
        public void moveR() { Head.X++; Forld = 4; }
        public void moveL() { Head.X--; Forld = 3; }
        public void moveD() { Head.Y++; Forld = 2; }
        public void moveU() { Head.Y--; Forld = 1; }
    }
}
