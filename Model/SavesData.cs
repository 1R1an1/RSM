using System.Collections.Generic;

namespace Rain_save_manager.Model
{
    public class SavesData : ConfigBehaviour
    {
        public Dictionary<int, SaveData> Saves = new Dictionary<int, SaveData>();
        
        public SavesData(Dictionary<int, SaveData> Saves):base(typeof(SavesData).Name){ this.Saves = Saves; }
        public SavesData():base(typeof(SavesData).Name){ }
    }
}
