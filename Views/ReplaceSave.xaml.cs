using Rain_save_manager.Model;
using System;
using System.Windows.Controls;

namespace Rain_save_manager.Views
{
    /// <summary>
    /// Lógica de interacción para ReplaceSave.xaml
    /// </summary>
    public partial class ReplaceSave : UserControl
    {
        public event EventHandler<Enums.Save> OnAceptar;
        public ReplaceSave()
        {
            InitializeComponent();
        }

        private void replace(Enums.Save save) => OnAceptar(this, save);

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) => replace(Enums.Save.Save_1);
        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e) => replace(Enums.Save.Save_2);
        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e) => replace(Enums.Save.Save_3);
    }
}
