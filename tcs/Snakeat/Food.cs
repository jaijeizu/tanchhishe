using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snakeat
{
    class Food:Black
    {
        public Food() { }
        public Food(int w, int h) { W = w; H = h; }
        public override void Draw(Graphics g, Color c)
        {
            Pen pen = new Pen(c, 1);
            SolidBrush brush = new SolidBrush(c);
            g.FillRectangle(brush, X * W + 2, Y * H + 2, W - 3, H - 3);
        }
        public Food NewFood(int[][] Base)
        {
            Random r = new Random();
            Food food = new Food();
            food.X = r.Next(1, 19);
            food.Y = r.Next(1, 19);
            food.W = this.W;
            food.H = this.H;
            return food;
        }
    }
}
