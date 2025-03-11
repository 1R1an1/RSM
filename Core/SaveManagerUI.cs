using Rain_save_manager.Model;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Rain_save_manager.Views;

namespace Rain_save_manager.Core
{
    public class SaveManagerUI
    {
        private Dictionary<int, RadioButton> _RB_Saves;
        private int _RB_Visual_Count;
        private bool _Is_btn_enabled = true;
        private MainView _mainView;

        public SaveManagerUI(MainView _mainView)
        {
            _RB_Saves = new Dictionary<int, RadioButton>();
            this._mainView = _mainView;
            VerifySelectedRadioButton();
        }


        private void VerifySelectedRadioButton() => SetIsEnabledInButtons(_RB_Saves.Values.Any(rb => rb.IsChecked == true));
        private void SetButtonProperties(Button button, bool isEnabled, string tagResource, string foregroundResource)
        {
            button.IsEnabled = isEnabled;
            button.Tag = (Brush)App.Current.FindResource(tagResource);
            button.Foreground = (Brush)App.Current.FindResource(foregroundResource);
        }
        private void SetIsEnabledInButtons(bool enable)
        {
            if (_Is_btn_enabled == enable)
                return;
            string tagResource = enable ? "NormalColorNormal" : "NormalColorDisabled";
            string foregroundResource = enable ? "FontColor" : "FontColorDisabled";

            SetButtonProperties(_mainView.btn_Eliminar, enable, tagResource, foregroundResource);
            SetButtonProperties(_mainView.btn_CambiarNombre, enable, tagResource, foregroundResource);
            SetButtonProperties(_mainView.btn_Utilizar, enable, tagResource, foregroundResource);
            SetButtonProperties(_mainView.btn_Actualizar, enable, tagResource, foregroundResource);
            _Is_btn_enabled = enable;
        }
        private void ActualizarMarginRadioButtons()
        {
            for (int i = 0; i < _RB_Saves.Count; i++)
            {
                List<RadioButton> rb = new List<RadioButton>(_RB_Saves.Values);

                double rightMargin = (i % 2 == 0) ? 10 : 0;
                double bottomMargin = (i >= rb.Count - (_RB_Saves.Count % 2 != 0 ? 1 : 2)) ? 0 : 10;

                rb[i].Margin = new Thickness(0, 0, rightMargin, bottomMargin);
            }
        }


        public RadioButton CreateSaveRadioButton(KeyValuePair<int, SaveData> save)
        {
            _RB_Visual_Count++;
            RadioButton rb = new RadioButton()
            {
                Name = $"id_{save.Key}",
                Style = (Style)App.Current.FindResource("RadioButtonStyle"),
                Content = save.Value.saveName,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(5.5),
                MaxWidth = 290.5,
                Width = 290.5,
                FontSize = 13.5,
                GroupName = "Saves"
            };

            rb.Margin = _RB_Visual_Count < 2 ? new Thickness(0, 0, 10, 10) : new Thickness(0, 0, 0, 10);
            _RB_Visual_Count = _RB_Visual_Count < 2 ? _RB_Visual_Count : 0;

            rb.Checked += (s, e) => SetIsEnabledInButtons(true);
            //lbl.MouseDoubleClick += (s, e) => _mainView.RemplazarSave_Click(s, e, save.Key);
            return rb;
        }
        public KeyValuePair<int, RadioButton> GetSelectedRadioButton() => _RB_Saves.FirstOrDefault(rb => rb.Value.IsChecked == true);


        public void InitializeRadioButtonSaves() { foreach (KeyValuePair<int, SaveData> dictionary in LoadData.savesData.Saves) { AddRadioButton(new KeyValuePair<int, RadioButton>(dictionary.Key, CreateSaveRadioButton(dictionary))); } }
        public void AddRadioButton(KeyValuePair<int, RadioButton> rb)
        {
            _mainView.WP_saves.Children.Add(rb.Value);
            _RB_Saves.Add(rb.Key, rb.Value);
            ActualizarMarginRadioButtons();
        }


        public void ActualizarRadioButton(int id)
        {
            _RB_Saves[id].Content = LoadData.savesData.Saves[id].saveName;
        }
        public void EliminarRadioButton(int id)
        {
            _mainView.WP_saves.Children.Remove(_RB_Saves[id]);
            _RB_Saves.Remove(id);
            if (_RB_Visual_Count != 0)
                _RB_Visual_Count--;
            ActualizarMarginRadioButtons();
            VerifySelectedRadioButton();
        }
        public void VerificarScrollbar() => _mainView.WP_saves.Margin = _mainView.SV_saves.ComputedVerticalScrollBarVisibility == Visibility.Visible ? new Thickness(0, 0, 5, 0) : new Thickness(10, 0, 10, 0);
    }
}
