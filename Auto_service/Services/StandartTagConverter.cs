using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Auto_service.Services
{
    class StandartTagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {              
                Tag tag = (Tag)value;
                TextBlock text = new TextBlock
                {
                    Text = tag.Title,
                    FontFamily = new System.Windows.Media.FontFamily("Tw Cen MT"),
                    FontSize = 16,
                    MinHeight = 20,
                    Padding = new System.Windows.Thickness(3, 0, 3, 0),
                    Margin = new System.Windows.Thickness(3, 5, 3, 5),
                    TextWrapping = System.Windows.TextWrapping.Wrap,
                    Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                    Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#" + tag.Color))
                    
                };
                return text;

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                TextBlock textTag = (TextBlock)value;
                string color = ((SolidColorBrush)(textTag.Background)).Color.ToString();
                string tagColor = color.Remove(0, 3);
                Tag tag = new Tag()
                {
                    Title = textTag.Text,
                    Color = tagColor
                };
                return tag;

            }
            return null;
        }
    }
}
