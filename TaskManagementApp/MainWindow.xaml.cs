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
using TaskManagementApp.Pages;
using TaskManagementApp.Services;

namespace TaskManagementApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public TaskManager TaskManager { get; set; }

        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            TaskManager = new TaskManager(FakeDatabase.GetTasks());
            SetHeadingText("Tasks");

            NavigateHome();
        }

        private void SetHeadingText(string heading) => txtBlkHeading.Text = heading;

        private void TxtBlkTasks_Click(object sender, RoutedEventArgs e) => NavigateHome();

        private void TxtBlkAddTask_Click(object sender, RoutedEventArgs e) => NavigateAddTask();

        private void NavigateHome() => mainFrame.NavigationService.Navigate(new TaskManagerPage());

        private void NavigateAddTask() => mainFrame.NavigationService.Navigate(new AddTaskPage());

    }
}
