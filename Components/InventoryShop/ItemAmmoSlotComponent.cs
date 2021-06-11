using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ItemAmmoSlotComponent : MonoBehaviour
    {
        [Space(10)]
        [Header("Images")]
        [SerializeField] private Image _ammoSlotIcon;
        [SerializeField] private Image _ammoSlotBg;

        public void Init(ItemAmmoSlotData.AmmoData ammoData)
        {
            _ammoSlotIcon.sprite = ammoData.Icon;
        }

        public static ItemAmmoSlotComponent CreateWeaponItemSlot(ItemAmmoSlotComponent ammoItemSlot, Transform parent)
        {
            ItemAmmoSlotComponent slot = Instantiate(ammoItemSlot, parent) as ItemAmmoSlotComponent;
            return slot;
        }
    }
}
