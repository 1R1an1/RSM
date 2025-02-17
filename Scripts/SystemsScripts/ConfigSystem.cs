using Rain_save_manager.Scripts.ConfigObj;

namespace Rain_save_manager.Scripts.SystemsScripts
{
    public static class ConfigSystem
    {
        public static T ReadConfigFile<T>() where T : ConfigBehaviour => FilesSystem.ReadFile<T>(Enums.RSMD.Config);

        public static void WriteConfigFile(string file, object content) => FilesSystem.WriteFile(Enums.RSMD.Config, file, content);
    }
}
