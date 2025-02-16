namespace Rain_save_manager.Scripts.ConfigObj
{
    public class SaveData : ConfigBehaviour
    {
        public string saveName;
        public int saveId;

        public SaveData(string saveName, int saveId) { this.saveName = saveName; this.saveId = saveId; }
    }
}
