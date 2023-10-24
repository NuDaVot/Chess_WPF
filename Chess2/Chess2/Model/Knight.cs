using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class Knight : Figure //Конь
    {
        public Knight(string image, bool isWhite) : base(image, isWhite)
        {
            this.hints = new IntPoint[] { new(2, 1), new(1, 2), new(-2, 1), new(-1, 2), new(2, -1), new(1, -2), new(-2, -1), new(-1, -2) }; // Варианты хода коня
        }
    }

}
