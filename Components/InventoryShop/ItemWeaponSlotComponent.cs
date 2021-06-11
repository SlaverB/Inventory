using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ItemWeaponSlotComponent : MonoBehaviour
    {

        [Space(10)]
        [Header("Images")]
        [SerializeField] private Image _weaponSlotIcon;
        [SerializeField] private Image _weaponSlotBg;

        public void Init(ItemWeaponSlotData.WeaponData weaponData)
        {
            _weaponSlotIcon.sprite = weaponData.Icon;
        }

        public static ItemWeaponSlotComponent CreateWeaponItemSlot(ItemWeaponSlotComponent weaponItemSlot, Transform parent)
        {
            ItemWeaponSlotComponent slot = Instantiate(weaponItemSlot, parent) as ItemWeaponSlotComponent;
            return slot;
        }
    }
}
