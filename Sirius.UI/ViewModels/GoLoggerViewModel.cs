using Microsoft.Toolkit.Mvvm.ComponentModel;
using Sirius.UI.Models;
using Sirius.UI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.ViewModels
{
    internal class GoLoggerViewModel : ObservableObject
    {
        public ObservableCollection<GoLog> Logs { get; set; } = new();



        public GoLoggerViewModel()
        {
            Logs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
            {
                OnPropertyChanged(nameof(Logs));
            };
        }

        public void Add(GoLog log)
        {
            Logs.Add(log);
            OnPropertyChanged(nameof(Logs));
        }
    }
}
