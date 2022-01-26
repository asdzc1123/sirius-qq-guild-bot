using Sirius.UI.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sirius.UI.Views
{
    /// <summary>
    /// OpenApiLoggerPage.xaml 的交互逻辑
    /// </summary>
    public partial class OpenApiLoggerView : UserControl
    {
        public OpenApiLoggerView()
        {
            DataContext = ServiceContainer.Find<IOpenApiLoggerService>().ViewModel;
            InitializeComponent();
        }
    }

    internal partial class OpenApiLogColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string label = (string)value;
            return label switch
            {
                "Success" => new SolidColorBrush(Colors.Green),
                "Error" => new SolidColorBrush(Colors.Red),
                _ => throw new ArgumentOutOfRangeException(null, nameof(label)),
            };
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object { };
        }
    }
}
