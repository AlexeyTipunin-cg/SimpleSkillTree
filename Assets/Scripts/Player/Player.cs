using System;

namespace Assets.Scripts.player
{
    public class Player
    {
        public event Action<int> onPointsUpdate;
        private int _points;
        public int points
        {
            get { return _points; }
            set
            {
                _points = value;
                onPointsUpdate?.Invoke(value);
            }
        }
    }
}
