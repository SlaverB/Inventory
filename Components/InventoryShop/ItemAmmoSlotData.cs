using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/InventoryItemShop/AddNewAmmoItems", fileName = "AmmoItems")]
    public class ItemAmmoSlotData : ScriptableObject
    {
        public List<AmmoData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<AmmoData>();
            foreach (AmmoData item in Items)
            {
                Items.Add(new AmmoData());
            }
        }

        [Serializable]
        public class AmmoData
        {

            [SerializeField] private string _name;
            [SerializeField] private string _id;
            [SerializeField] private Sprite _icon;
            [TextArea(10, 100), SerializeField] private string _description;
            [SerializeField] private float _ammoDamage;
            [SerializeField] private float _ammoReloadTime;
            [SerializeField] private int _amount;
            [SerializeField] private AmmoType _ammoType;

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

            public float AmmoDamage
            {
                get => _ammoDamage;
                set => _ammoDamage = value;
            }

            public float AmmoReloadTime
            {
                get => _ammoReloadTime;
                set => _ammoReloadTime = value;
            }

            public int Amount
            {
                get => _amount;
                set => _amount = value;
            }

            public AmmoType AmmoType
            {
                get => _ammoType;
                set => _ammoType = value;
            }
        }
    }
}
