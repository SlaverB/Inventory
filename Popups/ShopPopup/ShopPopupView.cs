using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    class ShopPopupView : BaseWindowView
    {
        [SerializeField] private ShopItemComponent _shopItem;
        [SerializeField] private ShopItemData _shopItemData;
        [SerializeField] private Transform _itemsContainer;

        public ShopItemComponent ShopItem
        {
            get => _shopItem;
            set => _shopItem = value;
        }
        public ShopItemData ShopItemData
        {
            get => _shopItemData;
            set => _shopItemData = value;
        }

        public Transform ItemsContainer
        {
            get => _itemsContainer;
            set => _itemsContainer = value;
        }
        public List<ShopItemComponent> ShopItems { get; set; }

        protected override void CreateMediator()
        {
            _mediator = new ShopPopupMediator();
        }
    }
}
