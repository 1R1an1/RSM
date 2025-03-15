using System.Windows;
using System.Windows.Input;

namespace Rain_save_manager
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            borde.Visibility = Visibility.Visible;
            borde1.Visibility = Visibility.Visible;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void b_cerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void b_minimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void mi_home_Click(object sender, RoutedEventArgs e)
        {
            CDU_MainView.Visibility = Visibility.Visible;
            CDU_BackupsView.Visibility = Visibility.Collapsed;
        }

        private void mi_backup_Click(object sender, RoutedEventArgs e)
        {
            CDU_MainView.Visibility = Visibility.Collapsed;
            CDU_BackupsView.Visibility = Visibility.Visible;
        }
    }
}
