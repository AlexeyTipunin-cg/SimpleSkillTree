using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class UpgradeSkillPopup : MonoBehaviour
    {
        public event Action onEarnPointCLick;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _skillCostText;

        [SerializeField] private Button _learnSkillBtn;
        [SerializeField] private Button _forgetSkillBtn;
        [SerializeField] private Button _foregetAllBtn;

        [SerializeField] private Button _earnPointBtn;

        [SerializeField] private SkillItemView[] _skillItemView;

        public void Init()
        {
            _earnPointBtn.onClick.AddListener(OnEarnPointClick);
        }

        public void UpdateScoreText(string scoreText)
        {
            _scoreText.text = scoreText;
        }

        private void OnEarnPointClick()
        {
            onEarnPointCLick?.Invoke();
        }
    }
}