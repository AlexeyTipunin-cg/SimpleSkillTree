using Assets.Scripts.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Views
{
    public class UpgradeSkillPopupController
    {
        private UpgradeSkillPopup _skillPopup;
        private Player _player;
        public UpgradeSkillPopupController(Player player, UpgradeSkillPopup skillPopup)
        {
            _skillPopup = skillPopup;
            _player = player;

            _player.onPointsUpdate += OnUpdateScore;
            _skillPopup.onEarnPointCLick += AddPoints;
        }

        public void Dispose()
        {
            _player.onPointsUpdate -= OnUpdateScore;
            _skillPopup.onEarnPointCLick -= AddPoints;
        }

        private void OnUpdateScore(int skillPoints)
        {
            _skillPopup.UpdateScoreText(skillPoints.ToString());
        }

        private void AddPoints()
        {
            _player.points += 1;
        }
    }
}
