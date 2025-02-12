using FortiCrypts;
using System.IO;
using Newtonsoft.Json;

namespace Rain_save_manager.Scripts.SystemsScripts
{
    public static class FilesSystem
    {
        public enum RSMD { Config, Saves }


        public static string ReadFile(RSMD directory, string file)
        {
            string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
            string text = File.ReadAllText(filepath);
            string textDecrypted = CrypShieldPro.Decrypt(text);
            return textDecrypted;
        }

        public static void WriteFile(RSMD directory, string file, object obj)
        {
            string filepath = $"{App.appRSM}\\{directory}\\{file}.rsm";
            string filepath1 = $"{App.appRSM}\\{directory}\\{file}2.rsm";

            if (!File.Exists(filepath))
            {
                File.Create(filepath);
                File.Create(filepath1);
            }

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string jsonEncrypted = CrypShieldPro.Encrypt(json);

            File.WriteAllText(filepath, jsonEncrypted);
            File.WriteAllText(filepath1, json);
        }
    }
}
