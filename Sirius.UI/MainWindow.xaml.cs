using HandyControl.Controls;
using Sirius.UI.Views;
using System;
using System.Collections.Generic;
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

namespace Sirius.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlowWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            Content = new BotLoginView(ToShellView);
        }

        private void ToShellView()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Content = new ShellView();
            });
        }
    }
}
