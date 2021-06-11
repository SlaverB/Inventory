using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace UI
{
    [CreateAssetMenu(menuName = "GameTools/AddNewSkill", fileName = "Skills")]
    public class SkillSlotData : ScriptableObject
    {
        public List<SkillData> Skills;

        public void FillList()
        {
            if (Skills != null && Skills.Count > 0)
            {
                return;
            }
            Skills = new List<SkillData>();
            foreach (SkillData skill in Skills)
            {
                Skills.Add(new SkillData());
            }
        }

        [Serializable]
        public class SkillData
        {
            [SerializeField] private string _skillName;
            [SerializeField] private string _skillId;
            [SerializeField] private Sprite _skillActiveIcon;
            [SerializeField] private Sprite _skillNonActiveIcon;
            [TextArea(10, 100), SerializeField] private string _skillDescription;
            [SerializeField] private int _skillBenefitValue;

            public string SkillName => _skillName;
            public string SkillId => _skillId;
            public Sprite SkillActiveIcon => _skillActiveIcon;
            public Sprite SkillNonActiveIcon => _skillNonActiveIcon;
            public string SkillDescription => _skillDescription;
            public int SkillBenefitValue => _skillBenefitValue;
        }
    }
}
