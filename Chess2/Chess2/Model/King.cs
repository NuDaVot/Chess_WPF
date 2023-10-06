using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class King : Figure
    {
        public King(string image) : base(image)
        {
            this.hints = new IntPoint[] { new(-1, -1), new(-1, 0), new (-1, 1), //-x, y
                                          new(0, -1),              new(0, 1),
                                          new(1, -1), new(1, 0), new(1, 1)}; 
        }
    }
}
