using Rain_save_manager.Core;
using Rain_save_manager.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace Rain_save_manager.Views
{
    public partial class MainView : UserControl
    {
        public static SaveManager saveManager { get; private set; }
        public static SaveManagerUI saveManagerUI { get; private set; }
        public MainView()
        {
            InitializeComponent();
            saveManager = new SaveManager();
            saveManagerUI = new SaveManagerUI(SP_saves, lblSave1, lblSave2, lblSave3, this);
            saveManagerUI.InitializeLabelsSaves();

        }


        public void RemplazarSave_Click(object sender, MouseButtonEventArgs e, int id) { saveManager.RemplazarSave(id); saveManagerUI.ActualizarLabel(id); }
        public void CambiarNombre_Click(object sender, RoutedEventArgs e, int id) { saveManager.CambiarNombreSave(id); saveManagerUI.ActualizarLabel(id); }
        public void Update_Click(object sender, RoutedEventArgs e, int id) => saveManager.UpdateSave(id);
        public void Eliminar_Click(object sender, RoutedEventArgs e, int id) { saveManager.EliminarSave(id); saveManagerUI.EliminarLabel(id); }


        public void btn_cpysave1_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_1);
        public void btn_cpysave2_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_2);
        public void btn_cpysave3_Click(object sender, RoutedEventArgs e) => CopySave(Enums.Save.Save_3);

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

            if (saveManager.EliminarSaves())
            {
                for (int i = 0; i < keysToRemove.Count; i++)
                {
                    saveManagerUI.EliminarLabel(keysToRemove[i]);
                }
            }

        }
    }
}
