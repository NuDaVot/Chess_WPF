using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2.Converters
{
    public class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imageName)
            {
                // Создайте путь к ресурсу изображения
                string imagePath = "/Chess2;component/Resources/Figures/" + imageName + ".png";

                // Возвращаем путь к ресурсу
                return new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
