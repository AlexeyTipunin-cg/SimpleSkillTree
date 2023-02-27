using Assets.Scripts.player;
using Assets.Scripts.Resources;
using Assets.Scripts.SkillTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Views
{
    public partial class UpgradeSkillPopupController
    {
        private ISkillPopup<SkillItemViewData> _skillPopup;
        private SkillService _skillService;
        public UpgradeSkillPopupController(SkillService skillService, ISkillPopup<SkillItemViewData> skillPopup)
        {
            _skillPopup = skillPopup;
            _skillService = skillService;
            _skillService.player.SubscribeResource(ResourceTypes.SkillPoints, OnUpdateScore);

            _skillService.onSkillLearn += OnSkillLearn;
            _skillService.onSkillForget += ForgetSkill;

            _skillPopup.onEarnPointClick += AddPoints;
            _skillPopup.onSkillLearnClick += OnLearnSkillClick;
            _skillPopup.onSkillForgetClick += OnForgetSkillClick;
            _skillPopup.onForgetAllClick += OnForgetAllClick;

            skillPopup.Init(ProcessSkillModels());
        }

        private List<SkillItemViewData> ProcessSkillModels()
        {
            var models = _skillService.skillTreeModels;
            List<SkillItemViewData> viewData = new List<SkillItemViewData>();
            foreach (var modelPair in models)
            {
                var data = ProcessModel(modelPair.Key);
                viewData.Add(data);
            }

            return viewData;
        }

        private SkillItemViewData ProcessModel(string key)
        {
            var skill = _skillService.skillTreeModels[key];
            return new SkillItemViewData
            {
                skillId = skill.id,
                skillName = skill.name,
                activated = skill.isOpened,
                cost = skill.cost.value,
                index = _skillService.skillConfig.skillToIcon[skill.id]
            };
        }

        public void Dispose()
        {
            _skillService.player.UnsubscribeResource(ResourceTypes.SkillPoints, OnUpdateScore);

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
            var data = ProcessModel(id);
            _skillPopup.OnSkillForget(data);
        }

        private void OnForgetSkillClick(string id)
        {
            _skillService.ForgetSkill(id);
        }

        private void OnSkillLearn(string id)
        {
            var data = ProcessModel(id);
            _skillPopup.OnSkillLearn(data);
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
            _skillService.player.AddResource(new Resource { type = ResourceTypes.SkillPoints, value = 1 });
        }
    }
}
