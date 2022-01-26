using Sirius.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// BotLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class BotLoginView : Page
    {

        public BotLoginView(Action toShellViewAction)
        {
            DataContext = new BotLoginViewModel(toShellViewAction);
            InitializeComponent();
            //var type = DataContext.GetType();
            //var toShellViewActionField = type.GetField("toShellViewAction", BindingFlags.NonPublic | BindingFlags.Instance);
            //toShellViewActionField!.SetValue(DataContext, toShellViewAction);
        }


    }
}
