using System.Collections.Generic;

namespace Rain_save_manager.Scripts.ConfigObj
{
    public class SavesData : ConfigBehaviour
    {
        public int SavesCount;
        public List<SaveData> Saves = new List<SaveData>();

        public SavesData(int SavesCount):base(typeof(SavesData).Name) { this.SavesCount = SavesCount; }
        public SavesData():base(typeof(SavesData).Name) { SavesCount = 0; }
    }
}
