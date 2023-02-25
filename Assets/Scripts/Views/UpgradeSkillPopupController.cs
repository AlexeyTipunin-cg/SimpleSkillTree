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

            _player.onPointsUpdate += OnUpdateScore;
            _skillTreeModel.onSkillLearn += skillPopup.OnSkillLearn;
            _skillPopup.onEarnPointClick += AddPoints;
            _skillPopup.onSkillLearnClick += OnLearnSkill;

            skillPopup.Init(viewData);
        }

        public void Dispose()
        {
            _player.onPointsUpdate -= OnUpdateScore;
            _skillPopup.onEarnPointClick -= AddPoints;
        }

        private void OnUpdateScore(int skillPoints)
        {
            _skillPopup.UpdateScoreText(skillPoints.ToString());
        }

        private void OnLearnSkill(string id)
        {
            _skillTreeModel.LearnSkill(id);
        }

        private void AddPoints()
        {
            _player.points += 1;
        }
    }
}
