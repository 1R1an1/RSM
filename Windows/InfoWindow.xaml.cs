using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rain_save_manager.Windows
{
    /// <summary>
    /// Lógica de interacción para InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        private TextBlock tb;
        public InfoWindow()
        {
            InitializeComponent();
            borde.Visibility = Visibility.Visible;
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


        public void ShowText(string text, VerticalAlignment va, HorizontalAlignment ha, Thickness margin)
        {
            tb = new TextBlock()
            {
                Style = (Style)FindResource("TBS"),
                Text = text,
                VerticalAlignment = va,
                HorizontalAlignment = ha,
                Margin = margin
            };
        }
        public void ShowText(string text, VerticalAlignment va, HorizontalAlignment ha)
        {
            tb = new TextBlock()
            {
                Style = (Style)FindResource("TBS"),
                Text = text,
                VerticalAlignment = va,
                HorizontalAlignment = ha
            };
        }
        public void ShowText(string text, VerticalAlignment va)
        {
            tb = new TextBlock()
            {
                Style = (Style)FindResource("TBS"),
                Text = text,
                VerticalAlignment = va
            };
        }
        public void ShowText(string text, HorizontalAlignment ha)
        {
            tb = new TextBlock()
            {
                Style = (Style)FindResource("TBS"),
                Text = text,
                HorizontalAlignment = ha
            };
        }
        public void ShowText(string text)
        {
            tb = new TextBlock()
            {
                Style = (Style)FindResource("TBS"),
                Text = text,
            };
        }
    }
}
