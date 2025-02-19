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
            lbl.MouseDoubleClick += RemplazarSave_Click;
            return lbl;
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





        private void RemplazarSave()
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.ReplaceSave);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
                System.Console.WriteLine(renameSave.texto);
        }
        private void CambiarNombreSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.RenemeSaves);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
            {
                Console.WriteLine(renameSave.texto);

                SaveData save = SavesDataLogic.FindSaveDataForId(id);
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
            int save = SavesDataLogic.FindSaveDataForIdInSaves(id);
            LoadData.savesData.Saves.RemoveAt(save);

            for (int i = 0; i < lblSaves.Count; i++)
            {
                if (lblSaves[i].Name.Split(char.Parse("_"))[1] == id.ToString())
                {
                    SP_saves.Children.Remove(lblSaves[i]);
                    lblSaves.RemoveAt(i);
                    File.Delete(Path.Combine(App.appsaves, "sav-" + id));
                    return;
                }
            }
        }
        private void CopiarSave(Enums.Save save)
        {
            OtherWindows window = new OtherWindows(Enums.OWT.RenemeSaves);
            bool? result = window.ShowDialog();

            if (result == true)
            {
                int maxId = SavesDataLogic.GetMaxIdInSaves();
                int Id = maxId + 1;

                SavesSystem.CopySaveFile("sav" + (save.ToString().Split(char.Parse("_"))[1] == "1" ? "" : save.ToString().Split(char.Parse("_"))[1]), $"sav-{Id}", out bool Replace);
                if (Replace)
                {
                    bool resudlt = msbRemplazarArchivo();
                    if (!resudlt)
                        return;
                    SavesSystem.CopySaveFile("sav" + (save.ToString().Split(char.Parse("_"))[1] == "1" ? "" : save.ToString().Split(char.Parse("_"))[1]), $"sav-{Id}", true);
                }

                LoadData.savesData.Saves.Add(new SaveData(window.texto, Id));
                Label lbl = CreateSaveLabel(LoadData.savesData.Saves[SavesDataLogic.FindSaveDataForIdInSaves(Id)]);
                lblSaves.Add(lbl);
                SP_saves.Children.Add(lbl);
                return;
            }
        }
        private bool msbRemplazarArchivo() => MessageBox.Show("Replazar archivo?", "replazar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;


        private void RemplazarSave_Click(object sender, MouseButtonEventArgs e) => RemplazarSave();
        private void CambiarNombre_Click(object sender, RoutedEventArgs e, int id) => CambiarNombreSave(id);
        private void Eliminar_Click(object sender, RoutedEventArgs e, int id) => EliminarSave(id);


        private void btn_cpysave1_Click(object sender, RoutedEventArgs e) => CopiarSave(Enums.Save.Save_1);
        private void btn_cpysave2_Click(object sender, RoutedEventArgs e) => CopiarSave(Enums.Save.Save_2);
        private void btn_cpysave3_Click(object sender, RoutedEventArgs e) => CopiarSave(Enums.Save.Save_3);


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
    }
}
