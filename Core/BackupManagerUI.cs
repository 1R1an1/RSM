using Rain_save_manager.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rain_save_manager.Core
{
    public class BackupManagerUI
    {
        private WrapPanel _WP_backup;
        private Dictionary<Guid, Button> _btnBackups;
        private int _Count = 0;

        public BackupManagerUI(WrapPanel WP_backup)
        {
            _WP_backup = WP_backup;
            _btnBackups = new Dictionary<Guid, Button>();
        }

        public void InitializeButtonsBackups()
        {
            foreach (KeyValuePair<Guid, BackupData> dictionary in LoadData.backupsData.Backups)
            {
                Button btn = CreateBackupButton(dictionary.Key);
                AddButton(new KeyValuePair<Guid, Button>(dictionary.Key, btn));
            }
        }

        public Button CreateBackupButton(Guid backupKey)
        {
            _Count++;
            Button btn = new Button()
            {
                Content = LoadData.backupsData.Backups[backupKey].timeS,
                Style = (Style)App.Current.FindResource("ButtonStyle"),
                FontSize = 12.5,
                Width = 176,
                Foreground = Brushes.Gray,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                ToolTip = $"{LoadData.backupsData.Backups[backupKey].time} \n{LoadData.backupsData.Backups[backupKey].timeS} \n{((int)LoadData.backupsData.Backups[backupKey].backupType)}"
            };
            if (_Count < 4)
                btn.Margin = new Thickness(0, 0, 10, 10);
            else
            {
                btn.Margin = new Thickness(0, 0, 0, 10);
                _Count = 0;
            }
            return btn;
        }

        public void AddButton(KeyValuePair<Guid, Button> btn)
        {
            _WP_backup.Children.Add(btn.Value);
            _btnBackups.Add(btn.Key, btn.Value);
        }

        public void EliminarButton(Guid guid)
        {
            _WP_backup.Children.Remove(_btnBackups[guid]);
            _btnBackups.Remove(guid);
            _Count--;
        }
     }
}
