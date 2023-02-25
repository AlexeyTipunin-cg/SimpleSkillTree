using System;
using System.Collections.Generic;
using Assets.Scripts.player;
using Assets.Scripts.Structures;

namespace Assets.Scripts.Tree
{
    public class SkillTreeModel
    {
        public event Action<string> onSkillLearn;
        public event Action<string> onSkillForget;
        private Player _player;
        private readonly Dictionary<string, SkillModel> _modelsStorage = new Dictionary<string, SkillModel>();
        private Graph<SkillModel> _skillGraph;

        public SkillTreeModel(Player player, List<SkillModel> skillModels)
        {
            _player = player;

            _skillGraph = new Graph<SkillModel>();
            foreach (var skillModel in skillModels)
            {
                if (!skillModel.canForget)
                {
                    _skillGraph.AddRootNode(skillModel);
                }
                else
                {
                    _skillGraph.AddNode(skillModel);
                }

                _modelsStorage.Add(skillModel.id, skillModel);

            }

            foreach (var model in _modelsStorage.Values)
            {
                foreach (var skillModel in model.neighIds)
                {
                    _skillGraph.AddEdge(model, _modelsStorage[skillModel]);
                }
            }
        }

        public void LearnSkill(string id)
        {
            var targetModel = _modelsStorage[id];
            bool canLearn = _skillGraph.HasPath(targetModel, _skillGraph.root.Value, model => model.isOpened);
            if (canLearn)
            {
                if (_player.skillPoints >= targetModel.cost)
                {
                    _player.SpendSkillPoints(targetModel.cost);
                    _modelsStorage[id].LearnSkill();
                    onSkillLearn?.Invoke(id);
                }
            }
        }

        public void ForgetSkill(string id)
        {
            if (_modelsStorage.TryGetValue(id, out var model))
            {
                if (model.isOpened && !_skillGraph.hasLeaf(model, _skillGraph.root.Value, m => m.isOpened, m => { return m.isOpened && m != model; }))
                {
                    _player.AddSkillPoints(model.cost);
                    _modelsStorage[id].ForgetSkill();
                    onSkillForget?.Invoke(id);
                }
            }
        }


    }
}


