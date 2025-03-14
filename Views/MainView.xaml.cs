using Rain_save_manager.Core;
using Rain_save_manager.Model;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Rain_save_manager.Windows;

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
            saveManagerUI = new SaveManagerUI(this);
            saveManagerUI.InitializeRadioButtonSaves();
        }

        private void CopySave(Enums.Save save)
        {
            KeyValuePair<int, SaveData> respuesta = saveManager.CopiarSave(save);
            KeyValuePair<int, SaveData> a = default;

            if (respuesta.Key != a.Key || respuesta.Value != a.Value)
                saveManagerUI.AddRadioButton(new KeyValuePair<int, RadioButton>(respuesta.Key, saveManagerUI.CreateSaveRadioButton(respuesta)));
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
                    saveManagerUI.EliminarRadioButton(keysToRemove[i]);
                }
            }

        }
        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            OtherWindows window = new OtherWindows(Enums.OWT.ReplaceSave, "Copiar partida");
            
            if (window.ShowDialog() == true)
                CopySave(window.save);
        }

        private void btn_Info_Click(object sender, RoutedEventArgs e) { int id = saveManagerUI.GetSelectedRadioButton().Key; saveManager.VerInfoSave(id);}
        private void btn_CambiarNombre_Click(object sender, RoutedEventArgs e) { int id = saveManagerUI.GetSelectedRadioButton().Key; saveManager.CambiarNombreSave(id); saveManagerUI.ActualizarRadioButton(id); }
        private void btn_Actualizar_Click(object sender, RoutedEventArgs e) { int id = saveManagerUI.GetSelectedRadioButton().Key; saveManager.ActualizarSave(id); }
        private void btn_Eliminar_Click(object sender, RoutedEventArgs e) { int id = saveManagerUI.GetSelectedRadioButton().Key; saveManager.EliminarSave(id); saveManagerUI.EliminarRadioButton(id); }
        private void btn_Utilizar_Click(object sender, RoutedEventArgs e) { int id = saveManagerUI.GetSelectedRadioButton().Key; saveManager.RemplazarSave(id); }

        private void SV_saves_ScrollChanged(object sender, ScrollChangedEventArgs e) => saveManagerUI.VerificarScrollbar();

    }
}
