using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services {
    public static class FakeDatabase {

        private const string FILE = "database/tasks.json";

        public static List<Task> GetTasks() {
            List<Task> tasks;

            using (StreamReader sr = new StreamReader(FILE)) {
                string json = sr.ReadToEnd();
                tasks = JsonConvert.DeserializeObject<List<Task>>(json);
            }

            return tasks;
        }

        public static void SaveTask(List<Task> tasks) {
            using (StreamWriter sw = File.CreateText(FILE)) {
                JsonSerializer js = new JsonSerializer();

                js.Serialize(sw, tasks);
            }
        }

    }
}
