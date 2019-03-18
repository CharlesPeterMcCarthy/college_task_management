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
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Responsibility { get; private set; }
        public string[] Labels { get; private set; }
        public bool IsComplete { get; private set; }

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
