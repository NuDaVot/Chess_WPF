using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Model
{
    public class DbUser : User, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public int Place { get; set; }
        public Visibility Visibility { get; set; }
        public int Partys { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public string Ban { get; set; }
        public async Task UpdateStatusInDatabase()
        {
            using (var context = new HistoryChessContext())
            {
                // Находите запись в базе данных по какому-то идентификатору (например, ID)
                var itemToUpdate = context.Users.Find(Iduser);

                // Обновляете статус в соответствии с новым значением
                if ((bool)itemToUpdate.Status)
                {
                    itemToUpdate.Status = false;
                    Ban = "Разбан";
                }
                else
                {
                    itemToUpdate.Status = true;
                    Ban = "Бан";
                }
                // Сохраняете изменения в базе данных
                await context.SaveChangesAsync();
            }
        }
        public AsyncCommand BanCommand => new(async () =>
        {
            await UpdateStatusInDatabase();
        });
    }
}
