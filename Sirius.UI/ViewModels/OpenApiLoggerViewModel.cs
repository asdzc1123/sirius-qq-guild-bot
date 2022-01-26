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
    internal class OpenApiLoggerViewModel : ObservableObject
    {
        public ObservableCollection<OpenApiLog> Logs { get; set; } = new();

        public OpenApiLoggerViewModel()
        {
            Logs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
            {
                OnPropertyChanged(nameof(Logs));
            };
        }

        public void Add(OpenApiLog log)
        {
            Logs.Add(log);
        }
    }
}
