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
using System.ComponentModel;
using System.Collections.ObjectModel;
using EasyList.Models;
using EasyList.Models.Interfaces;
using EasyList.Models.BaseModels;
using EasyList.ViewModels;
using EasyList.ViewModels.Interfaces;

namespace EasyList
{
    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        // Event used to indicate whether any properties were changed or not.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data context for the local database
        private EasyListDataContext easyListDb;

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<SettingsTable> settingItems;
        
        // Constructor
        public MainPage()
        {
            this.InitializeComponent();

            // Set event listener for XAML Control with Name="Panorama".
            this.Panorama.SelectionChanged += this.Panorama_SelectionChanged;

            // Connect to the database and instantiate data context.
            this.easyListDb = new EasyListDataContext(EasyListDataContext.DBConnectionString);

            // Data context and observable collection are children of the main page.
            // Note: Ehhhhh, why we do this?
            //this.DataContext = this;

            // Set the data context of the listbox control to the App's default ViewModel.
            var viewModel = new MainViewModel(this.easyListDb.GetSettings());
            App.ViewModel = viewModel;
            this.DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        /// <summary>
        /// This function is called when the panorama view has changed. This allows us to take action when that happens.
        /// For instance to change the Application Bar to suit the needs of the new view.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// /// <param name="e">Event args.</param>
        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = this.Panorama.SelectedIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Define the query to gather all of the to-do items.
            var settingItemsInDb =  from    SettingsTable settings 
                                    in      this.easyListDb.Settings
                                    select  settings;

            // Execute the query and place the results into a collection.
            this.SettingItems = new ObservableCollection<SettingsTable>(settingItemsInDb);

            // Call the base method.
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToDoTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text box when it gets focus.
            //newToDoTextBox.Text = String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void insertSetting(string key)
        {
            // Create a new to-do item based on the text box.
            //var newSetting = new Settings { Key = key, Value = "Waarde" };
            var newSetting = new SettingsTable(); 
            newSetting.Key = key;
            newSetting.Value = "Waarde";

            // Add a to-do item to the observable collection.
            this.SettingItems.Add(newSetting);

            // Add a to-do item to the local database.
            this.easyListDb.Settings.InsertOnSubmit(newSetting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToDoAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.insertSetting("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Call the base method.
            base.OnNavigatedFrom(e);

            // Save changes to the database.
            this.easyListDb.SubmitChanges();
        }

        /// <summary>
        /// Load data for the ViewModel Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        /// <summary>
        /// Used to notify Silverlight that a property has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
 
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<SettingsTable> SettingItems
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