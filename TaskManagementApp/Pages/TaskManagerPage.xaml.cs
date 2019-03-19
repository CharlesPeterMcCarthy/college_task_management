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
        public enum FilterType {
            None,
            Title,
            Description
        }
        public enum SortTypes {
            Category,
            Priority,
            DueDate,
            Labels
        }
        private FilterType filterType = FilterType.None;
        private object filterValue;

        public TaskManagerPage() => InitializeComponent();

        public TaskManagerPage(TaskManager tm) : this() {
            TaskManager = tm;
            RefreshTasks();

            cbxSortTasks.ItemsSource = Enum.GetNames(typeof(SortTypes));
        }

        private void RefreshTasks() {
            Console.WriteLine(filterValue);
            Console.WriteLine(filterType);
            Tasks = new ObservableCollection<Task>(
                filterType == FilterType.None ?
                TaskManager.Tasks :
                TaskManager.Tasks.Where(t => t[filterType.ToString()] == filterValue)
            );

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
            FilterTasks(FilterType.Title, searchString);
        }

        private void FilterTasks(FilterType ft, object fv) {
            filterType = ft;
            filterValue = fv;
            RefreshTasks();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e) {
            bool isChecked = (bool)(sender as CheckBox).IsChecked;
            Tasks.Clear();
            foreach (Task t in TaskManager.Tasks) if (isChecked && !t.IsComplete || !isChecked) Tasks.Add(t);
        }

        private void CbxSortTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string field = ((ComboBox)sender).SelectedItem.ToString();

            Tasks = field == "Labels" ?
                new ObservableCollection<Task>(Tasks.ToList().OrderBy(t => ((string[])t[field]).Count())) :
                new ObservableCollection<Task>(Tasks.ToList().OrderBy(t => t[field]));
            
            lbxTasks.ItemsSource = Tasks;
        }
    }
}
