using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class ShopPopupMediator : BaseWindowMediator<ShopPopupView, WindowData>
    {
        public override void Mediate(BaseWindowView value, GameManagersContexts managersContexts)
        {
            base.Mediate(value, managersContexts);
        }

        public override void UnMediate()
        {
            base.UnMediate();

        }
        protected override void ShowStart()
        {
            if (Target.ShopItems == null)
            {
                Target.ShopItems = new List<ShopItemComponent>();
                for (int i = 0; i < Target.ShopItemData.Items.Count; i++)
                {
                    Target.ShopItems.Add(ShopItemComponent.CreateShopItemObject(Target.ShopItem, Target.ItemsContainer));
                }
            }

            foreach (ShopItemComponent item in Target.ShopItems)
            {
                item.BuyButton.onClick.AddListener(() => { BuyItem(item); });
            }

            InitShopItems();
        }

        protected override void HideStart()
        {
            base.HideStart();
            foreach (ShopItemComponent item in Target.ShopItems)
            {
                item.BuyButton.onClick.RemoveListener(() => { BuyItem(item); });
            }
        }
        private void InitShopItems()
        {
            for (int i = 0; i < Target.ShopItems.Count; i++)
            {
                Target.ShopItems[i].Init(Target.ShopItemData.Items[i]);
            }
        }

        private void BuyItem(ShopItemComponent item)
        {
            int value = item.ItemBenefit;
            _managersContexts.UserProfileManager.ChangeUserMoney(value);
        }
    }
}
