using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InventorySlotComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
    {
        public static InventorySlotComponent DragedObject;
        public static GameObject DragPrefab;
        public static Image DragPrefabBg;
        public static Image DragPrefabIcon;
        public static CanvasGroup DragPrefabCanvasGroup;
        public static Camera CameraUi;
        public static List<InventorySlotComponent> AllSlots;
        [Range(0f, 2f)] public float OffsetForFinger_Y = 0.5f;
        public float TestDropDistance = 1f;

        [SerializeField] private GameObject _addIcon;
        [SerializeField] private ButtonLabel _inventorySlotButton;
        [SerializeField] private InventorySlotComponent _inventorySlotComponent;

        [Space(5)]
        [Header("Sprites")]
        [SerializeField] private Sprite _activeSlot;
        [SerializeField] private Sprite _nonactiveSlot;

        [Space(10)]
        [Header("Images")]
        [SerializeField] private Image _inventorySlotIcon;
        [SerializeField] private Image _slotBackground;
        [SerializeField] private Image _inventoryIcon;

        [Space(5)]
        [Header("Types")]
        [SerializeField] private InventoryType _inventoryType;
        [SerializeField] private StimulatorType _stimulatorType;
        [SerializeField] private SlotType _slotType;

        private Vector3 _offset = Vector3.zero;
        private Vector3 _offsetForFinger = Vector3.zero;
        private Vector3 _dragPrefabScale = new Vector3(1.5f, 1.5f, 1.5f);

        public InventoryType InventoryType
        {
            get => _inventoryType;
            set => _inventoryType = value;
        }

        public StimulatorType StimulatorType
        {
            get => _stimulatorType;
            set => _stimulatorType = value;
        }

        public SlotType Slot
        {
            get => _slotType;
            set => _slotType = value;
        }

        public Image InventorySlotIcon
        {
            get => _inventorySlotIcon;
            set => _inventorySlotIcon = value;
        }

        public ButtonLabel InventorySlotButton => _inventorySlotButton;

        public bool IsDragable { get; set; }
        public bool IsSlotEmpty { get; set; } = true;

        public bool IsSlotSwitched { get; set; }

        public void Init(InventorySlotData.InventoryData inventoryData)
        {
            _inventorySlotIcon.gameObject.SetActive(true);
            _inventorySlotIcon.sprite = inventoryData.SlotIcon;
            _inventorySlotIcon.preserveAspect = true;
            _inventoryType = inventoryData.SlotType;
            _stimulatorType = inventoryData.StimulatorType;
            IsDragable = true;
            IsSlotEmpty = false;

            _offsetForFinger.y = OffsetForFinger_Y;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_inventorySlotComponent.IsDragable)
            {
                DragedObject = _inventorySlotComponent;
                DragPrefab.SetActive(true);
                DragPrefabCanvasGroup.blocksRaycasts = false;
                DragPrefab.transform.localScale = _dragPrefabScale;

                Vector3 worldPos = CameraUi.ScreenToWorldPoint(Input.mousePosition);
                worldPos.z = transform.position.z;
                _offset = worldPos - transform.position - _offsetForFinger;

                SwitchSlotsBG(_activeSlot);

                if (_inventoryIcon != null)
                {
                    DragPrefabBg.sprite = _slotBackground.sprite;
                    DragPrefabIcon.sprite = _inventoryIcon.sprite;
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 worldPos = CameraUi.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = DragPrefab.transform.position.z;
            worldPos -= _offset;
            DragPrefab.transform.position = worldPos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _offset = Vector3.zero;
            SwitchSlotsBG(_nonactiveSlot);

            DragedObject = null;
            DragPrefabCanvasGroup.blocksRaycasts = true;
            DragPrefab.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _slotBackground.sprite = _activeSlot;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsSlotSwitched)
            {
                _slotBackground.sprite = _nonactiveSlot;
            }
        }

        private void ExchangeSlot(InventorySlotComponent currentItem, InventorySlotComponent currentDragedItem)
        {
            Sprite tmpSprite = currentItem.InventorySlotIcon.sprite;
            InventoryType tmpInventoryType = currentItem.InventoryType;
            StimulatorType tmpStimulatorType = currentItem.StimulatorType;

            if (currentItem._inventoryType == currentDragedItem._inventoryType || currentItem._slotType == currentDragedItem._slotType)
            {
                currentItem.InventorySlotIcon.sprite = currentDragedItem.InventorySlotIcon.sprite;
                currentDragedItem.InventorySlotIcon.sprite = tmpSprite;
                currentItem.InventoryType = currentDragedItem.InventoryType;
                currentDragedItem.InventoryType = tmpInventoryType;
                currentItem.StimulatorType = currentDragedItem.StimulatorType;
                currentDragedItem.StimulatorType = tmpStimulatorType;
            }
        }

        private void SwitchSlotsBG(Sprite bgSprite)
        {
            foreach (InventorySlotComponent slot in AllSlots)
            {
                if (DragedObject != null && slot.IsSlotEmpty && slot._slotType != SlotType.InventorySlot && slot._inventoryType == DragedObject.InventoryType)
                {
                    slot._slotBackground.sprite = bgSprite;

                    slot.IsSlotSwitched = bgSprite == _activeSlot ? true : false;
                }
            }
        }

        public static InventorySlotComponent CreateInventorySlot(InventorySlotComponent inventorySlot, Transform parent)
        {
            InventorySlotComponent slot = Instantiate(inventorySlot, parent) as InventorySlotComponent;
            return slot;
        }

        private void DropObj(InventorySlotComponent slot)
        {
            SwitchSlotsBG(_nonactiveSlot);

            if (DragedObject == null)
            {
                return;
            }

            if (slot.IsSlotEmpty)
            {
                if (slot._inventoryType == DragedObject._inventoryType || slot._inventoryType == InventoryType.Universal)
                {
                    if (slot._slotType != SlotType.InventorySlot && slot._addIcon != null)
                    {
                        slot._addIcon.SetActive(false);
                    }

                    slot.InventorySlotIcon.gameObject.SetActive(true);

                    slot.InventorySlotIcon.sprite = DragedObject.InventorySlotIcon.sprite;
                    slot._inventoryType = DragedObject.InventoryType;
                    slot._stimulatorType = DragedObject.StimulatorType;
                    slot.IsDragable = true;
                    slot.IsSlotEmpty = false;

                    DragedObject.InventorySlotIcon.sprite = null;
                    DragedObject.InventorySlotIcon.gameObject.SetActive(false);
                    DragedObject.StimulatorType = StimulatorType.NonStimulator;
                    DragedObject.IsDragable = false;
                    DragedObject.IsSlotEmpty = true;

                    if (DragedObject._slotType == SlotType.InventorySlot)
                    {
                        DragedObject._inventoryType = InventoryType.Universal;
                    }
                    else
                    {
                        DragedObject._addIcon.SetActive(true);
                    }
                }
            }
            else
            {
                ExchangeSlot(slot._inventorySlotComponent, DragedObject);
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            float dist = Mathf.Infinity;
            InventorySlotComponent closestSlot = null;

            foreach (InventorySlotComponent slot in AllSlots)
            {
                if (slot.gameObject != DragPrefab)
                {
                    Vector3 diff = DragPrefab.transform.position - slot.transform.position;
                    float curDistance = diff.magnitude;
                    if (curDistance < dist)
                    {
                        closestSlot = slot;
                        dist = curDistance;
                    }
                }
            }

            if (dist <= TestDropDistance)
            {
                DropObj(closestSlot);
            }
        }


        public enum SlotType
        {
            InventorySlot,
            WeaponMod,
            StimulatorSlot,
            AmmoSlot
        }
    }
}
