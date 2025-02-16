using FortiCrypts;
using System.IO;
using Newtonsoft.Json;
using System;
using Rain_save_manager.Scripts.ConfigObj;

namespace Rain_save_manager.Scripts.SystemsScripts
{
    public static class FilesSystem
    {
        public enum RSMD { Config, Saves }


        public static T ReadFile<T>(RSMD directory) where T : ConfigBehaviour
        {
            string filepath = $"{App.appRSM}\\{directory}\\{typeof(T).Name}.rsm";
            string text = File.ReadAllText(filepath);
            string textDecrypted = AES128.Decrypt(text, CryptoUtils.defaultPassword);
            Console.WriteLine(textDecrypted);

            var result = JsonConvert.DeserializeObject<T>(textDecrypted);

            return result;
        }

        public static void WriteFile(RSMD directory, string file, object obj)
        {
            string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
            string filepath1 = $"{App.appRSM}\\{directory}\\{file}2.json";
            
            //if (!File.Exists(filepath))
            //{
            //    File.Create(filepath);
            //}
            //if (!File.Exists(filepath1))
            //{
            //    File.Create(filepath1);
            //}

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
            string jsonEncrypted = AES128.Encrypt(json, CryptoUtils.defaultPassword);

            File.WriteAllText(filepath, jsonEncrypted);
            File.WriteAllText(filepath1, json);
        }

        //public static string ReadFileHigh(RSMD directory, string file)
        //{
        //    string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
        //    string text = File.ReadAllText(filepath);
        //    string textDecrypted = CrypShieldProHigh.Decrypt(text);
        //    return textDecrypted;
        //}

        //public static void WriteFileHigh(RSMD directory, string file, object obj)
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
