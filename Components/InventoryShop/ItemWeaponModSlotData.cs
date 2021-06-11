using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/InventoryItemShop/AddNewWeaponModItems", fileName = "WeaponModItems")]
    public class ItemWeaponModSlotData : ScriptableObject
    {
        public List<WeaponModData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<WeaponModData>();
            foreach (WeaponModData item in Items)
            {
                Items.Add(new WeaponModData());
            }
        }

        [Serializable]
        public class WeaponModData
        {

            [SerializeField] private string _name;
            [SerializeField] private string _id;
            [SerializeField] private Sprite _icon;
            [TextArea(10, 100), SerializeField] private string _description;
            [SerializeField] private int _weaponModBenefit;
            [SerializeField] private int _amount;
            [SerializeField] private WeaponModType _weaponModType;

            public string Name
            {
                get => _name;
                set => _name = value;
            }

            public string Id
            {
                get => _id;
                set => _id = value;
            }

            public Sprite Icon
            {
                get => _icon;
                set => _icon = value;
            }

            public string Description
            {
                get => _description;
                set => _description = value;
            }

            public int WeaponModBenefit
            {
                get => _weaponModBenefit;
                set => _weaponModBenefit = value;
            }

            public int Amount
            {
                get => _amount;
                set => _amount = value;
            }

            public WeaponModType WeaponModType
            {
                get => _weaponModType;
                set => _weaponModType = value;
            }
        }
    }
}
