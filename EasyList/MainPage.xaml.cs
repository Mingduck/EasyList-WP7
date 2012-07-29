using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Data.Linq;
using Microsoft.Phone.Shell;
using EasyList.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace EasyList
{
    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        // Event used to indicate whether any properties were changed or not.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data context for the local database
        private EasyListContext easyListDb;

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<Settings> settingItems;

        ApplicationBar bar1 = ((ApplicationBar)Application.Current.Resources["AppBar1"]);

        ApplicationBar bar2 = ((ApplicationBar)Application.Current.Resources["AppBar2"]);

        ApplicationBar bar3 = ((ApplicationBar)Application.Current.Resources["AppBar3"]);

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set event listener for XAML Control with Name="Panorama".
            Panorama.SelectionChanged += Panorama_SelectionChanged;

            // Connect to the database and instantiate data context.
            this.easyListDb = new EasyListContext(EasyListContext.DBConnectionString);

            // Data context and observable collection are children of the main page.
            this.DataContext = this;

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        /**
         * private Panorama_SelectionChanged
         * 
         * This function is called when the panorama view has changed. This allows us to take action when that happens.
         * For instance to change the Application Bar to suit the needs of the new view.
         * 
         * return void.
         */
        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = Panorama.SelectedIndex;
            bar1.IsVisible = false;
            bar2.IsVisible = false;
            bar3.IsVisible = false;
            switch (index)
            {
                case 0:
                    ApplicationBar = bar1;
                    bar1.Mode = ApplicationBarMode.Default;
                    break;
                case 1:
                    ApplicationBar = bar2;
                    bar2.Mode = ApplicationBarMode.Default;
                    break;
                case 2:
                    ApplicationBar = bar3;
                    ApplicationBar.Mode = ApplicationBarMode.Minimized;
                    break;
            }
            ApplicationBar.IsVisible = true;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Define the query to gather all of the to-do items.
            var settingItemsInDb =  from Settings settings in this.easyListDb.Settings
                                    select settings;

            // Execute the query and place the results into a collection.
            this.SettingItems = new ObservableCollection<Settings>(settingItemsInDb);

            // Call the base method.
            base.OnNavigatedTo(e);
        }

        private void newToDoTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text box when it gets focus.
            //newToDoTextBox.Text = String.Empty;
        }

        private void insertSetting(string key)
        {
            // Create a new to-do item based on the text box.
            //var newSetting = new Settings { Key = key, Value = "Waarde" };
            var newSetting = new Settings(); 
            newSetting.Key = key;
            newSetting.Value = "Waarde";

            // Add a to-do item to the observable collection.
            this.SettingItems.Add(newSetting);

            // Add a to-do item to the local database.
            this.easyListDb.Settings.InsertOnSubmit(newSetting);
        }

        private void newToDoAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.insertSetting("");
        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                //// Get a handle for the to-do item bound to the button.
                //Settings toDoForDelete = button.DataContext as Settings;

                //// Remove the to-do item from the observable collection.
                //ToDoItems.Remove(toDoForDelete);

                //// Remove the to-do item from the local database.
                //toDoDB.ToDoItems.DeleteOnSubmit(toDoForDelete);

                //// Save changes to the database.
                //toDoDB.SubmitChanges();

                // Put the focus back to the main page.
                this.Focus();
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Call the base method.
            base.OnNavigatedFrom(e);

            // Save changes to the database.
            this.easyListDb.SubmitChanges();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public ObservableCollection<Settings> SettingItems
        {
            get
            {
                return this.settingItems;
            }
            set
            {
                if (this.settingItems != value)
                {
                    this.settingItems = value;
                    this.NotifyPropertyChanged("SettingItems");
                }
            }
        }
    }
}