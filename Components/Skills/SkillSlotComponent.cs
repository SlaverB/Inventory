using Base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillSlotComponent : MonoBehaviour
    {
        public const string UserPrefsKey = "user";
        public const string SkillLevelPrefsKey = "skillLevel";
        public const string SkillBenefitPrefsKey = "skillBenefit";

        [SerializeField] private GameObject _selectBorderImage;
        [SerializeField] private Image _skillActiveIcon;
        [SerializeField] private Image _skillNonActiveIcon;
        [SerializeField] private Text _skillLevelText;
        [SerializeField] private ButtonLabel _skillSlotButton;

        private Sprite _skillDescriptionIcon;
        private Sprite _skillActiveIconSprite;
        private Sprite _skillNonActiveIconSprite;

        public GameObject SelectBorderImage
        {
            get => _selectBorderImage;
            set => _selectBorderImage = value;
        }
        public Text SkillLevelText
        {
            get => _skillLevelText;
            set => _skillLevelText = value;
        }
        public ButtonLabel SkillSlotButton
        {
            get => _skillSlotButton;
            set => _skillSlotButton = value;
        }

        public string SkillName { get; private set; }

        public string SkillId { get; private set; }
        public Sprite SkillDescriptionIcon
        {
            get => _skillDescriptionIcon;
            set => _skillDescriptionIcon = _skillActiveIcon.sprite;
        }

        public string SkillDescription { get; private set; }

        public int SkillBenefitValue { get; private set; }

        public int SkillLevel { get; set; }

        public void Init(SkillSlotData.SkillData skillData)
        { 
            string userSkillLevelPrefs = UserPrefsKey + skillData.SkillId + SkillLevelPrefsKey;
            string userSkillBenefitPrefs = UserPrefsKey + skillData.SkillId + SkillBenefitPrefsKey;

            SkillName = skillData.SkillName;
            SkillId = skillData.SkillId;
            SkillDescription = skillData.SkillDescription;
            SkillBenefitValue = skillData.SkillBenefitValue;
            SkillLevel = PlayerPrefs.GetInt(userSkillLevelPrefs, 0);

            _skillActiveIconSprite = skillData.SkillActiveIcon;
            _skillNonActiveIconSprite = skillData.SkillNonActiveIcon;
            _skillDescriptionIcon = skillData.SkillActiveIcon;
            _skillLevelText.text = SkillLevel.ToString();

            PlayerPrefs.SetInt(userSkillBenefitPrefs, SkillBenefitValue);

            _skillNonActiveIcon.sprite = PlayerPrefs.GetInt(userSkillLevelPrefs, 0) == 0 ? _skillNonActiveIconSprite : _skillActiveIconSprite;

            _selectBorderImage.SetActive(false);
        }

        public void UpdateSkillParams(SkillSlotComponent skill)
        {
            string userSkillLevelPrefs = UserPrefsKey + skill.SkillId + SkillLevelPrefsKey;
            string userSkillBenefitPrefs = UserPrefsKey + skill.SkillId + SkillBenefitPrefsKey;

            SkillLevelText.text = PlayerPrefs.GetInt(userSkillLevelPrefs, 0).ToString();
            SkillBenefitValue = PlayerPrefs.GetInt(userSkillBenefitPrefs, 0);

            _skillNonActiveIcon.sprite = PlayerPrefs.GetInt(userSkillLevelPrefs, 0) == 0 ? _skillNonActiveIconSprite : _skillActiveIconSprite;
        }

        public static SkillSlotComponent CreateSkillObject(SkillSlotComponent skillSlot, Transform parent)
        {
            SkillSlotComponent skill = Instantiate(skillSlot, parent) as SkillSlotComponent;
            return skill;
        }
    }

}
