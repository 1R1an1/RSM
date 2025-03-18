using Rain_save_manager.Model;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using static Rain_save_manager.Core.SavesSystem;

namespace Rain_save_manager.Core
{
    public static class LoadData
    {
        public static Dictionary<int, SaveData> savesData { get; set; }
        //public static AppConfig appConfig;

        public static void Start()
        {
            savesData = new Dictionary<int, SaveData>();
            if (Directory.GetFiles(App.appsaves).Length != 0)
                ReadSavesFiles(savesData);
            
                //foreach (var item in Directory.GetFiles(App.appsaves))
                //{
                //    SaveData data = FilesSystem.ReadFile<SaveData>(Enums.RSMD.Saves, item.Split('\\').Last());
                //    savesData.Add(data.saveId, data);
                //}
            

            //ComprobarData<SaveData>(out var result);
            //savesData = result;

            //SavesDataLogic.VerifyInvalidSaves();
        }
        public static void Close()
        {
            WriteSavesFile(savesData);
            //foreach (var item in savesData.Values)
            //    ConfigSystem.WriteConfigFile(Path.Combine(App.appsaves, item.saveFileName), item);
        }

        //private static void ComprobarData<T>(out T result) where T : new()
        //{
        //    try { result = ConfigSystem.ReadConfigFile<T>(); }
        //    catch (FileNotFoundException) { result = new T(); ConfigSystem.WriteConfigFile(typeof(T).Name, result); }
        //}
    }
}
