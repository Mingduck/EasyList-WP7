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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using EasyList.Models.BaseModels;

namespace EasyList.Models
{
    public class EasyListContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/EasyListDatabase.sdf";

        // Pass the connection string to the base class.
        public EasyListContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a single table for the to-do items.
        public Table<Settings> Settings;

        // Specify a single table for the to-do items.
        public Table<Lists> Lists;

        // Specify a single table for the to-do items.
        public Table<ListItems> ListItems;
    }
}
