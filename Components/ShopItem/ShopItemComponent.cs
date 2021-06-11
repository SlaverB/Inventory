using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class ShopItemComponent : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _itemBuyButtonIcon;
        [SerializeField] private Text _itemBuyButtonText;
        [SerializeField] private Text _itemBenefitText;
        [SerializeField] private Sprite _freeButtonIcon;
        [SerializeField] private Sprite _buyButtonIcon;
        [SerializeField] private ButtonLabel _buyButton;

        public int ItemBenefit { get; private set; }
        public ButtonLabel BuyButton
        {
            get => _buyButton;
            set => _buyButton = value;
        }
        public void Init(ShopItemData.ItemData itemData)
        {
            _itemIcon.sprite = itemData.ItemIcon;
            _itemBenefitText.text = "+" + itemData.ItemBenefitValue;

            ItemBenefit = itemData.ItemBenefitValue;

            if (itemData.ItemPrice == 0)
            {
                _itemBuyButtonIcon.sprite = _freeButtonIcon;
                _itemBuyButtonText.text = "Get it free";
            }
            else if (itemData.ItemPrice > 0)
            {
                _itemBuyButtonIcon.sprite = _buyButtonIcon;
                _itemBuyButtonText.text = "Buy $" + itemData.ItemPrice;
            }
        }

        public static ShopItemComponent CreateShopItemObject(ShopItemComponent shopItemSlot, Transform parent)
        {
            ShopItemComponent shopItem = Instantiate(shopItemSlot, parent) as ShopItemComponent;
            return shopItem;
        }
    }

}
