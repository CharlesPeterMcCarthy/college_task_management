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
    /// Interaction logic for ViewTaskPage.xaml
    /// </summary>
    public partial class ViewTaskPage : Page {

        public Task Task { get; set; }

        public ViewTaskPage() => InitializeComponent();

        public ViewTaskPage(Task t) : this() {
            Task = t;
            taskGrid.DataContext = Task;
        }

    }
}
