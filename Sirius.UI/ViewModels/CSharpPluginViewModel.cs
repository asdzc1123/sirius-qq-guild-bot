using Microsoft.Toolkit.Mvvm.ComponentModel;
using Sirius.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.ViewModels
{
    internal class CSharpPluginViewModel : ObservableObject
    {
        public ObservableCollection<CSharpPlugin> Plugins { get; } = new();
    }
}
