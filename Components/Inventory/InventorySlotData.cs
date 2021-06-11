using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    [CreateAssetMenu(menuName = "GameTools/AddNewInventorySlot", fileName = "InventorySlot")]

    public class InventorySlotData : ScriptableObject
    {
        public List<InventoryData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<InventoryData>();
            foreach (InventoryData item in Items)
            {
                Items.Add(new InventoryData());
            }
        }

        [Serializable]
        public class InventoryData
        {

            [SerializeField] private string _slotName;
            [SerializeField] private string _slotId;
            [SerializeField] private InventoryType _slotType;
            [SerializeField] private StimulatorType _stimulatorType;
            [SerializeField] private Sprite _slotIcon;
            [TextArea(10, 100), SerializeField] private string _slotDescription;


            public InventoryType SlotType
            {
                get => _slotType;
                set => _slotType = value;
            }

            public StimulatorType StimulatorType
            {
                get => _stimulatorType;
                set => _stimulatorType = value;
            }

            public string SlotName
            {
                get => _slotName;
                set => _slotName = value;
            }
            public string SlotId
            {
                get => _slotId;
                set => _slotId = value;
            }
            public Sprite SlotIcon
            {
                get => _slotIcon;
                set => _slotIcon = value;
            }
            public string SlotDescription
            {
                get => _slotDescription;
                set => _slotDescription = value;
            }
        }
    }

    public enum InventoryType
    {
        Weapons,
        Ammo,
        WeaponMod,
        Stimulator,
        Universal,
    }

    public enum StimulatorType
    {
        MoneyStimulator,
        ArmorStimulator,
        DamageStimulator,
        ReloadingStimulator,
        XpStimulator,
        InfluenceDelayStimulator,
        NonStimulator,
    }
}