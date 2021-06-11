using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/InventoryItemShop/AddNewStimulatorItems", fileName = "StimulatorItems")]
    public class ItemStimulatorSlotData : ScriptableObject
    {
        public List<StimulatorData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<StimulatorData>();
            foreach (StimulatorData item in Items)
            {
                Items.Add(new StimulatorData());
            }
        }

        [Serializable]
        public class StimulatorData
        {

            [SerializeField] private string _name;
            [SerializeField] private string _id;
            [SerializeField] private Sprite _icon;
            [TextArea(10, 100), SerializeField] private string _description;
            [SerializeField] private int _amount;
            [SerializeField] private int _stimulatorBenefit;

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

            public int Amount
            {
                get => _amount;
                set => _amount = value;
            }

            public int StimulatorBenefit
            {
                get => _stimulatorBenefit;
                set => _stimulatorBenefit = value;
            }
        }
    }
}
