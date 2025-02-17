using Rain_save_manager.Scripts.SystemsScripts;
using System;
using System.IO;
using System.Windows;

namespace Rain_save_manager
{
    public partial class App : Application
    {
        public static MainWindow window;

        public readonly static string rainworldsaves = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Appdata", "LocalLow", "Videocult", "Rain World");
        public readonly static string appRSM = Path.Combine(rainworldsaves, "RSM");
        public readonly static string appconfig = Path.Combine(appRSM, "Config");
        public readonly static string appsaves = Path.Combine(appRSM, "Saves");


        protected override void OnStartup(StartupEventArgs e)
        {
            if (!Directory.Exists(appconfig)) Directory.CreateDirectory(appconfig);
            if (!Directory.Exists(appsaves)) Directory.CreateDirectory(appsaves);
            

            LoadData.Start();
            window = new MainWindow();
            MainWindow = window;
            MainWindow.Show();
            App.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, ExitEventArgs e) => LoadData.Close();
    }
}
