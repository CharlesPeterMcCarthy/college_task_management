using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp.Models { 
    public enum Priority {
        High,
        Medium,
        Low
    }

    public enum Category {
        ShopFloor,
        StockRoom,
        LoadingBay,
        Management
    }

    public class Task: INotifyPropertyChanged {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        private string _responsibility;
        public string Responsibility {
            get { return _responsibility; }
            set {
                _responsibility = value;
                RaisePropertyChanged("Responsibility");
            }
        }
        public string[] Labels { get; set; }
        private bool _isComplete;
        public bool IsComplete {
            get { return _isComplete; }
            set {
                _isComplete = value;
                RaisePropertyChanged("IsComplete");
            }
        }

        public string DueDateReadable { get { return DueDate.ToShortDateString(); } }
        public string LabelsString { get { return string.Join(", ", Labels); } }

        public object this[string propertyName] {
            get => typeof(Task).GetProperty(propertyName).GetValue(this, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task() {}

        public Task(string title, string description, Category category,
            Priority priority, DateTime dueDate, string responsibility, string[] labels): this(title, description, category, priority, dueDate, labels) {
            Responsibility = responsibility;
        }

        public Task(string title, string description, Category category,
            Priority priority, DateTime dueDate, string[] labels) {
            Title = title;
            Description = description;
            Category = category;
            Priority = priority;
            DueDate = dueDate;
            Labels = labels;
        }

        public void CompleteTask() => IsComplete = true;

        public void AssignResponsibility(string name) => Responsibility = name;

    }
}
