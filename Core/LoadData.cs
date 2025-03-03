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
            ComprobarData<SavesData>(out var savesData1);
            savesData = savesData1;

            ComprobarData<BackupsData>(out var backupsData1);
            backupsData = backupsData1;


            SavesDataLogic.VerifyInvalidSaves();
        }
        public static void Close()
        {
            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
            ConfigSystem.WriteConfigFile(BackupsData.fileName, backupsData);
        }

        private static void ComprobarData<T>(out T result) where T : ConfigBehaviour, new ()
        {
            try { result = ConfigSystem.ReadConfigFile<T>(); }
            catch (FileNotFoundException) { result = new T(); ConfigSystem.WriteConfigFile(typeof(T).Name, result); }
        }
    }
}
