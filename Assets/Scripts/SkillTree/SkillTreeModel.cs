using System;
using System.Collections.Generic;
using Assets.Scripts.player;
using Assets.Scripts.Structures;

namespace Assets.Scripts.SkillTree
{
    public class SkillTreeModel
    {
        public event Action<string> onSkillLearn;
        public event Action<string> onSkillForget;

        private readonly Dictionary<string, SkillModel> _modelsStorage = new Dictionary<string, SkillModel>();
        private Graph<SkillModel> _skillGraph;

        public SkillTreeModel(List<SkillModel> skillModels)
        {
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

        public IReadOnlyDictionary<string, SkillModel> modelsStorage => _modelsStorage;

        public bool AreSkillsConnected(SkillModel targetSkill)
        {
            return _skillGraph.AreNodesConnected(targetSkill, _skillGraph.root.value, model => model.isOpened);
        }

        public bool AreNeighborsConnectedIfDeleted(SkillModel targetSkill)
        {
            var neighbours = _skillGraph.FilterNeighbors(targetSkill, m => m.isOpened);
            var isGraphOk = _skillGraph.AreNodesConnected(neighbours, _skillGraph.root.value, m => m.isOpened && m != targetSkill);
            return isGraphOk;
        }

        public void LearnSkill(SkillModel targetSkill)
        {
            targetSkill.LearnSkill();
            onSkillLearn?.Invoke(targetSkill.id);
        }

        public void ForgetSkill(SkillModel targetSkill)
        {
            targetSkill.ForgetSkill();
            onSkillForget?.Invoke(targetSkill.id);
        }
    }
}


