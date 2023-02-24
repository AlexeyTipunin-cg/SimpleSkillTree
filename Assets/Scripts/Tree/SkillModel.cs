using System.Collections.Generic;

namespace Assets.Scripts.Tree
{
    public class SkillModel
    {
        private int _cost;
        private string _name;
        private bool _isOpened;
        private bool _canForget;
        private List<string> _neighIds;
        public SkillModel(string id, int cost, bool isOpened, bool canForget, List<string> neighIds)
        {
            _name = id;
            _cost = cost;
            _isOpened = isOpened;
            _canForget = canForget;
            _neighIds = neighIds;
        }

        public void LearnSkill()
        {
            _isOpened = true;
        }

        public void ForgetSkill()
        {
            _isOpened = false;
        }

        public int cost => _cost;
        public string id => _name;
        public bool isOpened => _isOpened;
        public bool canForget => _canForget;
        public List<string> neighIds => _neighIds;
    }
}