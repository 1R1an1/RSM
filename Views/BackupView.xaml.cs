using Rain_save_manager.Core;
using Rain_save_manager.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Rain_save_manager.Views
{
    /// <summary>
    /// Lógica de interacción para BackupView.xaml
    /// </summary>
    public partial class BackupView : UserControl
    {
        public static BackupManager backupManager { get; private set; }
        public static BackupManagerUI backupManagerUI { get; private set; }
        public BackupView()
        {
            InitializeComponent();
            backupManagerUI = new BackupManagerUI(WP_backup);
            backupManager = new BackupManager();
            backupManagerUI.InitializeButtonsBackups();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            if (WP_backup.Children.Count < 40)
            {
                Guid respuesta = backupManager.CreateBackup();
                backupManagerUI.AddButton(new KeyValuePair<Guid, Button>(respuesta, backupManagerUI.CreateBackupButton(respuesta)));
                return;
            }
            MessageBox.Show("No se pueden crear más de 40 backups", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Restaurar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Informacion_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void CreateButton(Guid guid)
        //{
        //    Count++;
        //    Button a = new Button()
        //    {
        //        Content = LoadData.backupsData.Backups[guid].timeS,
        //        Style = (Style)App.Current.FindResource("ButtonStyle"),
        //        FontSize = 12.5,
        //        Width = 176,
        //        Foreground = Brushes.Gray,
        //        VerticalAlignment = VerticalAlignment.Bottom,
        //        HorizontalAlignment = HorizontalAlignment.Right,
        //        ToolTip = $"{LoadData.backupsData.Backups[guid].time} \n{LoadData.backupsData.Backups[guid].timeS} \n{((int)LoadData.backupsData.Backups[guid].backupType)}"
        //    };
        //    if (Count < 4)
        //        a.Margin = new Thickness(0, 0, 10, 10);
        //    else
        //    {
        //        a.Margin = new Thickness(0, 0, 0, 10);
        //        Count = 0;
        //    }
        //        SP_esaves.Children.Add(a);
        //}
    }
}
