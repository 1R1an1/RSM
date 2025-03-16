using Newtonsoft.Json;

namespace Rain_save_manager.Model
{
    public class SaveData
    {
        [JsonProperty("Id")]
        public int saveId;

        [JsonProperty("Name")]
        public string saveName = string.Empty;

        [JsonProperty("Content")]
        public string saveContent = string.Empty;

        public SaveData(string saveName, int saveId, string saveContent)
        {
            this.saveName = saveName;
            this.saveId = saveId;
            this.saveContent = saveContent;
        }
        public SaveData() { }
    }
}
