using Assets.Scripts.player;
using Assets.Scripts.Structures;
using Assets.Scripts.Tree;
using Assets.Scripts.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class App : MonoBehaviour
    {
        [SerializeField] private UpgradeSkillPopup _upgradeSkillPopup;

        private List<SkillModel> skills = new List<SkillModel>()
        {
            new SkillModel("База", 0, true, false, new List<string>{"1", "4", "2", "8", "9"}),
            new SkillModel("1", 1, false, true,new List<string>{"База" }),
            new SkillModel("2", 1, false, true, new List<string>{ "База", "3"}),
            new SkillModel("3", 1, false, true, new List<string>{ "2"}),
            new SkillModel("4", 1, false, true, new List<string>{ "База", "5", "6" }),
            new SkillModel("5", 1, false, true, new List<string>{ "4", "7" }),
            new SkillModel("6", 1, false, true, new List<string>{"4", "7" }),
            new SkillModel("7", 1, false, true, new List<string>{"5", "6" }),
            new SkillModel("8", 1, false, true, new List<string>{ "База", "10" }),
            new SkillModel("9", 1, false, true, new List<string>{ "База", "10" }),
            new SkillModel("10", 1, false, true, new List<string>{"8", "9" }),
        };

        private List<ViewData> _viewData = new List<ViewData>();



        private SkillTreeModel _skillTree;


        private void Start()
        {
            Player player = new Player();
            for (int i = 0; i < skills.Count; i++)
            {
                _viewData.Add(new ViewData
                {
                    
                    skillId = skills[i].id,
                    skillName = skills[i].id,
                    index = i,
                    activated = skills[i].isOpened
                });
            }

            _skillTree = new SkillTreeModel(player, skills);
            var skillPopup = new UpgradeSkillPopupController(player, _upgradeSkillPopup, _skillTree, _viewData);

        }
    }
}