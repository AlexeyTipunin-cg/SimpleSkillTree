using Assets.Scripts.player;
using Assets.Scripts.SkillTree;
using Assets.Scripts.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class App : MonoBehaviour
    {
        [SerializeField] private UpgradeSkillPopup _upgradeSkillPopup;

        private SkillTreeModel _skillTreeModel;


        private void Start()
        {
            SkillConfig skillConfig = new SkillConfig();
            Player player = new Player();
            _skillTreeModel = new SkillTreeModel(skillConfig.skills);
            var skillService = new SkillService(player, _skillTreeModel, skillConfig);
            var skillPopupController = new UpgradeSkillPopupController(skillService, _upgradeSkillPopup);
        }
    }
}