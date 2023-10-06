using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    public class Figure
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IntPoint _point;
        public IntPoint point
        {
            get { return _point; }
            set
            {
                if (_point != value)
                {
                    _point = value;
                    OnPropertyChanged(nameof(point)); // Уведомление о изменении свойства x
                }
            }
        }
        private string _image;
        public string image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(image)); // Уведомление о изменении свойства image
                }
            }
        }
        protected IntPoint[] hints;
        public List<IntPoint> GetHints()
        {
            List<IntPoint> ListHint = new ();
            foreach(IntPoint hint in hints)
            {
                if ((this.point.X + hint.X) < 0 || (this.point.Y + hint.Y) < 0 || (this.point.X + hint.X) > 7 || (this.point.Y + hint.Y) > 7)
                {
                    continue;
                }
                ListHint.Add(new IntPoint(this.point.X + hint.X, this.point.Y + hint.Y));
            }
            return ListHint;
        }
        public Figure(string image)
        {
            this.image = image;
        }
    }
}
