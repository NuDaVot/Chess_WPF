using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Chess2.Model
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _x;
        public int x
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged(nameof(x)); // Уведомление о изменении свойства x
                }
            }
        }

        private int _y;
        public int y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(y)); // Уведомление о изменении свойства y
                }
            }
        }

        private Style _borderStyle;
        public Style borderStyle
        {
            get { return _borderStyle; }
            set
            {
                if (_borderStyle != value)
                {
                    _borderStyle = value;
                    OnPropertyChanged(nameof(borderStyle)); // Уведомление о изменении свойства borderStyle
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


        public Cell(int x, int y, string borderStyle, string image = null)
        {
            this.x = x;
            this.y = y;
            this.borderStyle = (Style)Application.Current.FindResource(borderStyle);
            this.image = image;
        }
        public Cell(int x, int y, Style borderStyle, string image = null)
        {
            this.x = x;
            this.y = y;
            this.borderStyle = borderStyle;
            this.image = image;
        }
    }

}
