using Rain_save_manager.Model;
using System.Windows;
using System.Windows.Input;

namespace Rain_save_manager.Windows
{
    public partial class OtherWindows : Window
    {
        public string texto;
        public Enums.Save save;
        public OtherWindows(Enums.OWT Type, string title = "")
        {
            InitializeComponent();
            if (Type == Enums.OWT.RenemeSaves)
            {
                string titulo = title == "" ? "Renombrar partida (RSM)" : title + " (RSM)";
                this.Title = titulo;
                lbl_title.Content = titulo;
                CDU_RENS.Visibility = Visibility.Visible;
                CDU_RENS.OnAceptar += Rename_click;
            }
            else if (Type == Enums.OWT.ReplaceSave)
            {
                string titulo = title == "" ? "Remplazar partida (RSM)" : title + " (RSM)";
                this.Title = titulo;
                lbl_title.Content = titulo;
                CDU_REPS.Visibility = Visibility.Visible;
                CDU_REPS.OnAceptar += CDU_REPS_OnAceptar;
            }
                borde.Visibility = Visibility.Visible;

        }

        private void CDU_REPS_OnAceptar(object sender, Enums.Save e)
        {
            save = e;
            this.DialogResult = true;
            this.Close();
        }

        private void Rename_click(object sender, System.EventArgs e)
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
    }
}
