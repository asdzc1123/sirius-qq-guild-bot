using Sirius.CoreCSharp.Logger;
using Sirius.UI.Services;
using Sirius.UI.ViewModels;
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
    /// GoLogPage.xaml 的交互逻辑
    /// </summary>
    public partial class GoLoggerView : UserControl
    {
        public GoLoggerView()
        {
            DataContext = ServiceContainer.Find<IGoLoggerService>().ViewModel;
            InitializeComponent();
        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem.ToString();
        }
    }

    internal partial class GoLogColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LogLevel level = (LogLevel)value;
            return level switch
            {
                LogLevel.Debug => new SolidColorBrush(Colors.HotPink),
                LogLevel.Info => new SolidColorBrush(Colors.Green),
                LogLevel.Warn => new SolidColorBrush(Colors.Orange),
                LogLevel.Error => new SolidColorBrush(Colors.Red),
                _ => throw new ArgumentOutOfRangeException(null, nameof(level)),
            };
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object { };
        }
    }
}
