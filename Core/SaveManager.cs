using Rain_save_manager.Model;
using Rain_save_manager.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Rain_save_manager.Core
{
    public class SaveManager
    {
        public void RemplazarSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.ReplaceSave);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
            {
                string file = "sav-" + id;
                string filedest = ((int)renameSave.save).ToString();
                File.Copy(App.appsaves, Path.Combine(Path.Combine(App.appsaves, file), "sav" + (filedest == "1" ? "" : filedest)), true);
            }
        }
        public void CambiarNombreSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.RenemeSaves);

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
            {
#if DEBUG
                Console.WriteLine(renameSave.texto);
#endif
                SaveData save = SavesDataLogic.FindSaveDataForId(id);
                save.saveName = renameSave.texto;
            }
        }
        public void EliminarSave(int id)
        {
            File.Delete(Path.Combine(App.appsaves, LoadData.savesData.Saves[id].saveFileName));
            LoadData.savesData.Saves.Remove(id);
        }
        public KeyValuePair<int, SaveData> CopiarSave(Enums.Save save)
        {
            OtherWindows window = new OtherWindows(Enums.OWT.RenemeSaves, "Nombre de partida");
            bool? result = window.ShowDialog();

            if (result == true)
            {
                int maxId = SavesDataLogic.GetMaxIdInSaves();
                int Id = maxId + 1;

                SavesSystem.CopySaveFile("sav" + (((int)save).ToString() == "1" ? "" : ((int)save).ToString()), $"sav-{Id}", out bool Replace);
                if (Replace)
                {
                    bool resudlt = msbRemplazarArchivo();
                    if (!resudlt)
                        return new KeyValuePair<int, SaveData>();
                    SavesSystem.CopySaveFile("sav" + (((int)save).ToString() == "1" ? "" : ((int)save).ToString()), $"sav-{Id}", true);
                }

                SaveData savee = new SaveData(window.texto, "sav-" + Id);
                LoadData.savesData.Saves.Add(Id, savee);
                return new KeyValuePair<int, SaveData>(Id, savee);
            }
            return new KeyValuePair<int, SaveData>();
        }
        public void EliminarSaves()
        {
            if (MessageBox.Show("¡Cambios irreversibles! \n ¿Continuar?", "ADVERTENCIA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            Directory.Delete(App.appsaves, true);
            Directory.CreateDirectory(App.appsaves);
            LoadData.savesData = new SavesData();
        }
        private bool msbRemplazarArchivo() => MessageBox.Show("Replazar archivo?", "replazar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;
    }
    
}
