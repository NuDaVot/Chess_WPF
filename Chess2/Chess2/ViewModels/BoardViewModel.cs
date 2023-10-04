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
        readonly private Board board;
        //Белые
        public int[] location_number_letters {  get; set; }
        //Черный
        public int[] revers_location_number_letters { get; set; }


        public BoardViewModel()
        {
            board = new Board(true);
            AddList = board.cells;
            location_number_letters = board.location_number_letters;
            revers_location_number_letters = board.revers_location_number_letters;
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
            cell.borderStyle = (Style)Application.Current.FindResource("select_border");
            if (pastObj != null && pastObj != cell) {
                if ((pastObj.x + pastObj.y) % 2 != 0)
                    pastObj.borderStyle = (Style)Application.Current.FindResource("red_border"); 
                else
                    pastObj.borderStyle = (Style)Application.Current.FindResource("transparent_border");
            }
            pastObj = cell;
            board.testc(cell.x, cell.y);

        });


    }
}
