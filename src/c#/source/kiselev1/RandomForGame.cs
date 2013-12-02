using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kiselev1
{
    class RandomForGame
    {
        public int randDigit()
        {
            //случаное число в выборку от [1..6]
            int dig = 0;
            Random rand = new Random();

            dig = rand.Next(6) + 1; //[1..6]

            return dig;
        }

        public int Digit(Game ourGame, int dig = 0)
        {
            //число [1..6]
            dig += 1;
            if (dig > ourGame.alfSpace)
                dig = ourGame.notN;
            return dig;
        }
    }
}
