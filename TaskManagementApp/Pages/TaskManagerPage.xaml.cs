using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public TaskManagerPage() => InitializeComponent();

        public TaskManagerPage(TaskManager tm) : this() {
            TaskManager = tm;

            lbxTasks.ItemsSource = TaskManager.Tasks;
        }

        private void LbxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) => NavigationService.Navigate(new ViewTaskPage(((ListBox)sender).SelectedItem as Models.Task));
        
    }
}
