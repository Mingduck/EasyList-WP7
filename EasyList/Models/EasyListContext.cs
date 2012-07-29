using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using EasyList.Models.Interfaces;
using EasyList.Models.BaseModels;
using EasyList.Models;

namespace EasyList.Models
{
    public class EasyListDataContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/EasyListDatabase.sdf";

        // Pass the connection string to the base class.
        public EasyListDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a single table for the Settings items.
        public Table<SettingsTable> Settings;

        // Specify a single table for the Lists items.
        public Table<ListsTable> Lists;

        // Specify a single table for the ListItems items.
        public Table<ListItemsTable> ListItems;

        /// <summary>
        /// Get all content from  the Settings-table as an ObservableCollection.
        /// </summary>
        /// <returns>
        /// An Observable collection of SettingsTable objects.
        /// </returns>
        public ObservableCollection<SettingsTable> GetSettings()
        {
            var settingsInDb = from     SettingsTable settings
                               in       this.Settings
                               select   settings;

            return new ObservableCollection<SettingsTable>(settingsInDb);
        }
    }
}
