using Rain_save_manager.Model;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Rain_save_manager.Core
{
    public static class SavesDataLogic
    {
        public static void VerifyInvalidSaves()
        {
            List<int> keysToRemove = new List<int>();

            foreach (KeyValuePair<int, SaveData> dicctionary in LoadData.savesData.Saves)
            {
                if (!File.Exists(Path.Combine(App.appsaves, dicctionary.Value.saveFileName)))
                {
                    keysToRemove.Add(dicctionary.Key);
                }
            }

            if (keysToRemove.Count == 0)
                return;

            for (int i = 0; i < keysToRemove.Count; i++)
            {
                LoadData.savesData.Saves.Remove(keysToRemove[i]);
            }
        }
        public static SaveData FindSaveDataForId(int id)
        {
            if (LoadData.savesData.Saves.TryGetValue(id, out SaveData saveData))
                return saveData;

            throw new KeyNotFoundException($"El id: '{id}' no fue encontrado en la lista.");
        }
        public static int GetMaxIdInSaves()
        {
            if (LoadData.savesData.Saves.Count == 0)
                return -1;

            return LoadData.savesData.Saves.Keys.Max();
        }
    }
}
