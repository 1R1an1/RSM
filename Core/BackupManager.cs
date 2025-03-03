using Rain_save_manager.Model;
using System;


namespace Rain_save_manager.Core
{
    public class BackupManager
    {
        public Guid CreateBackup()
        {
            Guid guid = Guid.NewGuid();
            BackupData bd = new BackupData(DateTime.Now, Enums.BackupType.GameSaves);

            LoadData.backupsData.Backups.Add(guid, bd);
            return guid;
        }
    }
}
