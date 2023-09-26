using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace AutoService.pages
{
        public class DateTimes : MarkupExtension, IValueConverter
        {
            private static DateTimes _datatime;
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is DateTime dateTime)
                {
                    // Проверяем, равно ли значение dateTime минимальной дате
                    if (dateTime == DateTime.MinValue)
                    {
                        // Если да, то скрываем дату
                        return string.Empty;
                    }
                }

                // Если значение dateTime не минимальное, то отображаем содержимое TextBlock
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return _datatime ?? (_datatime = new DateTimes());
            }
        }
    }

