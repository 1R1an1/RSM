using Rain_save_manager.Model;
using System.Windows;
using System.Windows.Input;

namespace Rain_save_manager.Windows
{
    public partial class OtherWindows : Window
    {
        public string texto;
        public OtherWindows(Enums.OWT Type)
        {
            InitializeComponent();
            if (Type == Enums.OWT.RenemeSaves)
            {
                string titulo = "Renombrar partida";
                this.Title = titulo;
                lbl_title.Content = titulo;
                CDU_RENS.Visibility = Visibility.Visible;
                CDU_RENS.OnAceptar += Button_Click;
            }
            else if (Type == Enums.OWT.ReplaceSave)
            {
                string titulo = "Remplazar partida";
                this.Title = titulo;
                lbl_title.Content = titulo;
                CDU_REPS.Visibility = Visibility.Visible;
            }
                borde.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            texto = CDU_RENS.nombre;
            this.DialogResult = true;
            this.Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void b_cerrar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void b_minimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Dato = txtDato.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
