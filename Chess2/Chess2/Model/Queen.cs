using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class Queen : Figure //Ферзь
    {
        public Queen(string image, bool isWhite) : base(image, isWhite)
        {
            this.hints = new IntPoint[] { new (1, 0), new (2, 0), new (3, 0), new (4, 0), new (5, 0), new (6, 0), new (7, 0), // +x
                                   new (-1, 0), new (-2, 0), new (-3, 0), new (-4, 0), new (-5, 0), new (-6, 0), new (-7, 0), // -x
                                   new (0, 1), new (0, 2), new (0, 3), new (0, 4), new (0, 5), new (0, 6), new (0, 7), // +y
                                   new (0, -1), new (0, -2), new (0, -3), new (0, -4), new (0, -5), new (0, -6), new (0, -7), // -y
                                   new (1, 1), new (2, 2), new (3, 3), new (4, 4), new (5, 5), new (6, 6), new (7, 7), // +x, +y
                                   new (-1, 1), new (-2, 2), new (-3, 3), new (-4, 4), new (-5, 5), new (-6, 6), new (-7, 7), // -x, +y
                                   new (1, -1), new (2, -2), new (3, -3), new (4, -4), new (5, -5), new (6, -6), new (7, -7), // +x, -y
                                   new (-1, -1), new (-2, -2), new (-3, -3), new (-4, -4), new (-5, -5), new (-6, -6), new (-7, -7)}; // -x, -y
        }
    }

}
