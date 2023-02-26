using Assets.Scripts.player;
using Assets.Scripts.SkillTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Views
{
    public partial class UpgradeSkillPopupController
    {
        private UpgradeSkillPopup _skillPopup;
        private SkillService _skillService;
        public UpgradeSkillPopupController(SkillService skillService, UpgradeSkillPopup skillPopup)
        {
            _skillPopup = skillPopup;
            _skillService = skillService;
            _skillService.player.onSkillPointsUpdate += OnUpdateScore;

            _skillService.onSkillLearn += OnSkillLearn;
            _skillService.onSkillForget += ForgetSkill;

            _skillPopup.onEarnPointClick += AddPoints;
            _skillPopup.onSkillLearnClick += OnLearnSkillClick;
            _skillPopup.onSkillForgetClick += OnForgetSkillClick;
            _skillPopup.onForgetAllClick += OnForgetAllClick;

            skillPopup.Init(ProcessDataFromModel());
        }

        private List<SkillItemViewData> ProcessDataFromModel()
        {
            var models = _skillService.skillTreeModels;
            var data = models.Select(x => new SkillItemViewData
            {
                skillId = x.id,
                skillName = x.id,
                activated = x.isOpened,
                cost= x.cost,
                index = _skillService.skillConfig.skillToIcon[x.id]
            }).ToList();

            return data;
        }

        public void Dispose()
        {
            _skillService.player.onSkillPointsUpdate -= OnUpdateScore;

            _skillService.onSkillLearn -= OnSkillLearn;
            _skillService.onSkillForget -= ForgetSkill;

            _skillPopup.onEarnPointClick -= AddPoints;
            _skillPopup.onSkillLearnClick -= OnLearnSkillClick;
            _skillPopup.onSkillForgetClick -= OnForgetSkillClick;
        }

        private void OnUpdateScore(int skillPoints)
        {
            _skillPopup.UpdateScoreText(skillPoints);
        }

        private void ForgetSkill(string id)
        {
            _skillPopup.OnSkillForget(id);
        }

        private void OnForgetSkillClick(string id)
        {
            _skillService.ForgetSkill(id);
        }

        private void OnSkillLearn(string id)
        {
            _skillPopup.OnSkillLearn(id);
        }

        private void OnLearnSkillClick(string id)
        {
            _skillService.LearnSkill(id);
        }

        private void OnForgetAllClick()
        {
            _skillService.ForgetAllSkills();
        }

        private void AddPoints()
        {
            _skillService.player.AddSkillPoints(1);
        }
    }
}
