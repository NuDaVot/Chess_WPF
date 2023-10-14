using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class King : Figure //Король
    {
        public King(string image, bool isWhite) : base(image, isWhite)
        {
            this.hints = new IntPoint[] { new(-1, -1), new(-1, 0), new (-1, 1), //-x, y
                                          new(0, -1),              new(0, 1),
                                          new(1, -1), new(1, 0), new(1, 1)}; 
        }
    }
}
