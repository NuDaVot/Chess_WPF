using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    class Pawn : Figure //Пешка
    {
        //bool взятие_напроходе;
        public Pawn(string image, bool isWhite) : base(image, isWhite)
        {
            this.hints = new IntPoint[] { new(-1, -1), new(0, -1), new(0, -2), new(1, -1) }; // Варианты хода пешки
        }
        public List<IntPoint> GetAllHints()
        {
            return new List<IntPoint>(hints);
        }
    }
}
