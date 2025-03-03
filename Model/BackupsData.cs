using System;
using System.Collections.Generic;

namespace Rain_save_manager.Model
{
    public class BackupsData : ConfigBehaviour
    {
        public Dictionary<Guid, BackupData> Backups = new Dictionary<Guid, BackupData>();

        public BackupsData(Dictionary<Guid, BackupData> backup):base(typeof(BackupsData).Name) => this.Backups = backup;
        public BackupsData():base(typeof(BackupsData).Name) { }
    }
}
