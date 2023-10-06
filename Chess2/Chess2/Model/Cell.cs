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
        
        private Figure? _figure;
        public Figure? figure
        {
            get { return _figure; }
            set
            {
                hintEllipse = Visibility.Hidden;
                if (_figure != value)
                {
                    _figure = value;
                    OnPropertyChanged(nameof(figure)); // Уведомление о изменении свойства figure
                }
            }
        }
        private Visibility _hintEllipse;
        public Visibility hintEllipse
        {
            get { return _hintEllipse; }
            set
            {
                if (value != _hintEllipse)
                {
                    _hintEllipse = value;
                    OnPropertyChanged(nameof(hintEllipse));
                }
            }
        }

        public Cell(IntPoint point, string borderStyle, Visibility hintEllipse, Figure figure = null)
        {
            
            this.point = point;
            this.borderStyle = (Style)Application.Current.FindResource(borderStyle);
            if (figure == null)
                this.hintEllipse = hintEllipse;
            else
                this.hintEllipse = Visibility.Hidden;
            this.figure = figure;
        }
        public Cell(IntPoint point, Style borderStyle, Visibility hintEllipse, Figure figure = null)
        {
            this.point = point;
            this.borderStyle = borderStyle;
            if (figure == null)
                this.hintEllipse = hintEllipse;
            else
                this.hintEllipse = Visibility.Hidden;
            this.figure = figure;
        }
        public void ChangeVisibility(bool visible) 
        {
            this.hintEllipse = visible? Visibility.Visible : Visibility.Hidden;
        }
    }
}
