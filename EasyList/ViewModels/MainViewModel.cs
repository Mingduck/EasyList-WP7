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
using EasyList.ViewModels;
using EasyList.ViewModels.Interfaces;
using System.Linq;
using System.Data.Linq;

namespace EasyList.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        /// <summary>
        /// An observable collection for Settings-objects.
        /// </summary>
        public ObservableCollection<SettingsTable> Settings { get; set; }
        
        /// <summary>
        /// An observable collection for Lists-objects.
        /// </summary>
        public ObservableCollection<ListsTable> Lists { get; set; }

        /// <summary>
        /// An observable collection for ListItems-objects.
        /// </summary>
        public ObservableCollection<ListItemsTable> ListItems { get; set; }

        /// <summary>
        /// A value to indicate whether all data has been loaded.
        /// </summary>
        public bool IsDataLoaded { get; set; }

        /// /// <summary>
        /// Event handler to handling of a property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            // Just so we're clear bout thattt!
            this.IsDataLoaded = false;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData(EasyListDataContext db)
        {
            this.Settings = new ObservableCollection<SettingsTable>(from SettingsTable st in db.Settings select st);
            this.Lists = new ObservableCollection<ListsTable>(from ListsTable lt in db.Lists select lt);
            this.ListItems = new ObservableCollection<ListItemsTable>(from ListItemsTable lit in db.ListItems select lit);

            // Sample data; replace with real data
            //this.Items.Add(new ItemViewModel() { LineOne = "runtime one", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            //this.Items.Add(new ItemViewModel() { LineOne = "runtime two", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.IsDataLoaded = true;
        }

        /// <summary>
        /// Set the property that has been changed.
        /// </summary>
        /// <param name="propertyName">The name of property that has been changed.</param>
        public void NotifyPropertyChanged(String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}