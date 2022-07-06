using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snakeat
{
    class Black
    {
        public int X;
        public int Y;
        public int H;
        public int W;
        public Black(){}
        public Black(int x,int y,int h,int w){
            X=x;
            Y=y;
            H=h;
            W=w;
        }
        public virtual void Draw(Graphics g,Color c)
        {
            Pen pen = new Pen(c,2);
            g.DrawRectangle(pen, X * W + 2, Y * H + 2, W - 3, H - 3);//绘制矩形
        }
        public void clear(Graphics g, Color c)
        {
            SolidBrush Brush = new SolidBrush(c);
            g.FillRectangle(Brush, X * W + 1, Y * H + 1, W - 1, H - 1);//填充矩形内部
        }

    }
}
