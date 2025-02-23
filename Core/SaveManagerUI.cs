using Rain_save_manager.Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using Rain_save_manager.Views;
using System.Collections.Generic;

namespace Rain_save_manager.Core
{
    public class SaveManagerUI
    {
        private StackPanel _SP_saves;
        private Dictionary<int, Label> _lblSaves;
        private Label _lblSave1, _lblSave2, _lblSave3;
        private MainView _mainView;

        public SaveManagerUI(StackPanel _SP_saves, Label _lblSave1, Label _lblSave2, Label _lblSave3, MainView _mainView)
        {
            this._SP_saves = _SP_saves;
            _lblSaves = new Dictionary<int, Label>();
            this._lblSave1 = _lblSave1;
            this._lblSave2 = _lblSave2;
            this._lblSave3 = _lblSave3;
            this._mainView = _mainView;
        }

        public void InitializeLabelsSaves()
        {
            _lblSave1.ContextMenu = CreateContextMenuSave(Enums.Save.Save_1);
            _lblSave1.MouseDoubleClick += _mainView.btn_cpysave1_Click;
            
            _lblSave2.ContextMenu = CreateContextMenuSave(Enums.Save.Save_2);
            _lblSave2.MouseDoubleClick += _mainView.btn_cpysave2_Click;
            
            _lblSave3.ContextMenu = CreateContextMenuSave(Enums.Save.Save_3);
            _lblSave3.MouseDoubleClick += _mainView.btn_cpysave3_Click;


            foreach (KeyValuePair<int, SaveData> dictionary in LoadData.savesData.Saves)
            {
                Label lbl = CreateSaveLabel(dictionary);

                _lblSaves.Add(dictionary.Key, lbl);
                _SP_saves.Children.Add(lbl);
            }
        }
        public Label CreateSaveLabel(KeyValuePair<int, SaveData> save)
        {
            Label lbl = new Label()
            {
                Name = $"id_{save.Key}",
                Style = (Style)App.Current.FindResource("lblS"),
                Content = save.Value.saveName,
                FontSize = 13.5,
                Margin = new Thickness(0,0,0,2.5),
                ContextMenu = CreateContextMenu(save.Key)
            };
            lbl.MouseDoubleClick += (s, e) => _mainView.RemplazarSave_Click(s, e, save.Key);
            return lbl;
        }
        private ContextMenu CreateContextMenu(int saveId)
        {
            ContextMenu contextMenu = new ContextMenu() { Style = (Style)App.Current.FindResource("CM") };

            MenuItem renameItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)App.Current.FindResource("MIUP"),
                Header = "Cambiar nombre"
            };
            renameItem.Click += (s, e) => _mainView.CambiarNombre_Click(s, e, saveId);

            MenuItem UpdateItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)App.Current.FindResource("MIMIDDLE"),
                Header = "Actualizar"
            };
            UpdateItem.Click += (s, e) => _mainView.Update_Click(s, e, saveId);

            MenuItem deleteItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)App.Current.FindResource("MIDOWN"),
                Header = "Eliminar"
            };
            deleteItem.Click += (s, e) => _mainView.Eliminar_Click(s, e, saveId);

            contextMenu.Items.Add(renameItem);
            contextMenu.Items.Add(UpdateItem);
            contextMenu.Items.Add(deleteItem);
            return contextMenu;
        }

        private ContextMenu CreateContextMenuSave(Enums.Save save)
        {
            ContextMenu contextMenu = new ContextMenu() { Style = (Style)App.Current.FindResource("CM") };

            MenuItem copiSave = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)App.Current.FindResource("MI"),
                Header = "Copiar"
            };

            if (save == Enums.Save.Save_1)
                copiSave.Click += _mainView.btn_cpysave1_Click;
            else if (save == Enums.Save.Save_2)
                copiSave.Click += _mainView.btn_cpysave2_Click;
            else
                copiSave.Click += _mainView.btn_cpysave3_Click;

            contextMenu.Items.Add(copiSave);
            return contextMenu;
        }

        public void AddLabel(KeyValuePair<int, Label> lbl)
        {
            _SP_saves.Children.Add(lbl.Value);
            _lblSaves.Add(lbl.Key, lbl.Value);
        }
        public void ActualizarLabel(int id)
        {
            _lblSaves[id].Content = LoadData.savesData.Saves[id].saveName;
        }

        public void EliminarLabel(int id)
        {
            _SP_saves.Children.Remove(_lblSaves[id]);
            _lblSaves.Remove(id);
        }
    }
}
