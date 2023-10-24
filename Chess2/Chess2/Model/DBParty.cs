using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    public class DBParty : Party
    {
        public string ModeImage { get; set; }
        public string ResultImage { get; set; }
        public string WhiteUserImage { get; set; }
        public string BlackUserImage { get; set; }
        public AsyncCommand PartyCommand => new(async () =>
        {
            Debug.WriteLine("Мод: "+Mode);
            Debug.WriteLine($"Белая сторона: {WhiteUserNavigation.Nick}({WhiteUserNavigation.Rating})");
            Debug.WriteLine($"Черная сторона: {BlackUserNavigation.Nick}({BlackUserNavigation.Rating})");
            Debug.WriteLine("Результат: " + Result);
            Debug.WriteLine("Дата: "+ Date);
        });
    }
}
