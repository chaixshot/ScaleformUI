﻿using ScaleformUI.Menu;

namespace ScaleformUI.PauseMenu
{
    public delegate void SettingsCheckboxChanged(SettingsItem item, bool value);
    public class SettingsCheckboxItem : SettingsItem
    {
        private bool isChecked;
        public event SettingsCheckboxChanged OnCheckboxChange;
        public UIMenuCheckboxStyle CheckBoxStyle { get; set; }
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                if (Parent != null)
                {
                    int leftItem = Parent.Parent.LeftItemList.IndexOf(Parent);
                    int rightIndex = Parent.ItemList.IndexOf(this);
                    Parent.Parent.Parent._pause.SetRightSettingsItemBool(leftItem, rightIndex, isChecked);
                }
                CheckboxChanged();
            }
        }
        public SettingsCheckboxItem(string label, UIMenuCheckboxStyle style, bool @checked) : base(label, "")
        {
            ItemType = SettingsItemType.CheckBox;
            Label = label;
            CheckBoxStyle = style;
            IsChecked = @checked;
        }

        public void CheckboxChanged()
        {
            OnCheckboxChange?.Invoke(this, isChecked);
        }
    }
}
