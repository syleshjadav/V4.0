using System;
using System.Windows.Media;
using System.Windows.Data;


namespace ATP.Kiosk.Helpers

{


    public class ColorToSolidColorBrushValueConverter : IValueConverter
    {
        private readonly Random _random = new Random();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return GetNextBrush((string)value);
        }

        public Brush GetNextBrush(string htmlcolor)
        {
            if (htmlcolor == null) { htmlcolor = "#FFFFF1"; }
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString(htmlcolor);

            return brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // If necessary, here you can convert back. Check if which brush it is (if its one),
            // get its Color-value and return it.

            throw new NotImplementedException();
        }
    }

    public class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          
            string input = value as string;
          
            switch (input)
            {
                case "BLUE": return Brushes.Blue;
                case "RED": return Brushes.Red;
                case "YELLOW": return Brushes.Yellow;
                case "GREEN": return Brushes.White;
                case "WHITE": return Brushes.White;
                default: return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


}
