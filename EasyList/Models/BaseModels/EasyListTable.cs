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

namespace EasyList.Models.BaseModels
{   
    [Table]
    public class EasyListTable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the page that a data context property changed
        protected void NotifyPropertyChanged(string propertyName)
        {
            #region INotifyPropertyChanged method

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }

        // Used to notify the data context that a data context property is about to change
        protected void NotifyPropertyChanging(string propertyName)
        {
            #region INotifyPropertyChanging method

            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }

            #endregion
        }        
    }
}
