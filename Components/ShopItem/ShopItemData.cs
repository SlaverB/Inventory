using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/AddNewShopItem", fileName = "ShopItem")]
    public class ShopItemData : ScriptableObject
    {
        public List<ItemData> Items;

        public void FillList()
        {
            if (Items != null && Items.Count > 0)
            {
                return;
            }
            Items = new List<ItemData>();
            foreach (ItemData item in Items)
            {
                Items.Add(new ItemData());
            }
        }

        [Serializable]
        public class ItemData
        {
            [SerializeField] private Sprite _itemIcon;
            [SerializeField] private float _itemPrice;
            [SerializeField] private int _itemBenefitValue;

            public int ItemBenefitValue => _itemBenefitValue;
            public float ItemPrice => _itemPrice;
            public Sprite ItemIcon => _itemIcon;
        }
    }
}
