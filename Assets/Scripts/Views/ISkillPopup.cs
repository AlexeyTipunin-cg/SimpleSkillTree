using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Views
{
    public interface ISkillPopup<T>
    {
        public event Action onEarnPointClick;
        public event Action<string> onSkillLearnClick;
        public event Action<string> onSkillForgetClick;
        public event Action onForgetAllClick;
        public void Init(List<T> viewData);
        public void UpdateScoreText(int score);
        public void OnSkillLearn(T data);
        public void OnSkillForget(T data);
    }
}
