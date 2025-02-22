using Rain_save_manager.Model;
#if DEBUG
using FortiCrypts;
using System;
#endif
using System.IO;

namespace Rain_save_manager.Core
{
    public static class LoadData
    {
        public static SavesData savesData { get; private set; }
        public static SavesData savesdata { private get => savesData; set { savesData = value; } }
        //public static AppConfig appConfig;

        public static void Start()
        {
            ComprobarData<SavesData>(out var result);
            savesData = result;
            SavesDataLogic.VerifyInvalidSaves();

            #if DEBUG
            ConfigSystem.WriteConfigFile(SavesData.fileName, savesData);
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
    }
}
