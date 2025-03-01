﻿using System.IO;

namespace Rain_save_manager.Core
{
    public static class SavesSystem
    {
        //public static void CopySaveFile(string path, string filename, bool replace, out bool Replace)
        //{
        //    try
        //    {
        //        File.Copy(path + "\\" + filename, App.appsaves + $@"\{filename}");
        //        Replace = false;
        //    }
        //    catch
        //    {
        //        Replace = true;
        //        File.Copy(path + "\\" + filename, App.appsaves + $@"\{filename}", replace);
        //    }
        //}

        public static void CopySaveFile(string filename, string destfilename, out bool Replace)
        {
            try
            { File.Copy(Path.Combine(App.rainworldsaves, filename), Path.Combine(App.appsaves, destfilename)); Replace = false; }
            catch (IOException) { Replace = true; }
        }

        public static void CopySaveFile(string filename, string destfilename, bool replace) { if (replace) File.Copy(Path.Combine(App.rainworldsaves, filename), Path.Combine(App.appsaves, destfilename), replace); }
    }
}
