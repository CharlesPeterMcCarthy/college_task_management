using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditTaskPage.xaml
    /// </summary>
    public partial class EditTaskPage : Page {

        public Task Task { get; set; }

        public EditTaskPage() {
            InitializeComponent();
        }

        public EditTaskPage(Task t): this() {
            Task = t;

            editTaskGrid.DataContext = Task;

            SetComboBoxes();
        }

        private void SetComboBoxes() {
            cbxCategory.ItemsSource = Enum.GetNames(typeof(Category));
            cbxPriority.ItemsSource = Enum.GetNames(typeof(Priority));
        }

    }
}
