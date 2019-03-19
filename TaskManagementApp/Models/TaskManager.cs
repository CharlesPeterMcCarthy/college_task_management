using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApp.Services;

namespace TaskManagementApp.Models {
    public class TaskManager {
        public List<Task> Tasks { get; private set; }

        public TaskManager(List<Task> tasks) {
            Tasks = tasks;
            //Tasks = new ObservableCollection<Task>(tasks);
        }

        public void AddTask(Task t) {
            Tasks.Add(t);
            UpdateTasks();
        }

        public void DeleteTask(Task t) {
            Tasks.Remove(t);
            UpdateTasks();
        }

        public void UpdateTasks() {
            Console.WriteLine(Tasks[0].IsComplete);
            FakeDatabase.SaveTask(Tasks.ToList());
        }
    }
}
