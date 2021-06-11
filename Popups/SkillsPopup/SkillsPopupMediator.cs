using Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class SkillsPopupMediator : BaseWindowMediator<SkillsPopupView, WindowData>
    {
        private SkillSlotComponent _skill;
        private SkillSlotComponent[] _selectedSkills = new SkillSlotComponent[2];

        public override void Mediate(BaseWindowView value, GameManagersContexts managersContexts)
        {
            base.Mediate(value, managersContexts);
            Target.ImproveButton.onClick.AddListener(() => { ChangeSkillLevelText(_skill, 1); });
            Target.ZeroOutButton.onClick.AddListener(() => { ChangeSkillLevelText(_skill, -1); });
            Target.ResetAllSkillsButton.onClick.AddListener(ResetAllSkills);

            _managersContexts.UserProfileManager.OnUserSkillsChanged += UpdateSkillCount;

        }

        public override void UnMediate()
        {
            base.UnMediate();
            Target.ImproveButton.onClick.RemoveListener(() => { ChangeSkillLevelText(_skill, 1); });
            Target.ZeroOutButton.onClick.RemoveListener(() => { ChangeSkillLevelText(_skill, -1); });
            Target.ResetAllSkillsButton.onClick.RemoveListener(ResetAllSkills);

            _managersContexts.UserProfileManager.OnUserSkillsChanged -= UpdateSkillCount;
        }

        protected override void ShowStart()
        {
            if (Target.SkillSlots == null)
            {
                Target.SkillSlots = new List<SkillSlotComponent>();
                for (int i = 0; i < Target.SkillSlotData.Skills.Count; i++)
                {
                    Target.SkillSlots.Add(SkillSlotComponent.CreateSkillObject(Target.SkillSlot, Target.UserSkillsSet));
                }
            }

            foreach (SkillSlotComponent slot in Target.SkillSlots)
            {
                slot.SkillSlotButton.onClick.AddListener(() => { ShowSkillDescription(slot); });
            }

            InitCharacterSkills();
            ShowSkillDescription(Target.SkillSlots[0]);
            ChangeVisibilityScrollbar();
            UpdateSkillCount();
        }

        protected override void HideStart()
        {
            base.HideStart();
            foreach (SkillSlotComponent slot in Target.SkillSlots)
            {
                slot.SkillSlotButton.onClick.RemoveListener(() => { ShowSkillDescription(slot); });
            }
        }

        private void InitCharacterSkills()
        {
            for (int i = 0; i < Target.SkillSlots.Count; i++)
            {
                Target.SkillSlots[i].Init(Target.SkillSlotData.Skills[i]);
            }
        }

        private void ChangeVisibilityScrollbar()
        {
            Target.SkillsScrollbar.gameObject.SetActive(!Target.SkillsScrollbar.gameObject.activeSelf);
        }

        private void ShowSkillDescription(SkillSlotComponent skillSlotComponent)
        {
            if (_selectedSkills[1])
            {
                _selectedSkills[1].SelectBorderImage.SetActive(false);
            }

            _selectedSkills[0] = skillSlotComponent;
            _skill = skillSlotComponent;

            _selectedSkills[0].SelectBorderImage.SetActive(true);

            ImproveButtonVisibility(Target.ImproveButton);
            ZeroOutButtonVisibility(Target.ZeroOutButton, skillSlotComponent);

            Target.SkillNameText.text = skillSlotComponent.SkillName;
            Target.SkillDescriptionIcon.sprite = skillSlotComponent.SkillDescriptionIcon;
            Target.SkillDescriptionIcon.SetNativeSize();
            Target.SkillBenefitValueText.text = "+" + skillSlotComponent.SkillBenefitValue;
            Target.SkillDescriptionText.text = skillSlotComponent.SkillDescription;
            
            _selectedSkills[1] = skillSlotComponent;
        }

        private void ZeroOutButtonVisibility(ButtonLabel button, SkillSlotComponent skill)
        {
            string userSkillLevelPrefs = SkillSlotComponent.UserPrefsKey + skill.SkillId + SkillSlotComponent.SkillLevelPrefsKey;
            int skillLevel = PlayerPrefs.GetInt(userSkillLevelPrefs, 0);
            button.image.color = skillLevel <= 0 ? Color.grey : Color.white;
            button.enabled = skillLevel > 0;
        }

        private void ImproveButtonVisibility(ButtonLabel button)
        {
            button.image.color = _managersContexts.UserProfileManager.UserSkills <= 0 ? Color.grey : Color.white;
            button.enabled = _managersContexts.UserProfileManager.UserSkills > 0;
        }

        private void ChangeSkillLevelText(SkillSlotComponent skill, int value)
        {
            _managersContexts.UserProfileManager.ChangeSkillLevelValue(skill.SkillId, value);
            _managersContexts.UserProfileManager.ChangeSkillBenefitValue(skill.SkillId, value);

            skill.UpdateSkillParams(skill);
            ChangeSkillBenefitText(skill.SkillId);

            _managersContexts.UserProfileManager.ChangeUserSkills(-value);

            ZeroOutButtonVisibility(Target.ZeroOutButton, skill);
            ImproveButtonVisibility(Target.ImproveButton);
        }

        private void ChangeSkillBenefitText(string skillId)
        {
            string userSkillLevelPrefs = SkillSlotComponent.UserPrefsKey + skillId + SkillSlotComponent.SkillLevelPrefsKey;
            string userSkillBenefitPrefs = SkillSlotComponent.UserPrefsKey + skillId + SkillSlotComponent.SkillBenefitPrefsKey;
            
            Target.SkillBenefitLevelText.text = "+ Lv." + (PlayerPrefs.GetInt(userSkillLevelPrefs, 0) + 1);
            Target.SkillBenefitValueText.text = "+" + (PlayerPrefs.GetInt(userSkillBenefitPrefs, 0));
        }

        private void UpdateSkillCount()
        {
            Target.SkillPointsText.text = _managersContexts.UserProfileManager.UserSkills.ToString();
        }

        private void ResetAllSkills()
        {
            foreach (SkillSlotComponent slot in Target.SkillSlots)
            {
                string userSkillLevelPrefs = SkillSlotComponent.UserPrefsKey + slot.SkillId + SkillSlotComponent.SkillLevelPrefsKey;
                int skillLevel = PlayerPrefs.GetInt(userSkillLevelPrefs, 0);
                
                if (skillLevel > 0)
                {
                    for (int i = 0; i < skillLevel; i++)
                    {
                        ChangeSkillLevelText(slot, -1);
                    }
                }
            }
        }
    }
}
