using Rain_save_manager.Scripts.ConfigObj;
using System;
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
        }

        public static void Close()
        {
            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
        }

        private static void ComprobarData<T>(out T result) where T : ConfigBehaviour
        {
            try { result = ConfigSystem.ReadConfigFile<T>(); }
            catch (FileNotFoundException) { result = (T)Activator.CreateInstance(typeof(T)); ConfigSystem.WriteConfigFile(typeof(T).Name, result); }
        }
    }
}
