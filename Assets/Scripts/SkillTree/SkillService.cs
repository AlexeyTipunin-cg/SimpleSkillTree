using Assets.Scripts.player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.SkillTree
{
    public class SkillService
    {
        public event Action<string> onSkillForget
        {
            add { _skillTreeModel.onSkillForget += value; }
            remove { _skillTreeModel.onSkillForget -= value; }
        }

        public event Action<string> onSkillLearn
        {
            add { _skillTreeModel.onSkillLearn += value; }
            remove { _skillTreeModel.onSkillLearn -= value; }
        }


        private readonly Player _player;
        private readonly SkillTreeModel _skillTreeModel;
        private readonly SkillConfig _skillConfig;

        public SkillService(Player player, SkillTreeModel skillTreeModel, SkillConfig skillConfig)
        {
            _player = player;
            _skillTreeModel = skillTreeModel;
            _skillConfig = skillConfig;
        }

        public Player player => _player;
        public List<SkillModel> skillTreeModels => _skillTreeModel.modelsStorage.Values.ToList();
        public SkillConfig skillConfig => _skillConfig;

        public void LearnSkill(string id)
        {
            var targetModel = _skillTreeModel.modelsStorage[id];
            bool skillsConnected = _skillTreeModel.AreSkillsConnected(targetModel);
            if (!skillsConnected)
            {
                return;
            }

            bool notEnoughSkillPoints = _player.skillPoints < targetModel.cost;
            if (notEnoughSkillPoints)
            {
                return;
            }

            _player.SpendSkillPoints(targetModel.cost);
            _skillTreeModel.LearnSkill(targetModel);
        }

        public void ForgetAllSkills()
        {
            foreach (var skill in _skillTreeModel.modelsStorage.Values)
            {
                if (skill.canForget && skill.isOpened)
                {
                    _player.AddSkillPoints(skill.cost);
                    _skillTreeModel.ForgetSkill(skill);
                }
            }
        }

        public void ForgetSkill(string id)
        {
            if (_skillTreeModel.modelsStorage.TryGetValue(id, out var targetModel))
            {
                if (!targetModel.isOpened)
                {
                    return;
                }

                var isGraphOk = _skillTreeModel.AreNeighborsConnectedIfDeleted(targetModel);
                if (!isGraphOk)
                {
                    return;
                }

                bool notEnoughSkillPoints = _player.skillPoints < targetModel.cost;
                if (notEnoughSkillPoints)
                {
                    return;
                }

                _player.AddSkillPoints(targetModel.cost);
                _skillTreeModel.ForgetSkill(targetModel);
            }
        }
    }
}
