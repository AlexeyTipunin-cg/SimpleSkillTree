using System;
using System.Collections.Generic;
using Assets.Scripts.Structures;

namespace Assets.Scripts.Tree
{
    public class SkillTreeModel
    {
        public event Action<string> onSkillLearn;
        private readonly Dictionary<string, SkillModel> _modelsStorage = new Dictionary<string, SkillModel>();
        private Graph<SkillModel> _skillGraph = new Graph<SkillModel>();

        public SkillTreeModel(List<SkillModel> skillModels)
        {
            foreach (var skillModel in skillModels)
            {
                _modelsStorage.Add(skillModel.id, skillModel);
                _skillGraph.AddNode(skillModel);
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
            bool canLearn = _skillGraph.HasPath(_modelsStorage[id], _modelsStorage["База"], model => model.isOpened);
            if (canLearn)
            {
                _modelsStorage[id].LearnSkill();
                onSkillLearn?.Invoke(id);
            }
        }


    }
}


