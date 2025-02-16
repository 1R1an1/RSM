using Rain_save_manager.Scripts.ConfigObj;
using Rain_save_manager.Scripts.SystemsScripts;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Rain_save_manager.Views
{
    public partial class Window : UserControl
    {
        public Window()
        {
            InitializeComponent();

            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado0", 1));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado1", 2));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado2", 3));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado3", 4));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado4", 5));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado5", 6));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado6", 7));
            LoadData.savesData.Saves.Add(new SaveData("nombre de guardado7", 8));

            for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            {
                Label lbl = new Label()
                {
                    Style = (Style)FindResource("lblCT"),
                    Content = LoadData.savesData.Saves[i].saveName
                };
                SP_saves.Children.Add(lbl);

                if (lbl.ContextMenu != null)
                {
                    foreach (var item in lbl.ContextMenu.Items)
                    {
                        if (item is MenuItem menuItem)
                        {
                            switch (menuItem.Header.ToString())
                            {
                                case "Cambiar nombre":
                                    menuItem.Click += CambiarNombre_Click;
                                    ;
                                    break;
                                case "Eliminar":
                                    menuItem.Click += Eliminar_Click;
                                    ;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void CambiarNombre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("awdawdawda", "awdawdawdadwaw");
        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("awdawdawda1212313", "awdawdawdadwaw12312312");
        }


        private void Current_Exit(object sender, ExitEventArgs e)
        {
            ConfigSystem.WriteConfigFile(SavesData.fileName, new SavesData(LoadData.savesData.SavesCount));
        }

        private void btn_cpysave1_Click(object sender, RoutedEventArgs e)
        {
            //SavesSystem.CopySaveFile(App.rainworldsaves, "sav", out bool Replace);
            //if (Replace)
            //    SavesSystem.CopySaveFile(App.rainworldsaves, "sav", msb());

            //ConfigSystem.WriteConfigFile("SavesConfig", new SavesConfig(1));
        }

        private bool msbRemplazarArchivo() { if (MessageBox.Show("Replazar archivo?", "replazar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) return true; else return false; }

        public void holapepe (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("wdawdawd", "awdad");
        }

        private void btn_cpysave2_Click(object sender, RoutedEventArgs e)
        {
            //SavesSystem.CopySaveFile(App.rainworldsaves, "sav2", out bool Replace);
            //if (Replace)
            //    SavesSystem.CopySaveFile(App.rainworldsaves, "sav2", msb());
        }

        private void btn_cpysave3_Click(object sender, RoutedEventArgs e)
        {
            LoadData.savesData.SavesCount++;
            SavesSystem.CopySaveFile(App.rainworldsaves, "sav3", $"sav-3-{LoadData.savesData.SavesCount}", out bool Replace);
            if (Replace)
                SavesSystem.CopySaveFile(App.rainworldsaves, "sav3", $"sav-3-{LoadData.savesData.SavesCount}", msbRemplazarArchivo());

        }

        private void btn_deletallsaves_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¡Cambios irreversibles! \n ¿Continuar?", "ADVERTENCIA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            Directory.Delete(App.appsaves, true);
            Directory.CreateDirectory(App.appsaves);
            LoadData.savesData.SavesCount = 0;
            //ConfigSystem.WriteConfigFile(SavesData.fileName, new SavesData(0));


            //private void btn_rutaOB_Click(object sender, System.Windows.RoutedEventArgs e)
            //{
            //    Console.Clear();
            //    //Console.WriteLine($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Videocult\\Rain World");
            //    //Console.WriteLine($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Videocult\\Rain World");
            //    Console.WriteLine(Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Appdata\\LocalLow\\Videocult\\Rain World"));
            //    Console.WriteLine($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\..\\LocalLow\\Videocult\\Rain World");
            //}
        }
    }
}
