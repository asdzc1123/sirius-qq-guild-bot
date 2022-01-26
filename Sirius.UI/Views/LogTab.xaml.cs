using Sirius.CoreCSharp;
using Sirius.UI.Models;
using Sirius.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
    /// LogTab.xaml 的交互逻辑
    /// </summary>
    public partial class LogTab : UserControl
    {

        public LogTab()
        {
            InitializeComponent();
        }

        public static void Add()
        {

        }

        private void LogDataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            var dataGrid = (DataGrid)sender;

            Trace.WriteLine(e.ClipboardRowContent.Count);


        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }


}
