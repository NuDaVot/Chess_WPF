using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chess2.Model
{
    class Step
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number;
        public int number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(number));
                }
            }
        }
        private IntPoint _start;
        public IntPoint start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    OnPropertyChanged(nameof(start));
                }
            }
        }
        private IntPoint _end;
        public IntPoint end
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    OnPropertyChanged(nameof(end));
                }
            }
        }
        private Figure _figure;
        public Figure figure
        {
            get { return _figure; }
            set
            {
                if (_figure != value)
                {
                    _figure = value;
                    OnPropertyChanged(nameof(figure));
                }
            }
        }
        private bool _isWhite;
        public bool isWhite
        {
            get { return _isWhite; }
            set
            {
                if (_isWhite != value)
                {
                    _isWhite = value;
                    OnPropertyChanged(nameof(isWhite)); // Уведомление о изменении свойства image
                }
            }
        }

        public Step(int number, IntPoint start, IntPoint end, Figure figure, bool isWhite)
        {
            this.number = number;
            this.start = start;
            this.end = end;
            this.figure = figure;
            this.isWhite = isWhite;
        }
        public Step ConverterStrinStep(string strStep)
        {
            return null;
        }
    }
}
