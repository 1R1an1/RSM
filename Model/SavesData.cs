using System.Collections.Generic;

namespace Rain_save_manager.Model
{
    public class SavesData : ConfigBehaviour
    {
        public List<SaveData> Saves = new List<SaveData>();
        
        public SavesData(List<SaveData> Saves):base(typeof(SavesData).Name){ this.Saves = Saves; }
        public SavesData():base(typeof(SavesData).Name){ }
    }
}
