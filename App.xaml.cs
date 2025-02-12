using Rain_save_manager.Scripts.ConfigObj;
using Rain_save_manager.Scripts.SystemsScripts;
using System;
using System.IO;
using System.Windows;

namespace Rain_save_manager
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow window;

        public readonly static string rainworldsaves = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\..\\LocalLow\\Videocult\\Rain World";
        public readonly static string appconfig = $"{rainworldsaves}\\RSM\\Config";
        public readonly static string appsaves = $"{rainworldsaves}\\RSM\\Saves";
        public readonly static string appRSM = $"{rainworldsaves}\\RSM";

        protected override void OnStartup(StartupEventArgs e)
        {
            window = new MainWindow();
            MainWindow = window;
            MainWindow.Show();
            window.borde.Visibility = Visibility.Visible;

            FilesSystem.WriteFile(FilesSystem.RSMD.Config, "wa", new ConfigPrueba(false, "awdwad", 1234));
            Console.WriteLine(FilesSystem.ReadFile(FilesSystem.RSMD.Config, "wa"));
            Console.WriteLine(FilesSystem.ReadFile(FilesSystem.RSMD.Saves, "wa"));

            if (!Directory.Exists(appconfig)) Directory.CreateDirectory(appconfig);
            if (!Directory.Exists(appsaves)) Directory.CreateDirectory(appsaves);
            //reference windoww = new reference();
            ////MainWindow = windoww;
            //windoww.Show();
        }
    }
}
