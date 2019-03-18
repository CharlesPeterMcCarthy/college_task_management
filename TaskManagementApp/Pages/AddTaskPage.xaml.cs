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
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages {
    /// <summary>
    /// Interaction logic for AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page {

        public TaskManager TaskManager { get; set; }

        public AddTaskPage() {
            InitializeComponent();

            SetComboBoxes();
        }

        public AddTaskPage(TaskManager tm): this() =>  TaskManager = tm;

        private void SetComboBoxes() {
            cbxCategory.ItemsSource = Enum.GetNames(typeof(Category));
            cbxPriority.ItemsSource = Enum.GetNames(typeof(Priority));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) {
            string title = txtbxTitle.Text;
            string desc = txtbxDescription.Text;
            string responsibility = txtbxResponsbility.Text;
            string[] labels = txtbxLabels.Text.Split(',').Select(l => l.Trim()).ToArray();
            Category category = GetCatgeory();
            Priority priority = GetPriority();
            DateTime dueDate = dtpkDueDate.SelectedDate.Value.Date;

            SaveNewTask(
                responsibility.Length > 0 ?
                new Models.Task(title, desc, category, priority, dueDate, responsibility, labels) :
                new Models.Task(title, desc, category, priority, dueDate, labels)
            );
        }

        private Category GetCatgeory() => (Category)cbxCategory.SelectedIndex;

        private Priority GetPriority() => (Priority)cbxPriority.SelectedIndex;

        private void SaveNewTask(Models.Task t) => TaskManager.AddTask(t);

    }
}
