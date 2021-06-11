using Base;
using Descriptions;
using DG.Tweening;
using System;
using UnityEngine;

namespace UI
{
    public class MenuHudMediator : BaseWindowMediator<MenuHudView, WindowData>
    {
        private const float _durationChangeXp = 2f;

        public override void Mediate(BaseWindowView value, GameManagersContexts gameManagersContexts)
        {
            base.Mediate(value, gameManagersContexts);
            Target.ButtonPlay.onClick.AddListener(Play);
            Target.ButtonSkills.onClick.AddListener(() => { OpenWindow(WindowType.SkillsPopup); });
            Target.ButtonShop.onClick.AddListener(() => { OpenWindow(WindowType.ShopPopup); });
            Target.ButtonAddMoney.onClick.AddListener(() => { OpenWindow(WindowType.ShopPopup); });
            Target.ButtonSkillsOnXP.onClick.AddListener(() => { OpenWindow(WindowType.SkillsPopup); });
            Target.ButtonSkillsOnCurrentAmount.onClick.AddListener(() => { OpenWindow(WindowType.SkillsPopup); });

            Target.InventoryButton.onClick.AddListener(() => { OpenWindow(WindowType.InventoryPopup); }); //button for test inventory

            _managersContexts.UserProfileManager.OnUserLevelChanged += UserLevelChanged;
            _managersContexts.UserProfileManager.OnUserXpChanged += UpdateCurrentXp;
            _managersContexts.UserProfileManager.OnUserSkillsChanged += UpdateSkillCount;
            _managersContexts.UserProfileManager.OnUserMoneyChanged += UpdateMoneyCount;
        }

        public override void UnMediate()
        {
            base.UnMediate();
            Target.ButtonPlay.onClick.RemoveListener(Play);
            Target.ButtonSkills.onClick.RemoveListener(() => { OpenWindow(WindowType.SkillsPopup); });
            Target.ButtonShop.onClick.RemoveListener(() => { OpenWindow(WindowType.ShopPopup); });
            Target.ButtonShop.onClick.RemoveListener(() => { OpenWindow(WindowType.ShopPopup); });
            Target.ButtonSkillsOnXP.onClick.RemoveListener(() => { OpenWindow(WindowType.SkillsPopup); });
            Target.ButtonSkillsOnCurrentAmount.onClick.RemoveListener(() => { OpenWindow(WindowType.SkillsPopup); });

            Target.InventoryButton.onClick.RemoveListener(() => { OpenWindow(WindowType.InventoryPopup); }); //button for test inventory

            _managersContexts.UserProfileManager.OnUserLevelChanged -= UserLevelChanged;
            _managersContexts.UserProfileManager.OnUserXpChanged -= UpdateCurrentXp;
            _managersContexts.UserProfileManager.OnUserSkillsChanged -= UpdateSkillCount;
            _managersContexts.UserProfileManager.OnUserMoneyChanged -= UpdateMoneyCount;
        }

        protected override void ShowStart()
        {
            base.ShowStart();

            UpdateSkillCount();
            UpdateMoneyCount();
            UpdateTextCurrentUserLevel();
        }

        private void UpdateSkillCount()
        {
            Target.TextSkillsCount.text = _managersContexts.UserProfileManager.UserSkills.ToString();
        }

        private void UpdateMoneyCount()
        {
            Target.TextMoneyValue.text = _managersContexts.UserProfileManager.UserMoney.ToString();
        }

        private void UpdateTextCurrentUserLevel()
        {
            Target.TextCurrentUserLevel.text = "Lv." + _managersContexts.UserProfileManager.UserLevel;

            UpdateCurrentXp();
        }

        private void UserLevelChanged()
        {
            var durationMoveXpFast = 1.5f;
            int addedSkill = 1;

            Target.ImageCurrentXPFillAmount.DOFillAmount(1, durationMoveXpFast).OnComplete(() =>
            {
                Target.TextCurrentUserLevel.text = "Lv." + _managersContexts.UserProfileManager.UserLevel;
                Target.ImageCurrentXPFillAmount.fillAmount = 0;
                _managersContexts.UserProfileManager.ChangeUserSkills(addedSkill);
                float amount = (float)(_managersContexts.UserProfileManager.UserXp - PlayerLevelsDescription.MinXpOnCurrentLevel) / PlayerLevelsDescription.LengthXpOnCurrentLevel;
                Target.ImageCurrentXPFillAmount.DOFillAmount(amount, _durationChangeXp);
            });
        }

        private void UpdateCurrentXp()
        {
            PlayerLevelsDescription.GetUserLevelByXp(_managersContexts.UserProfileManager.UserXp);

            float amount = (float)(_managersContexts.UserProfileManager.UserXp - PlayerLevelsDescription.MinXpOnCurrentLevel) / PlayerLevelsDescription.LengthXpOnCurrentLevel;

            Target.ImageCurrentXPFillAmount.DOFillAmount(amount, _durationChangeXp);
        }

        private void OpenWindow(WindowType windowType)
        {
            _managersContexts.WindowsManager.Open(windowType);
        }

        private void Play()
        {
            _managersContexts.GameStateManager.Current = GameState.Game;
            _managersContexts.GameStateManager.STATE_CHANGED += DisableWindow;
        }

        private void DisableWindow(GameState state)
        {
            _managersContexts.GameStateManager.STATE_CHANGED -= DisableWindow;
            Target.gameObject.SetActive(false);
        }



    }
}