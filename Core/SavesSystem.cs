using Rain_save_manager.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rain_save_manager.Core
{
    public static class SavesSystem
    {
        public static void CopySaveFile(string filename, string destfilename, out bool Replace)
        {
            try
            { File.Copy(Path.Combine(App.rainworldsaves, filename), Path.Combine(App.appsaves, destfilename)); Replace = false; }
            catch (IOException) { Replace = true; }
        }

        public static void CopySaveFile(string filename, string destfilename, bool replace) { if (replace) File.Copy(Path.Combine(App.rainworldsaves, filename), Path.Combine(App.appsaves, destfilename), replace); }


        public static void ReadSavesFiles(Dictionary<int, SaveData> data)
        {
            foreach (var item in Directory.GetFiles(App.appsaves))
            {
                if (item.EndsWith("2.json"))
                    continue;
                SaveData save = FilesSystem.ReadFile<SaveData>(Enums.RSMD.Saves, item.Split('\\').Last());
                data.Add(save.Id, save);
            }
        }
        public static void WriteSavesFile(Dictionary<int, SaveData> data)
        {
            foreach (var item in data.Values)
                FilesSystem.WriteFile(Enums.RSMD.Saves, item.FileName, item);
        }

        public static void WriteSaveFile(SaveData data) => FilesSystem.WriteFile(Enums.RSMD.Saves, data.FileName, data);
    }
}
