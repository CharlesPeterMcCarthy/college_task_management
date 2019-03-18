using System;
using System.Collections.Generic;
using System.Linq;
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

    public class Task {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { private get; set; }
        public string Responsibility { get; set; }
        public string[] Labels { private get; set; }
        public bool IsComplete { get; set; }

        public string DueDateReadable { get { return DueDate.ToShortDateString(); } }
        public string LabelsString { get { return string.Join(", ", Labels); } }

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
