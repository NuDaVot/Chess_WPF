using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class Bishop : Figure //Слон
    {
        public Bishop(string image, bool isWhite) : base(image, isWhite)
        {
            this.hints = new IntPoint[] { new (1, 1), new (2, 2), new (3, 3), new (4, 4), new (5, 5), new (6, 6), new (7, 7),
                                   new (-1, 1), new (-2, 2), new (-3, 3), new (-4, 4), new (-5, 5), new (-6, 6), new (-7, 7),
                                   new (1, -1), new (2, -2), new (3, -3), new (4, -4), new (5, -5), new (6, -6), new (7, -7),
                                   new (-1, -1), new (-2, -2), new (-3, -3), new (-4, -4), new (-5, -5), new (-6, -6), new (-7, -7)}; // Варианты хода слона
        }
    }

}
