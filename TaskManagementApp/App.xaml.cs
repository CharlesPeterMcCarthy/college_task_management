using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManagementApp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        SplashScreen ss = new SplashScreen("Images/csharp.png");

        void App_Startup(object sender, StartupEventArgs e) {
            ss.Show(false);
            Thread.Sleep(4000);
            ss.Close(new TimeSpan(2000));
        }
    }
}
