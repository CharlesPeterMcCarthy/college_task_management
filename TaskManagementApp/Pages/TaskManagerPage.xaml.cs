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

        public enum SortTypes {
            Category,
            Priority,
            DueDate,
            Labels
        }

        public TaskManagerPage() => InitializeComponent();

        public TaskManagerPage(TaskManager tm) : this() {
            TaskManager = tm;
            RefreshTasks(TaskManager.Tasks);

            cbxSortTasks.ItemsSource = Enum.GetNames(typeof(SortTypes));
        }

        private void RefreshTasks(ObservableCollection<Task> tasks) {
            Tasks = new ObservableCollection<Task>(tasks);
            lbxTasks.ItemsSource = Tasks;
        }

        private void LbxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) => NavigationService.Navigate(new ViewTaskPage(((ListBox)sender).SelectedItem as Models.Task));

        private void CompleteTask(object sender, RoutedEventArgs e) {
            Task t = ((ListBoxItem)lbxTasks.ContainerFromElement((Button)sender)).Content as Models.Task;
            t.CompleteTask();
            TaskManager.UpdateTasks();
        }

        private void EditTask(object sender, RoutedEventArgs e) => NavigationService.Navigate(new EditTaskPage(((ListBoxItem)lbxTasks.ContainerFromElement((Button)sender)).Content as Task));
        
        private void DeleteTask(object sender, RoutedEventArgs e) {
            Task t = ((ListBoxItem)lbxTasks.ContainerFromElement((Button)sender)).Content as Models.Task;
            TaskManager.DeleteTask(t);
            RefreshTasks(TaskManager.Tasks);
        }

        private void SearchTasks(object sender, RoutedEventArgs e) {
            string searchString = tbxSearch.Text;
            tbxSearch.Text = "";
            Tasks.Clear();
            foreach (Task t in TaskManager.Tasks) if (t.Title.Contains(searchString)) Tasks.Add(t);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e) {
            bool isChecked = (bool)(sender as CheckBox).IsChecked;
            Tasks.Clear();
            foreach (Task t in TaskManager.Tasks) if (isChecked && !t.IsComplete || !isChecked) Tasks.Add(t);
        }

        private void CbxSortTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string field = ((ComboBox)sender).SelectedItem.ToString();

            RefreshTasks(
                field == "Labels" ?
                new ObservableCollection<Task>(Tasks.ToList().OrderBy(t => ((string[])t[field]).Count())) :
                new ObservableCollection<Task>(Tasks.ToList().OrderBy(t => t[field]))
            );
        }

        private void CommitChanges(object sender, RoutedEventArgs e) => TaskManager.UpdateTasks();
        
    }
}
