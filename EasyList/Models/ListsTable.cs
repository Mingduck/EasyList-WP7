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
    // The Lists-table.
    [Table]
    public class ListsTable : EasyListTable
    {
        private int id;
        private string name;
        private DateTime lastModified;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id != value)
                {
                    this.NotifyPropertyChanging("Id");
                    this.id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }

        [Column]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.NotifyPropertyChanging("Name");
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        [Column]
        public DateTime LastModified
        {
            get
            {
                return this.lastModified;
            }

            set
            {
                if (this.lastModified != value)
                {
                    this.NotifyPropertyChanging("LastModified");
                    this.lastModified = value;
                    this.NotifyPropertyChanged("LastModified");
                }
            }
        }
    }
}
