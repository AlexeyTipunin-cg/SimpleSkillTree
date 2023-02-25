using System;

namespace Assets.Scripts.player
{
    public class Player
    {
        public event Action<int> onSkillPointsUpdate;
        private int _skillPoints;

        public int skillPoints => _skillPoints;
        public void AddSkillPoints(int value)
        {
            _skillPoints += value;
            onSkillPointsUpdate?.Invoke(_skillPoints);
        }

        public void SpendSkillPoints(int value)
        {
            _skillPoints -= value;
            onSkillPointsUpdate?.Invoke(_skillPoints);
        }
    }
}
