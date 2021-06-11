using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ItemWeaponModSlotComponent : MonoBehaviour
    {
        [Space(10)]
        [Header("Images")]
        [SerializeField] private Image _weaponModSlotIcon;
        [SerializeField] private Image _weaponModSlotBg;

        public void Init(ItemWeaponModSlotData.WeaponModData weaponModData)
        {
            _weaponModSlotIcon.sprite = weaponModData.Icon;
        }

        public static ItemWeaponModSlotComponent CreateWeaponItemSlot(ItemAmmoSlotComponent ammoItemSlot, Transform parent)
        {
            ItemWeaponModSlotComponent slot = Instantiate(ammoItemSlot, parent) as ItemWeaponModSlotComponent;
            return slot;
        }
    }
}
