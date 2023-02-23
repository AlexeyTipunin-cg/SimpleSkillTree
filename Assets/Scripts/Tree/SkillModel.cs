namespace Assets.Scripts.Tree
{
    public class SkillModel
    {
        private int _cost;
        private string _name;
        private bool _isOpened;
        public SkillModel(string id, int cost, bool isOpened)
        {
            _name = id;
            _cost = cost;
            _isOpened = isOpened;
        }

        public int cost => _cost;
        public string id => _name;
        public bool isOpened => _isOpened;
    }
}