using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class SkillsPopupView : BaseWindowView
    {
        [SerializeField] private ButtonLabel _resetAllSkillsButton;
        [SerializeField] private Text _skillPointsText;
        [SerializeField] private Scrollbar _skillsScrollbar;
        [SerializeField] private SkillSlotComponent _skillSlot;
        [SerializeField] private Transform _userSkillsSet;
        [SerializeField] private SkillSlotData _skillSlotData;

        #region DescriptionPanel
        [SerializeField] private Text _skillNameText;
        [SerializeField] private Image _skillDescriptionIcon;
        [SerializeField] private Text _skillDescriptionText;
        [SerializeField] private Text _skillBenefitLevelText;
        [SerializeField] private Text _skillBenefitValueText;
        [SerializeField] private ButtonLabel _improveButton;
        [SerializeField] private ButtonLabel _zeroOutButton;
        #endregion

        #region Properties
        public SkillSlotComponent SkillSlot
        {
            get => _skillSlot;
            set => _skillSlot = value;
        }
        public List<SkillSlotComponent> SkillSlots { get; set; }

        public ButtonLabel ResetAllSkillsButton
        {
            get => _resetAllSkillsButton;
            set => _resetAllSkillsButton = value;
        }

        public Scrollbar SkillsScrollbar
        {
            get => _skillsScrollbar;
            set => _skillsScrollbar = value;
        }

        public Text SkillPointsText
        {
            get => _skillPointsText;
            set => _skillPointsText = value;
        }

        public Text SkillNameText
        {
            get => _skillNameText;
            set => _skillNameText = value;
        }

        public Image SkillDescriptionIcon
        {
            get => _skillDescriptionIcon;
            set => _skillDescriptionIcon = value;
        }

        public Text SkillDescriptionText
        {
            get => _skillDescriptionText;
            set => _skillDescriptionText = value;
        }

        public Text SkillBenefitLevelText
        {
            get => _skillBenefitLevelText;
            set => _skillBenefitLevelText = value;
        }

        public Text SkillBenefitValueText
        {
            get => _skillBenefitValueText;
            set => _skillBenefitValueText = value;
        }

        public ButtonLabel ImproveButton
        {
            get => _improveButton;
            set => _improveButton = value;
        }

        public ButtonLabel ZeroOutButton
        {
            get => _zeroOutButton;
            set => _zeroOutButton = value;
        }

        public SkillSlotData SkillSlotData
        {
            get => _skillSlotData;
            set => _skillSlotData = value;
        }
        public Transform UserSkillsSet
        {
            get => _userSkillsSet;
            set => _userSkillsSet = value;
        }
        #endregion

        protected override void CreateMediator()
        {
            _mediator = new SkillsPopupMediator();
        }
    }
}
