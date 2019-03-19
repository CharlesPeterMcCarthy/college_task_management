using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagementApp.Models;

namespace TaskManagementApp.Pages {
    /// <summary>
    /// Interaction logic for TaskManagerPage.xaml
    /// </summary>
    public partial class TaskManagerPage : Page {

        public TaskManager TaskManager { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }

        public TaskManagerPage() => InitializeComponent();

        public TaskManagerPage(TaskManager tm) : this() {
            TaskManager = tm;
            Tasks = new ObservableCollection<Task>(TaskManager.Tasks);

            lbxTasks.ItemsSource = Tasks;
        }

        private void LbxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) => NavigationService.Navigate(new ViewTaskPage(((ListBox)sender).SelectedItem as Models.Task));
        
        private void AssignPopup(object sender, RoutedEventArgs e) {
            
        }

        private void AssignTask(object sender, RoutedEventArgs e) {
        }

        private void CompleteTask(object sender, RoutedEventArgs e) {
            Task t = ((ListBoxItem)lbxTasks.ContainerFromElement((Button)sender)).Content as Models.Task;
            t.CompleteTask();
            TaskManager.UpdateTasks();
        }

        private void DeleteTask(object sender, RoutedEventArgs e) {
            Task t = ((ListBoxItem)lbxTasks.ContainerFromElement((Button)sender)).Content as Models.Task;
            TaskManager.DeleteTask(t);
        }

        private void SearchTasks(object sender, RoutedEventArgs e) {
            string searchString = tbxSearch.Text;
            Tasks.Clear();
            foreach (Task t in TaskManager.Tasks) if (t.Title.Contains(searchString)) Tasks.Add(t);
        }
    }
}
