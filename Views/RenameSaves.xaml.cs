using System;
using System.Windows.Controls;

namespace Rain_save_manager.Views
{
    /// <summary>
    /// Lógica de interacción para RenameSaves.xaml
    /// </summary>
    public partial class RenameSaves : UserControl
    {
        public string nombre;
        public event EventHandler OnAceptar;
        public RenameSaves()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            nombre = txtDato.Text;
            OnAceptar?.Invoke(this, EventArgs.Empty);
        }
    }
}
