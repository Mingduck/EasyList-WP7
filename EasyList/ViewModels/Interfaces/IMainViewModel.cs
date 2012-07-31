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
    public interface IMainViewModel
    {
        /// <summary>
        /// An observable collection for Settings-objects.
        /// </summary>
        ObservableCollection<SettingsTable> Settings { get; set; }

        /// <summary>
        /// An observable collection for Lists-objects.
        /// </summary>
        ObservableCollection<ListsTable> Lists { get; set; }

        /// <summary>
        /// An observable collection for ListItems-objects.
        /// </summary>
        ObservableCollection<ListItemsTable> ListItems { get; set; }

        /// <summary>
        /// A value to indicate whether all data has been loaded.
        /// </summary>
        bool IsDataLoaded { get; set; }

        /// <summary>
        /// Event handler to handling of a property change.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        void LoadData(EasyListDataContext db);

        /// <summary>
        /// Set the property that has been changed.
        /// </summary>
        /// <param name="propertyName">The name of property that has been changed.</param>
        void NotifyPropertyChanged(String propertyName);
    }
}