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

        public SaveManagerUI(StackPanel _SP_saves)
        {
            this._SP_saves = _SP_saves;
            _lblSaves = new Dictionary<int, Label>();
        }

        public void InitializeLabelsSaves()
        {
            //for (int i = 0; i < LoadData.savesData.Saves.Count; i++)
            //{
            //    Label lbl = CreateSaveLabel(LoadData.savesData.Saves[i]);

            //    saveManager.lblSaves.Add(lbl);
            //    saveManager.SP_saves.Children.Add(lbl);
            //}

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
                ContextMenu = CreateContextMenu(save.Key)
            };
            lbl.MouseDoubleClick += (s, e) => RSMain.RemplazarSave_Click(s, e, save.Key);
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
            renameItem.Click += (s, e) => RSMain.CambiarNombre_Click(s, e, saveId);

            MenuItem deleteItem = new MenuItem()
            {
                FontSize = 12,
                FontFamily = new FontFamily("Consolas"),
                Style = (Style)App.Current.FindResource("MIDOWN"),
                Header = "Eliminar"
            };
            deleteItem.Click += (s, e) => RSMain.Eliminar_Click(s, e, saveId);

            contextMenu.Items.Add(renameItem);
            contextMenu.Items.Add(deleteItem);
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
