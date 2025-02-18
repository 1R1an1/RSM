using Rain_save_manager.Scripts.ConfigObj;
#if DEBUG
using FortiCrypts;
using System;
#endif
using System.Collections.Generic;
using System.IO;

namespace Rain_save_manager.Scripts.SystemsScripts
{
    public static class LoadData
    {
        public static SavesData savesData;
        public static void Start()
        {
            ComprobarData<SavesData>(out var result);
            savesData = result;

            int exist = 0;
            for (int i = 0; i <= savesData.Saves.Count; i++)
            {
                if (i >= savesData.Saves.Count)
                    break;
                if (exist == 0 && i != 0)
                    i--;
                if (!File.Exists($"{App.appsaves}sav-{savesData.Saves[i].saveId}"))
                {
                    savesData.Saves.Remove(savesData.Saves[i]);
                    if (i != 0)
                        i--;
                }
                else
                    exist++;
            }

            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
            #if DEBUG
            Console.WriteLine(AES128.Decrypt(File.ReadAllText(Path.Combine(App.appconfig, SavesData.fileName + ".rsm")), CryptoUtils.defaultPassword));
            #endif

        }

        public static void Close()
        {
            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
        }

        private static void ComprobarData<T>(out T result) where T : ConfigBehaviour, new ()
        {
            try { result = ConfigSystem.ReadConfigFile<T>(); }
            catch (FileNotFoundException) { result = new T(); ConfigSystem.WriteConfigFile(typeof(T).Name, result); }
        }

        public static SaveData FindSaveDataForId(int id)
        {
            for (int i = 0; i < savesData.Saves.Count; i++)
            {
                if (savesData.Saves[i].saveId == id)
                    return savesData.Saves[i];
            }

            throw new KeyNotFoundException($"El id: '{id}' no fue encontrado en la lista.");
        }

        public static int FindSaveDataForIdInSaves(int id)
        {
            for (int i = 0; i < savesData.Saves.Count; i++)
            {
                if (savesData.Saves[i].saveId == id)
                    return i;
            }

            throw new KeyNotFoundException($"El elemento con el id: '{id}' no fue encontrado en la lista.");
        }
    }
}
