using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.ViewModels
{
    class BoardViewModel : BindableBase
    {
        public int[] location_cells_row =>( new int[] {0, 1, 2, 3, 4, 5, 6, 7});
        public int[] location_cells_column =>( new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });

        public int[] location_cells_row1 => (new int[] { 7, 6, 5, 4 ,3 ,2 ,1 ,0});
        public int[] location_cells_column1 => (new int[] { 7, 6, 5, 4 ,3 , 2 ,1 });

        public int[] location_number_letters0 => (new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        public int[] location_number_letters => (new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });

        public string[][] visibility_ellipses => (new string[][]
        {
            new string[]{ "Hidden", "Visible", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Visible", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Visible", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
            new string[]{ "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden", "Hidden" },
        });//Visible

    }
}
