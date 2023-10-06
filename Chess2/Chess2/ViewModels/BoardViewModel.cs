using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.ViewModels
{
    class BoardViewModel : BindableBase
    {
        //Белые
        public int[] location_number_letters => (new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        //Черный
        public int[] location_number_letters0 => (new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });


        public BoardViewModel()
        {
            _addList = new ObservableCollection<Cell>();
           
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((x + y) % 2 != 0)
                        AddList.Add(new Cell(x, y, "red_border", "BB"));
                    else
                        AddList.Add(new Cell(x, y, "transparent_border", "RW"));
                }
            }     
        }
        private ObservableCollection<Cell> _addList { get; set; }
        public ObservableCollection<Cell> AddList
        {
            get { return _addList; }
            set { _addList = value; RaisePropertiesChanged("AddList"); }
        }
        private Cell pastObj;
        public DelegateCommand<object> ChangePage => new DelegateCommand<object>(obj =>
        {
            Cell cell = (Cell)obj;
            //Белые 
            Debug.WriteLine($"Координаты в матрице: {cell.x}, {cell.y}");
            Debug.WriteLine($"Координаты на доске:{location_number_letters0[cell.x] - 2}, {cell.y}");
            Debug.WriteLine($"__________________");
            ////Черный
            //Debug.WriteLine($"Координаты в матрице: {cell.x}, {cell.y}");
            //Debug.WriteLine($"Координаты на доске:{cell.x}, {location_number_letters[cell.y]-2}");
            //Debug.WriteLine($"__________________");
            cell.borderStyle = (Style)Application.Current.FindResource("select_border");
            if (pastObj != null && pastObj != cell) {
                if ((pastObj.x + pastObj.y) % 2 != 0)
                    pastObj.borderStyle = (Style)Application.Current.FindResource("red_border"); 
                else
                    pastObj.borderStyle = (Style)Application.Current.FindResource("transparent_border");
            }
            pastObj = cell;
            
        });


    }
}
