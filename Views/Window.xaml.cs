using Rain_save_manager.Core;
using Rain_save_manager.Model;
using Rain_save_manager.Windows;
#if DEBUG
using System;
#endif
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Rain_save_manager.Views
{
    public partial class Window : UserControl
    {
        private List<Label> lblSaves = new List<Label>();
        public Window()
        {
            lblSaves = new List<Label>();
            InitializeComponent();

#if DEBUG
            //btn_deletallsaves_Click(new object(), new RoutedEventArgs());
            LoadData.savesData.Saves.Add(new SaveData("nombre1", 0));
            //LoadData.savesData.Saves.Add(new SaveData("nombre2", 1));
            //LoadData.savesData.Saves.Add(new SaveData("nombre3", 2));
            //LoadData.savesData.Saves.Add(new SaveData("nombre4", 3));
            //LoadData.savesData.Saves.Add(new SaveData("nombre5", 4));
            //LoadData.savesData.Saves.Add(new SaveData("nombre6", 5));
            //LoadData.savesData.Saves.Add(new SaveData("nombre7", 6));
            //LoadData.savesData.Saves.Add(new SaveData("nombre8", 7));
            //LoadData.savesData.Saves.Add(new SaveData("nombre9", 8));
            //LoadData.savesData.Saves.Add(new SaveData("nombre10", 9));
            //LoadData.savesData.Saves.Add(new SaveData("nombre11", 10));
            //LoadData.savesData.Saves.Add(new SaveData("nombre12", 11));
            //LoadData.savesData.Saves.Add(new SaveData("nombre13", 12));
            //LoadData.savesData.Saves.Add(new SaveData("nombre14", 13));
            //LoadData.savesData.Saves.Add(new SaveData("nombre15", 14));
            //LoadData.savesData.Saves.Add(new SaveData("nombre16", 15));
            //LoadData.savesData.Saves.Add(new SaveData("nombre17", 16));
            //LoadData.savesData.Saves.Add(new SaveData("nombre18", 17));
            //LoadData.savesData.Saves.Add(new SaveData("nombre19", 18));
            //LoadData.savesData.Saves.Add(new SaveData("nombre20", 19));
            //for (int i = 0; i < lblSaves.Count; i++)
            //{
            //    Console.WriteLine(lblSaves[i].Name.Split(char.Parse("_"))[1]);
            //}
#endif
            InitializeLabelsSaves();
        }


        private void InitializeLabelsSaves()
        {
            for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            {
                Label lbl = CreateSaveLabel(LoadData.savesData.Saves[i]);

                lblSaves.Add(lbl);
                SP_saves.Children.Add(lbl);
            }
        }
        private Label CreateSaveLabel(SaveData save)
        {
            Label lbl = new Label()
            {
                Name = $"id_{save.saveId}",
                Style = (Style)FindResource("lblS"),
                Content = save.saveName,
                FontSize = 13.5,
                ContextMenu = CreateContextMenu(save.saveId)
            };
            lbl.MouseDoubleClick += holapepepepepepepew;
            return lbl;
        }

        private void holapepepepepepepew(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private ContextMenu CreateContextMenu(int saveId)
        {
            ContextMenu contextMenu = new ContextMenu() { Style = (Style)FindResource("CM") };

            MenuItem renameItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)FindResource("MIUP"),
                Header = "Cambiar nombre"
            };
            renameItem.Click += (s, e) => CambiarNombre_Click(s, e, saveId);

            MenuItem deleteItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)FindResource("MIDOWN"),
                Header = "Eliminar"
            };
            deleteItem.Click += (s, e) => Eliminar_Click(s, e, saveId);

            contextMenu.Items.Add(renameItem);
            contextMenu.Items.Add(deleteItem);
            return contextMenu;
        }

        private void CambiarNombreSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.RenemeSaves);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
            {
                Console.WriteLine(renameSave.texto);

                SaveData save = LoadDataLogic.FindSaveDataForId(id);
                save.saveName = renameSave.texto;

                for (int i = 0; i < lblSaves.Count; i++)
                {
                    if (lblSaves[i].Name.Split(char.Parse("_"))[1] == id.ToString())
                    {
                        lblSaves[i].Content = save.saveName;
                        return;
                    }
                }
            }
        }
        private void EliminarSave(int id)
        {
            int save = LoadDataLogic.FindSaveDataForIdInSaves(id);
            LoadData.savesData.Saves.RemoveAt(save);

            for (int i = 0; i < lblSaves.Count; i++)
            {
                if (lblSaves[i].Name.Split(char.Parse("_"))[1] == id.ToString())
                {
                    SP_saves.Children.Remove(lblSaves[i]);
                    lblSaves.RemoveAt(i);
                    return;
                }
            }
        }


        private void CambiarNombre_Click(object sender, RoutedEventArgs e, int id) => CambiarNombreSave(id);
        private void Eliminar_Click(object sender, RoutedEventArgs e, int id) => EliminarSave(id);




        private bool msbRemplazarArchivo() => MessageBox.Show("Replazar archivo?", "replazar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;

        public void holapepe (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("wdawdawd", "awdad");
        }

        private void btn_cpysave1_Click(object sender, RoutedEventArgs e)
        {
            //SavesSystem.CopySaveFile(App.rainworldsaves, "sav", out bool Replace);
            //if (Replace)
            //    SavesSystem.CopySaveFile(App.rainworldsaves, "sav", msb());

            //ConfigSystem.WriteConfigFile("SavesConfig", new SavesConfig(1));
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
            LoadData.savesData = new SavesData();
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

        private void btn_opennewwindow_Click(object sender, RoutedEventArgs e)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.ReplaceSave);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
                System.Console.WriteLine(renameSave.texto);
        }
    }
}
