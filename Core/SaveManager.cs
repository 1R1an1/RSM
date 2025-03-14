﻿using Rain_save_manager.Model;
using Rain_save_manager.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Rain_save_manager.Core
{
    public class SaveManager
    {
        public void RemplazarSave(int id)
        {
            OtherWindows replaceSave = new OtherWindows(Enums.OWT.ReplaceSave);

            bool? resultado = replaceSave.ShowDialog();
            if (resultado == true)
            {
                string file = "sav-" + id;
                string filedest = ((int)replaceSave.save).ToString();
                File.Copy(Path.Combine(App.appsaves, file), Path.Combine(App.rainworldsaves, "sav" + (filedest == "1" ? "" : filedest)), true);
                MessageBox.Show("Archivo utilizado en la ranura: " + filedest, "informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void ActualizarSave(int id)
        {
            OtherWindows updateSave = new OtherWindows(Enums.OWT.ReplaceSave, "Actualizar partida");

            bool? resultado = updateSave.ShowDialog();
            if (resultado == true)
            {
                string file = "sav-" + id;
                string filereference = ((int)updateSave.save).ToString();
                File.Copy(Path.Combine(App.rainworldsaves, "sav" + (filereference == "1" ? "" : filereference)), Path.Combine(App.appsaves, file), true);
                MessageBox.Show("Archivo actualizado", "informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void CambiarNombreSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.RenemeSaves);
            renameSave.CDU_RENS.txtDato.Text = LoadData.savesData.Saves[id].saveName;

            bool? resultado = renameSave.ShowDialog();
            if (resultado == true)
            {
                SaveData save = SavesDataLogic.FindSaveDataForId(id);
                save.saveName = (renameSave.texto.Trim().Length == 0 ? "partida-" + id : renameSave.texto);
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

                SaveData savee = new SaveData((window.texto.Trim().Length == 0 ? "partida-" + Id : window.texto), "sav-" + Id);
                LoadData.savesData.Saves.Add(Id, savee);
                return new KeyValuePair<int, SaveData>(Id, savee);
            }
            return new KeyValuePair<int, SaveData>();
        }
        public bool EliminarSaves()
        {
            if (MessageBox.Show("¡Cambios irreversibles! \n ¿Continuar?", "ADVERTENCIA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            Directory.Delete(App.appsaves, true);
            Directory.CreateDirectory(App.appsaves);

            LoadData.savesData = new SavesData();
            return true;
        }
        public void VerInfoSave(int id)
        {
            Dictionary<Enums.RainWorldCharacter, RWsaveData> saveData = RWreadSaves.ReadSaveData(Path.Combine(App.appsaves, LoadData.savesData.Saves[id].saveFileName), true);
            InfoWindow infoWindow = new InfoWindow();
            List<string> text = new List<string>();
            int u = 0;
            foreach (var item in saveData)
            {
                u++;
                text.Add($"SlugCat: {item.Key.ToString()}" +
                         $"\nCiclo: {item.Value.CycleNumber}" +
                         $"\nKarma Actual: {item.Value.KarmaLevel}" +
                         $"\nKarma maximo: {item.Value.KarmaCap}" +
                         $"\nFlor de karma: {(item.Value.ReinforcedKarma == false ? "desactivado" : "activado")}" +
                         //$"\nTiempo jugado en partida: {TimeSpan.FromSeconds(item.Value.TotalTime).Hours}:{TimeSpan.FromSeconds(item.Value.TotalTime).Minutes}:{TimeSpan.FromSeconds(item.Value.TotalTime).Seconds}" +
                         $"\nTiempo jugado en partida: {(item.Value.TotalTime / 3600):D2}:{((item.Value.TotalTime % 3600) / 60):D2}:{(item.Value.TotalTime % 60):D2}" +
                         $"\nNumero de muertes: {item.Value.Deaths}" +
                         $"{(u < saveData.Count ? "\n\n" : "")}");
            }
            string texts = "";
            for (int i = 0; i < text.Count; i++)
            {
                texts += text[i];
            }
            infoWindow.ShowText(texts);
            infoWindow.ShowDialog();
        }
        private bool msbRemplazarArchivo() => MessageBox.Show("Replazar archivo?", "replazar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;
    }
    
}
