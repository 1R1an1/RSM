using System;
using System.IO;
using System.Windows.Controls;

namespace Rain_save_manager.Views
{
    /// <summary>
    /// Lógica de interacción para Window.xaml
    /// </summary>
    public partial class Window : UserControl
    {
        public Window()
        {
            InitializeComponent();
        }

        private void btn_rutaOB_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string ruta = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Videocult\\Rain World";
            string ruta1 = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Videocult\\Rain World";
            string ruta2 = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\..\\LocalLow\\Videocult\\Rain World";
            Console.WriteLine(ruta);
            Console.WriteLine(ruta1);
            Console.WriteLine(ruta2);
            Console.WriteLine(Directory.Exists(ruta2));
            for (int i = 0; i < Directory.GetFileSystemEntries(ruta2).Length; i++)
            {
                Console.WriteLine(Directory.GetFileSystemEntries(ruta2)[i]);
            }
        }
    }
}
