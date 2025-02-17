using FortiCrypts;
using System.IO;
using Newtonsoft.Json;
#if DEBUG
using System;
#endif
using Rain_save_manager.Scripts.ConfigObj;

namespace Rain_save_manager.Scripts.SystemsScripts
{
    public static class FilesSystem
    {


        public static T ReadFile<T>(Enums.RSMD directory) where T : ConfigBehaviour
        {
            string filepath = Path.Combine(App.appRSM, directory.ToString(), $"{typeof(T).Name}.rsm");
            string text = File.ReadAllText(filepath);
            string textDecrypted = AES128.Decrypt(text, CryptoUtils.defaultPassword);
            #if DEBUG
                Console.WriteLine(textDecrypted);
            #endif
            var result = JsonConvert.DeserializeObject<T>(textDecrypted);

            return result;
        }

        public static void WriteFile(Enums.RSMD directory, string file, object obj)
        {
            string filepath = Path.Combine(App.appRSM, directory.ToString(), file + ".rsm");
            string filepath1 = Path.Combine(App.appRSM, directory.ToString(), file + "2.json");
            
            //if (!File.Exists(filepath))
            //{
            //    File.Create(filepath);
            //}
            //if (!File.Exists(filepath1))
            //{
            //    File.Create(filepath1);
            //}

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            #if DEBUG
                Console.WriteLine(json);
            #endif
            string jsonEncrypted = AES128.Encrypt(json, CryptoUtils.defaultPassword);

            File.WriteAllText(filepath, jsonEncrypted);
            File.WriteAllText(filepath1, json);
        }

        //public static string ReadFileHigh(Enums.RSMD directory, string file)
        //{
        //    string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
        //    string text = File.ReadAllText(filepath);
        //    string textDecrypted = CrypShieldProHigh.Decrypt(text);
        //    return textDecrypted;
        //}

        //public static void WriteFileHigh(Enums.RSMD directory, string file, object obj)
        //{
        //    string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
        //    string filepath1 = $"{App.appRSM}\\{directory}\\{file}2.rsm";

        //    if (!File.Exists(filepath))
        //    {
        //        File.Create(filepath);
        //        File.Create(filepath1);
        //    }

        //    var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        //    string jsonEncrypted = CrypShieldProHigh.Encrypt(json);

        //    File.WriteAllText(filepath, jsonEncrypted);
        //    File.WriteAllText(filepath1, json);
        //}
    }
}
