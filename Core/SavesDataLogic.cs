using Rain_save_manager.Model;
using System.IO;
using System.Collections.Generic;

namespace Rain_save_manager.Core
{
    public static class SavesDataLogic
    {
        public static void VerifyInvalidSaves()
        {
            int exist = 0;
            for (int i = 0; i <= LoadData.savesData.Saves.Count; i++)
            {
                if (i >= LoadData.savesData.Saves.Count)
                    break;
                if (exist == 0 && i != 0)
                    i--;
                if (!File.Exists(Path.Combine(App.appsaves, $"sav-{LoadData.savesData.Saves[i].saveId}")))
                {
                    LoadData.savesData.Saves.Remove(LoadData.savesData.Saves[i]);
                    if (i != 0)
                        i--;
                }
                else
                    exist++;
            }
        }
        public static SaveData FindSaveDataForId(int id)
        {
            for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            {
                if (LoadData.savesData.Saves[i].saveId == id)
                    return LoadData.savesData.Saves[i];
            }

            throw new KeyNotFoundException($"El id: '{id}' no fue encontrado en la lista.");
        }
        public static int FindSaveDataForIdInSaves(int id)
        {
            for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            {
                if (LoadData.savesData.Saves[i].saveId == id)
                    return i;
            }

            throw new KeyNotFoundException($"El elemento con el id: '{id}' no fue encontrado en la lista.");
        }
        public static int GetMaxIdInSaves()
        {
            if (LoadData.savesData.Saves.Count == 0)
                return -1;

            if (LoadData.savesData.Saves.Count == 1)
                return LoadData.savesData.Saves[0].saveId;

            int maxId = 0;
            for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            {
                if (maxId < LoadData.savesData.Saves[i].saveId)
                    maxId = LoadData.savesData.Saves[i].saveId;
            }
            return maxId;
        }
    }
}
