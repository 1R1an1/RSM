using Rain_save_manager.Model;
using System.IO;

namespace Rain_save_manager.Core
{
    public static class LoadData
    {
        public static SavesData savesData { get; set; }
        public static BackupsData backupsData { get; set; }
        //public static AppConfig appConfig;

        public static void Start()
        {
            savesData = ComprobarData<SavesData>();
            backupsData = ComprobarData<BackupsData>();

            SavesDataLogic.VerifyInvalidSaves();
        }
        public static void Close()
        {
            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
            ConfigSystem.WriteConfigFile(BackupsData.fileName, backupsData);
        }


        private static T ComprobarData<T>() where T : ConfigBehaviour, new()
        {
            try
            { return ConfigSystem.ReadConfigFile<T>(); }
            catch (FileNotFoundException)
            {
                T result = new T();
                ConfigSystem.WriteConfigFile(typeof(T).Name, result);
                return result;
            }
        }
    }
}
