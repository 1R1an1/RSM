using Rain_save_manager.Model;
using System.IO;

namespace Rain_save_manager.Core
{
    public static class LoadData
    {
        public static SavesData savesData { get; set; }
        //public static AppConfig appConfig;

        public static void Start()
        {
            ComprobarData<SavesData>(out var result);
            savesData = result;

            SavesDataLogic.VerifyInvalidSaves();
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
    }
}
