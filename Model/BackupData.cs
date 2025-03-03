using Newtonsoft.Json;
using System;

namespace Rain_save_manager.Model
{
    public class BackupData
    {
        public DateTime time;
        [JsonProperty("timeString")]
        public string timeS;
        public Enums.BackupType backupType;

        public BackupData(DateTime time, Enums.BackupType backupType) { this.time = time; timeS = string.Empty; timeS = time.ToString("dd-MM-yyyy__HH-mm-ss-fff"); this.backupType = backupType; }
    }
}
