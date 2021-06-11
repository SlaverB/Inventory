using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuHudView : BaseWindowView
    {
        [SerializeField] private ButtonLabel _buttonSkills;
        [SerializeField] private ButtonLabel _buttonOpenShop;
        [SerializeField] private ButtonLabel _buttonSkillsOnXP;
        [SerializeField] private ButtonLabel _buttonSkillsOnCurrentAmount;
        [SerializeField] private ButtonLabel _buttonAddMoney;
        [SerializeField] private ButtonLabel _buttonPlay;
        [SerializeField] private Text _textMoneyValue;
        [SerializeField] private Text _textSkillsCount;
        [SerializeField] private Text _textCurrentUserLevel;
        [SerializeField] private Image _imageCurrentXP;

        [SerializeField] private ButtonLabel _inventoryButton; //button for test inventory

        public ButtonLabel InventoryButton //button for test inventory
        {
            get => _inventoryButton;
            set => _inventoryButton = value;
        }

        public ButtonLabel ButtonSkills
        {
            get => _buttonSkills;
            set => _buttonSkills = value;
        }

        public ButtonLabel ButtonShop
        {
            get => _buttonOpenShop;
            set => _buttonOpenShop = value;
        }

        public ButtonLabel ButtonAddMoney
        {
            get => _buttonAddMoney;
            set => _buttonAddMoney = value;
        }

        public ButtonLabel ButtonSkillsOnXP
        {
            get => _buttonSkillsOnXP;
            set => _buttonSkillsOnXP = value;
        }


        public ButtonLabel ButtonSkillsOnCurrentAmount
        {
            get => _buttonSkillsOnCurrentAmount;
            set => _buttonSkillsOnCurrentAmount = value;
        }

        public ButtonLabel ButtonPlay
        {
            get => _buttonPlay;
            set => _buttonPlay = value;
        }

        public Text TextMoneyValue
        {
            get => _textMoneyValue;
            set => _textMoneyValue = value;
        }

        public Text TextSkillsCount
        {
            get => _textSkillsCount;
            set => _textSkillsCount = value;
        }

        public Text TextCurrentUserLevel
        {
            get => _textCurrentUserLevel;
            set => _textCurrentUserLevel = value;
        }

        public Image ImageCurrentXPFillAmount
        {
            get => _imageCurrentXP;
            set => _imageCurrentXP = value;
        }

        protected override void CreateMediator()
        {
            _mediator = new MenuHudMediator();
        }

    }

}