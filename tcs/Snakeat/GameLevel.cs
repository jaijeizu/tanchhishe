using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snakeat
{
    public static class GameLevel
    {
        private static int score = 0;
        public static int score1 = 0;
       
        public static int Score
        {
            get { return score; }
            set { score = value; LevelUp(); }
        }

        private static int level = 1;
        public static int Level
        {
            get { return level; }
        }

        private static void LevelUp()
        {
            if (score >= 30)
            {
                level = (int)Math.Log(score / 30, 2) + 2;
            }
        }
    }
}
