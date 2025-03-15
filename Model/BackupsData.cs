using System.Collections.Generic;

namespace Rain_save_manager.Model
{
    public class BackupsData : ConfigBehaviour
    {
        public Dictionary<int, BackupData> Backups = new Dictionary<int, BackupData>();

        public BackupsData(Dictionary<int, BackupData> Backups) : base(typeof(BackupsData).Name) { this.Backups = Backups; }
        public BackupsData() : base(typeof(BackupsData).Name) { }
    }
}
