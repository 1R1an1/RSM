using Rain_save_manager.Model;
using Rain_save_manager.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Rain_save_manager.Core
{
    public class SaveManager
    {
        public void RemplazarSave(int id)
        {
            OtherWindows replaceSave = new OtherWindows(Enums.OWT.ReplaceSave);

            bool? resultado = replaceSave.ShowDialog();
            if (resultado == false)
                return;

            string filedest = ((int)replaceSave.save).ToString();
            File.WriteAllText(Path.Combine(App.rainworldsaves, "sav" + (filedest == "1" ? "" : filedest)), LoadData.savesData[id].Content);
            MessageBox.Show("Archivo utilizado en la ranura: " + filedest, "informacion", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public void ActualizarSave(int id)
        {
            OtherWindows updateSave = new OtherWindows(Enums.OWT.ReplaceSave, "Actualizar partida");

            bool? resultado = updateSave.ShowDialog();
            if (resultado == false)
                return;

            string filereference = ((int)updateSave.save).ToString();
            string fileContent = File.ReadAllText(Path.Combine(App.rainworldsaves, "sav" + (filereference == "1" ? "" : filereference)));
            LoadData.savesData[id].Content = fileContent;

            SavesSystem.WriteSaveFile(LoadData.savesData[id]);

            MessageBox.Show("Archivo actualizado", "informacion", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public void CambiarNombreSave(int id)
        {
            OtherWindows renameSave = new OtherWindows(Enums.OWT.RenemeSaves);
            renameSave.CDU_RENS.txtDato.Text = LoadData.savesData[id].VisualName;

            bool? resultado = renameSave.ShowDialog();
            if (resultado == false)
                return;

            SaveData save = LoadData.savesData[id];
            save.VisualName = (renameSave.texto.Trim().Length == 0 ? "partida-" + id : renameSave.texto);
            SavesSystem.WriteSaveFile(LoadData.savesData[id]);
        }
        public void EliminarSave(int id)
        {
            File.Delete(Path.Combine(App.appsaves, LoadData.savesData[id].FileName));
            File.Delete(Path.Combine(App.appsaves, LoadData.savesData[id].FileName + "2.json"));
            LoadData.savesData.Remove(id);
        }
        public KeyValuePair<int, SaveData> CopiarSave(Enums.Save save)
        {
            OtherWindows window = new OtherWindows(Enums.OWT.RenemeSaves, "Nombre de partida");
            bool? result = window.ShowDialog();

            if (result == false)
                return new KeyValuePair<int, SaveData>();

            Dictionary<int, SaveData> keys = LoadData.savesData;
            int Id = (keys.Count == 0 ? -1 : keys.Keys.Max()) + 1;

            SaveData savee = new SaveData()
            {
                Id = Id,
                VisualName = (window.texto.Trim().Length == 0 ? "partida-" + Id : window.texto),
                FileName = "sav-" + Id + ".rsm",
                Content = File.ReadAllText(Path.Combine(App.rainworldsaves, "sav" + (((int)save) == 1 ? "" : ((int)save).ToString())))
            };

            SavesSystem.WriteSaveFile(savee);

            LoadData.savesData.Add(Id, savee);
            return new KeyValuePair<int, SaveData>(Id, savee);
        }
        
        public bool EliminarSaves()
        {
            if (MessageBox.Show("¡Cambios irreversibles! \n ¿Continuar?", "ADVERTENCIA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            Directory.Delete(App.appsaves, true);
            Directory.CreateDirectory(App.appsaves);

            LoadData.savesData = new Dictionary<int, SaveData>();
            return true;
        }
        public void VerInfoSave(int id)
        {
            Dictionary<Enums.RainWorldCharacter, RWsaveData> saveData = RWreadSaves.ReadSaveData(LoadData.savesData[id].Content, false);
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
                         $"\nTiempo jugado en partida: {(item.Value.TotalTime / 3600):D3}:{((item.Value.TotalTime % 3600) / 60):D2}:{(item.Value.TotalTime % 60):D2}" +
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
