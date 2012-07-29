using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using EasyList.Models;
using EasyList.Models.BaseModels;

namespace EasyList.ViewModels.Interfaces
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// An observable collection for Settings-objects.
        /// </summary>
        public ObservableCollection<ListItemsTable> Items;

        /// <summary>
        /// A value to indicate whether all data has been loaded.
        /// </summary>
        public bool IsDataLoaded;

        /// <summary>
        /// Event handler to handling of a property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData();

        /// <summary>
        /// Set the property that has been changed.
        /// </summary>
        /// <param name="propertyName">The name of property that has been changed.</param>
        private void NotifyPropertyChanged(String propertyName);
    }
}