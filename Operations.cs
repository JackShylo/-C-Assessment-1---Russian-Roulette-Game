using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    public class Operations
    {
        public int BadBalloon;
        public int PopCount = 0;
        public int Loses = 0;
        public int Wins = 0;

        public void StartRound()
        {
            // Reset PopCount
            PopCount = 0;

            // Generate BadBalloon
            Random myRandom = new Random();
            BadBalloon = myRandom.Next(0, 6);
        }

        public bool PopBalloon(int i)
        {
            if (i == BadBalloon)
            {
                return true;
            }
            else
            {
                PopCount++;
                return false;
            }
        }

        // Checks if 4 Balloons have safely been popped, if so, Round is won.
        public bool CheckPopCount()
        {
            if (PopCount >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UpdateWins()
        {
            Wins++;
            return Wins;
        }

        public int UpdateLoses()
        {
            Loses++;
            return Loses;
        }
    }
}
