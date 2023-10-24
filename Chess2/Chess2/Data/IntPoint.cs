using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Data
{
    public class IntPoint
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public IntPoint(int x, int y) {  X = x; Y = y; }
        public override bool Equals(object obj)
        {
            if (obj is IntPoint other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public bool OutRange(IntPoint two)
        {
            return (this.X + two.X) < 0 || (this.Y + two.Y) < 0 || (this.X + two.X) > 7 || (this.Y + two.Y) > 7;
        }
        public IntPoint SumPoint(IntPoint two)
        {
            return new IntPoint(this.X + two.X, this.Y + two.Y);
        }
    }
}
