using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp.Models {
    public class TaskManager {
        public ObservableCollection<Task> Tasks { get; private set; }

        public TaskManager(List<Task> tasks) {
            Tasks = new ObservableCollection<Task>(tasks);
        }

        public void AddTask(Task t) => Tasks.Add(t);

        public void DeleteTask(Task t) => Tasks.Remove(t);
    }
}
