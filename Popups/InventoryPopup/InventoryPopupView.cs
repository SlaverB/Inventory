using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryPopupView : BaseWindowView
    {
        public const int SlotsCount = 10;

        [SerializeField] private ButtonLabel _weaponsTabButton;
        [SerializeField] private ButtonLabel _ammoTabButton;
        [SerializeField] private ButtonLabel _weaponsModTabButton;
        [SerializeField] private ButtonLabel _stimulatorsTabButton;
        [SerializeField] private InventorySlotComponent _defaultInventorySlot;
        [SerializeField] private Transform _slotsContainer;
        [SerializeField] private InventorySlotData _inventorySlotData;
        [SerializeField] private GameObject _dragPrefab;
        [SerializeField] private Image _dragPrefabBg;
        [SerializeField] private Image _dragPrefabIcon;
        [SerializeField] private CanvasGroup _dragPrefabCanvasGroup;

        public ButtonLabel WeaponsTabButton => _weaponsTabButton;
        public ButtonLabel AmmoTabButton => _ammoTabButton;
        public ButtonLabel WeaponsModTabButton => _weaponsModTabButton;
        public ButtonLabel StimulatorsTabButton => _stimulatorsTabButton;

        public List<InventorySlotComponent> InventorySlots { get; set; }
        public List<InventorySlotComponent> AllInventorySlots { get; set; }

        public InventorySlotComponent DefaultInventorySlot => _defaultInventorySlot;

        public Transform SlotsContainer => _slotsContainer;

        public InventorySlotData InventorySlotData
        {
            get => _inventorySlotData;
            set => _inventorySlotData = value;
        }

        public CanvasGroup DragPrefabCanvasGroup
        {
            get => _dragPrefabCanvasGroup;
            set => _dragPrefabCanvasGroup = value;
        }
        public GameObject DragPrefab
        {
            get => _dragPrefab;
            set => _dragPrefab = value;
        }

        public Image DragPrefabIcon
        {
            get => _dragPrefabIcon;
            set => _dragPrefabIcon = value;
        }

        public Image DragPrefabBg
        {
            get => _dragPrefabBg;
            set => _dragPrefabBg = value;
        }

        protected override void CreateMediator()
        {
            _mediator = new InventoryPopupMediator();
        }
    }
}
