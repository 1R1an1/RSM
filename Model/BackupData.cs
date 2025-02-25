using System;

namespace Rain_save_manager.Model
{
    public class BackupData
    {
        public DateTime time;
        public string timeS;
        public Enums.BackupType backupType;

        public BackupData()
        {
            time = DateTime.Now;
            timeS = time.ToString("dd-MM-yyyy_HH-mm-ss-fff");
        }
        public BackupData(DateTime time) => this.time = time;
        public BackupData(DateTime time, Enums.BackupType backupType) { this.time = time; this.backupType = backupType; }
    }
}
