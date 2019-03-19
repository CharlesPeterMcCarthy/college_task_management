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
        private string _title;
        private string _description;
        private Category _category;
        private Priority _priority;
        private DateTime _dueDate;
        private string _responsibility;
        private bool _isComplete;

        public string Title {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }
        public string Description {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }
        public Category Category {
            get { return _category; }
            set { _category = value; RaisePropertyChanged("Category"); }
        }
        public Priority Priority {
            get { return _priority; }
            set { _priority = value; RaisePropertyChanged("Priority"); }
        }
        public DateTime DueDate {
            get { return _dueDate; }
            set { _dueDate = value; RaisePropertyChanged("DueDate"); RaisePropertyChanged("DueDateReadable"); }
        }
        public string Responsibility {
            get { return _responsibility; }
            set { _responsibility = value; RaisePropertyChanged("Responsibility"); }
        }
        public string[] Labels { get; set; }
        public bool IsComplete {
            get { return _isComplete; }
            set { _isComplete = value; RaisePropertyChanged("IsComplete"); }
        }

        public string DueDateReadable { get { return DueDate.ToShortDateString(); } }
        public string LabelsString {
            get { return string.Join(", ", Labels); }
            set { Labels = value.Split(',').Select(s => s.Trim()).ToArray(); RaisePropertyChanged("Labels"); RaisePropertyChanged("LabelsString"); }
        }

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

    }
}
