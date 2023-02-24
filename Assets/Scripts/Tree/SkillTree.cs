using System.Collections.Generic;
using Assets.Scripts.Structures;

namespace Assets.Scripts.Tree
{
    public class SkillTree
    {
        private readonly Dictionary<string, SkillModel> _modelsStorage = new Dictionary<string, SkillModel>();
        private Graph<SkillModel> _skillGraph = new Graph<SkillModel>();

        public SkillTree(List<SkillModel> skillModels)
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
    }
}


