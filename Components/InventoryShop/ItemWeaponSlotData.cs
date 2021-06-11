using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/InventoryItemShop/AddNewWeaponItems", fileName = "WeaponItems")]
    public class ItemWeaponSlotData : ScriptableObject
    {
        public List<WeaponData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<WeaponData>();
            foreach (WeaponData item in Items)
            {
                Items.Add(new WeaponData());
            }
        }

        [Serializable]
        public class WeaponData
        {

            [SerializeField] private string _name;
            [SerializeField] private string _id;
            [SerializeField] private Sprite _icon;
            [TextArea(10, 100), SerializeField] private string _description;
            [SerializeField] private float _weaponAccuracy;
            [SerializeField] private float _weaponRateOfFire;
            [SerializeField] private List<AmmoType> _ammoTypes;
            [SerializeField] private List<WeaponModType> _weaponModTypes;

            [SerializeField] private ItemAmmoSlotComponent _defaultAmmo;

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

            public float WeaponAccuracy
            {
                get => _weaponAccuracy;
                set => _weaponAccuracy = value;  
            }

            public float WeaponRateOfFire
            {
                get => _weaponRateOfFire;
                set => _weaponRateOfFire = value;
            }

            public List<AmmoType> AmmoType
            {
                get => _ammoTypes;
                set => _ammoTypes = value;
            }
            public List<WeaponModType> WeaponModType
            {
                get => _weaponModTypes;
                set => _weaponModTypes = value;
            }

        }
    }

    public enum AmmoType
    {
        Bullet,
        Bang_bullet,
        Gauss_Cartridge,
        Grenade,
        Cumulative_shell,
        Cannonball,
    }

    public enum WeaponModType
    {
        
    }
}
