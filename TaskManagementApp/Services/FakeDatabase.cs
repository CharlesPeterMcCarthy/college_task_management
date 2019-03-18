using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services {
    public static class FakeDatabase {
        
        public static List<Task> GetTasks() {
            return new List<Task>();
        }

    }
}
