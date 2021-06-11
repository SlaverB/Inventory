using Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryPopupMediator : BaseWindowMediator<InventoryPopupView, WindowData>
    {
        public override void Mediate(BaseWindowView value, GameManagersContexts managersContexts)
        {
            base.Mediate(value, managersContexts);

            Target.WeaponsTabButton.onClick.AddListener(OpenTab);
            Target.AmmoTabButton.onClick.AddListener(OpenTab);
            Target.WeaponsModTabButton.onClick.AddListener(OpenTab);
            Target.StimulatorsTabButton.onClick.AddListener(OpenTab);
        }

        public override void UnMediate()
        {
            base.UnMediate();

            Target.WeaponsTabButton.onClick.RemoveListener(OpenTab);
            Target.AmmoTabButton.onClick.RemoveListener(OpenTab);
            Target.WeaponsModTabButton.onClick.RemoveListener(OpenTab);
            Target.StimulatorsTabButton.onClick.RemoveListener(OpenTab);
        }

        protected override void ShowStart()
        {
            if (Target.InventorySlots == null)
            {
                Target.InventorySlots = new List<InventorySlotComponent>();
                for (int i = 0; i < InventoryPopupView.SlotsCount; i++)
                {
                    Target.InventorySlots.Add(InventorySlotComponent.CreateInventorySlot(Target.DefaultInventorySlot, Target.SlotsContainer));
                }

                InitInventorySlots();

                Target.AllInventorySlots = new List<InventorySlotComponent>();
            }

            GetAllInventorySlots(Target.gameObject);

            InventorySlotComponent.CameraUi = _managersContexts.UiLayersManager.GetCamera();
            InventorySlotComponent.DragPrefab = Target.DragPrefab;
            InventorySlotComponent.DragPrefabBg = Target.DragPrefabBg;
            InventorySlotComponent.DragPrefabIcon = Target.DragPrefabIcon;
            InventorySlotComponent.DragPrefabCanvasGroup = Target.DragPrefabCanvasGroup;
            InventorySlotComponent.AllSlots = Target.AllInventorySlots;
        }

        protected override void HideStart()
        {
            Target.AllInventorySlots.Clear();
        }

        private void InitInventorySlots()
        {
            for (int i = 0; i < Target.InventorySlots.Count; i++)
            {
                if (i < Target.InventorySlotData.Items.Count)
                {
                    Target.InventorySlots[i].Init(Target.InventorySlotData.Items[i]);
                }
            }
        }
        private void OpenTab()
        {

        }

        private void GetAllInventorySlots(GameObject obj)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                GetChildrenInventorySlot(obj.transform.GetChild(i).gameObject);
            }
        }

        private void GetChildrenInventorySlot(GameObject currentObj)
        {
            for (int i = 0; i < currentObj.transform.childCount; i++)
            {
                GetChildrenInventorySlot(currentObj.transform.GetChild(i).gameObject);
                InventorySlotComponent slotComponent = currentObj.transform.GetChild(i).gameObject.GetComponent<InventorySlotComponent>();

                if (slotComponent != null)
                {
                    int counter = 0;
                    foreach (InventorySlotComponent slot in Target.AllInventorySlots)
                    {
                        if (slotComponent == slot)
                        {
                            counter++;
                        }
                    }

                    if (counter == 0 || Target.AllInventorySlots == null)
                    {
                        Target.AllInventorySlots.Add(slotComponent);
                    }
                }
            }

        }
    }
}
