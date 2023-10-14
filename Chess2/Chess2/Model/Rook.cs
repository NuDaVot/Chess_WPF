using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class Rook : Figure //Ладья
    {
        public Rook(string image, bool isWhite) : base(image, isWhite)
        {
            
            this.hints = new IntPoint[] { new (7, 0), new (6, 0), new (5, 0), new (4, 0), new (3, 0), new (2, 0), new (1, 0), //+x
                                       new (-7, 0), new (-6, 0), new (-5, 0), new (-4, 0), new (-3, 0), new (-2, 0), new (-1, 0), //-x
                                       new (0, 7), new (0, 6), new (0, 5), new (0, 4), new (0, 3), new (0, 2), new (0, 1), //+y
                                       new (0, -7), new (0, -6), new (0, -5), new (0, -4), new (0, -3), new (0, -2), new (0, -1)}; //-y
        }
    }
}
