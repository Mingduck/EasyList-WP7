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
using EasyList.Models.Interfaces;
using EasyList.Models.BaseModels;
using EasyList.ViewModels;
using EasyList.ViewModels.Interfaces;

namespace EasyList.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        /// <summary>
        /// An observable collection for Settings-objects.
        /// </summary>
        public ObservableCollection<IEasyListTable> Items { get; private set; }

        /// <summary>
        /// A value to indicate whether all data has been loaded.
        /// </summary>
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// /// <summary>
        /// Event handler to handling of a property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel(ObservableCollection<IEasyListTable> dataItems)
        {
            this.Items = dataItems;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.Items.Add(new ListItemsTable { Id = 1, LastModified = DateTime.Now, ListId = 1, Selected = false, Value = "hoi."});
            this.Items.Add(new ListItemsTable { Id = 2, LastModified = DateTime.Now, ListId = 5, Selected = true, Value = "hoiyoooow." });

            // Sample data; replace with real data
            //this.Items.Add(new ItemViewModel() { LineOne = "runtime one", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            //this.Items.Add(new ItemViewModel() { LineOne = "runtime two", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.IsDataLoaded = true;
        }

        /// <summary>
        /// Set the property that has been changed.
        /// </summary>
        /// <param name="propertyName">The name of property that has been changed.</param>
        private void NotifyPropertyChanged(String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}