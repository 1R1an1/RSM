﻿using FortiCrypts;
using System.IO;
using Newtonsoft.Json;
#if DEBUG
using System;
#endif
using Rain_save_manager.Model;

namespace Rain_save_manager.Core
{
    public static class FilesSystem
    {


        public static T ReadFile<T>(Enums.RSMD directory) where T : ConfigBehaviour
        {
            string filepath = Path.Combine(App.appRSM, directory.ToString(), $"{typeof(T).Name}.rsm");
            string text = File.ReadAllText(filepath);
            string textDecrypted = AES256.Decrypt(text, CryptoUtils.defaultPassword);
            #if DEBUG
                Console.WriteLine(textDecrypted);
            #endif
            var result = JsonConvert.DeserializeObject<T>(textDecrypted);

            return result;
        }

        public static void WriteFile(Enums.RSMD directory, string file, object obj)
        {
            string filepath = Path.Combine(App.appRSM, directory.ToString(), file + ".rsm");
#if DEBUG      
            string filepath1 = Path.Combine(App.appRSM, directory.ToString(), file + "2.json");
#endif

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            #if DEBUG
                Console.WriteLine(json);
            #endif
            string jsonEncrypted = AES256.Encrypt(json, CryptoUtils.defaultPassword);

            File.WriteAllText(filepath, jsonEncrypted);
#if DEBUG
            File.WriteAllText(filepath1, json);
#endif
        }
    }
}
