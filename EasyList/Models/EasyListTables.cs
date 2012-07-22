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
    // Settings.
    [Table]
    public class Settings : EasyListTable
    {
        private string key;
        private string value;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                if (key != value)
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

    // Lists.
    [Table]
    public class Lists : EasyListTable
    {
        private int id;
        private string name;
        private DateTime lastModified;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
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

    // ListItems.
    [Table]
    public class ListItems : EasyListTable
    {
        private int id;
        private int listId;
        private string value;
        private DateTime lastModified;
        private bool selected;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    this.NotifyPropertyChanging("Id");
                    this.id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }

        [Column]
        public int ListId
        {
            get
            {
                return this.listId;
            }

            set
            {
                if (this.listId != value)
                {
                    this.NotifyPropertyChanging("ListId");
                    this.listId = value;
                    this.NotifyPropertyChanged("ListId");
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

        [Column]
        public bool Selected
        {
            get
            {
                return this.selected;
            }

            set
            {
                if (this.selected != value)
                {
                    this.NotifyPropertyChanging("Selected");
                    this.selected = value;
                    this.NotifyPropertyChanged("Selected");
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
