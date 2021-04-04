using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Auto_service.Services
{
    public class TagWrapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                List<TextBlock> texts = new List<TextBlock>();
                foreach (Tag item in (ICollection<Tag>)value)
                {
                    texts.Add(new TextBlock
                    {
                        Text = item.Title,
                        FontFamily = new System.Windows.Media.FontFamily("Tw Cen MT"),
                        FontSize = 16,
                        MinHeight = 20,
                        Padding = new System.Windows.Thickness(3, 0, 3, 0),
                        Margin = new System.Windows.Thickness(3, 5, 3, 5),
                        TextWrapping = System.Windows.TextWrapping.Wrap,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                        Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#" + item.Color)

                        )
                    });
                }
                return texts;

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                List<Tag> tags = new List<Tag>();
                foreach (TextBlock item in (ICollection<TextBlock>)value)
                {
                    tags.Add(new Tag
                    {
                        Title = item.Text,
                        Color = ((SolidColorBrush)(item.Foreground)).Color.ToString()
                    });
                }
                return tags;
            }
            return null;
        }
    }
}

