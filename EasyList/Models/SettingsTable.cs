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
    /// <summary>
    /// The Settings-table.
    /// </summary>
    [Table]
    public class SettingsTable : EasyListTable
    {
        private string key;
        private string value;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                if (this.key != value)
                {
                    this.NotifyPropertyChanging("Key");
                    this.key = value;
                    this.NotifyPropertyChanged("Key");
                }
            }
        }

        [Column]
        public string Value 
        {
            get 
            {
                return this.value;
            }

            set 
            { 
                if (this.value != value) 
                {
                    this.NotifyPropertyChanging("Value");
                    this.value = value;
                    this.NotifyPropertyChanged("Value");
                }
            }
        }
    }
}
