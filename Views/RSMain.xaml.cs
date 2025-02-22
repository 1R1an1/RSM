using Rain_save_manager.Core;
using Rain_save_manager.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace Rain_save_manager.Views
{
    public partial class RSMain : UserControl
    {
        public static SaveManager saveManager { get; private set; }
        public static SaveManagerUI saveManagerUI { get; private set; }
        public RSMain()
        {
            InitializeComponent();
            saveManager = new SaveManager();
            saveManagerUI = new SaveManagerUI(SP_saves);
            saveManagerUI.InitializeLabelsSaves();

        }


        public static void RemplazarSave_Click(object sender, MouseButtonEventArgs e, int id) { saveManager.RemplazarSave(id); saveManagerUI.ActualizarLabel(id); }
        public static void CambiarNombre_Click(object sender, RoutedEventArgs e, int id) { saveManager.CambiarNombreSave(id); saveManagerUI.ActualizarLabel(id); }
        public static void Eliminar_Click(object sender, RoutedEventArgs e, int id) { saveManager.EliminarSave(id); saveManagerUI.EliminarLabel(id); }


        private void btn_cpysave1_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_1);
        private void btn_cpysave2_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_2);
        private void btn_cpysave3_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_3);

        private void CopySave(Enums.Save save)
        {
            KeyValuePair<int, SaveData> respuesta = saveManager.CopiarSave(save);
            KeyValuePair<int, SaveData> a = new KeyValuePair<int, SaveData>();

            if (respuesta.Key != a.Key || respuesta.Value != a.Value)
                saveManagerUI.AddLabel(new KeyValuePair<int, Label>(respuesta.Key, saveManagerUI.CreateSaveLabel(respuesta)));
        }

        private void btn_deletallsaves_Click(object sender, RoutedEventArgs e)
        {
            List<int> keysToRemove = new List<int>();
            foreach (KeyValuePair<int, SaveData> item in LoadData.savesData.Saves)
            {
                keysToRemove.Add(item.Key);
            }

            for (int i = 0; i < keysToRemove.Count; i++)
            {
                saveManagerUI.EliminarLabel(keysToRemove[i]);
            }
            saveManager.EliminarSaves();
        }
    }
}
