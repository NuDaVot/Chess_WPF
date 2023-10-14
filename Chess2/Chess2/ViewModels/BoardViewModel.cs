using Chess2.Model;
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
        public int[] location_number_letters {  get; set; }

        public BoardViewModel()
        {
            board = new Board(false);
            AddList = board.cells;
            location_number_letters = board.location_number_letters;
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
            pastObj = board.GetHints(cell, pastObj);
            //pastObj = cell;
        });
    }
}
