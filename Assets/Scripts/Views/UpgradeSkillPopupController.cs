using Assets.Scripts.player;
using Assets.Scripts.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Views
{
    public partial class UpgradeSkillPopupController
    {
        private UpgradeSkillPopup _skillPopup;
        private SkillTreeModel _skillTreeModel;
        private Player _player;
        public UpgradeSkillPopupController(Player player, UpgradeSkillPopup skillPopup, SkillTreeModel skillTreeModel, List<ViewData> viewData)
        {
            _skillPopup = skillPopup;
            _player = player;
            _skillTreeModel = skillTreeModel;

            _player.onSkillPointsUpdate += OnUpdateScore;

            _skillTreeModel.onSkillLearn += OnSkillLearn;
            _skillTreeModel.onSkillForget += ForgetSkill;

            _skillPopup.onEarnPointClick += AddPoints;
            _skillPopup.onSkillLearnClick += OnLearnSkillClick;
            _skillPopup.onSkillForgetClick += OnForgetSkillClick;

            skillPopup.Init(viewData);
        }

        public void Dispose()
        {
            _player.onSkillPointsUpdate -= OnUpdateScore;

            _skillTreeModel.onSkillLearn -= OnSkillLearn;
            _skillTreeModel.onSkillForget -= ForgetSkill;

            _skillPopup.onEarnPointClick -= AddPoints;
            _skillPopup.onSkillLearnClick -= OnLearnSkillClick;
            _skillPopup.onSkillForgetClick -= OnForgetSkillClick;
        }

        private void OnUpdateScore(int skillPoints)
        {
            _skillPopup.UpdateScoreText(skillPoints.ToString());
        }

        private void ForgetSkill(string id)
        {
            _skillPopup.OnSkillForget(id);
        }

        private void OnForgetSkillClick(string id)
        {
            _skillTreeModel.ForgetSkill(id);
        }

        private void OnSkillLearn(string id)
        {
            _skillPopup.OnSkillLearn(id);
        }

        private void OnLearnSkillClick(string id)
        {
            _skillTreeModel.LearnSkill(id);
        }

        private void AddPoints()
        {
            _player.AddSkillPoints(1);
        }
    }
}
