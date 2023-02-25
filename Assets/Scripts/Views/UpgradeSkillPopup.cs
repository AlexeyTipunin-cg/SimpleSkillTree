using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class UpgradeSkillPopup : MonoBehaviour
    {
        public event Action onEarnPointClick;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _skillCostText;

        [SerializeField] private Button _learnSkillBtn;
        [SerializeField] private Button _forgetSkillBtn;
        [SerializeField] private Button _foregetAllBtn;

        [SerializeField] private Button _earnPointBtn;

        [SerializeField] private SkillItemView[] _skillItemView;

        private SkillItemView _selectedSkill;

        public void Init(List<ViewData> viewData)
        {
            _earnPointBtn.onClick.AddListener(OnEarnPointClick);
            _learnSkillBtn.onClick.AddListener(OnLearnSkillClick);

            foreach (var data in viewData)
            {
                var view = _skillItemView[data.index];
                view.onSelect += OnSkillSelect;
                view.Init(data);
                view.Unselect();
            }

            _selectedSkill = _skillItemView[0];
        }

        public void UpdateScoreText(string scoreText)
        {
            _scoreText.text = scoreText;
        }

        public void UpdateSkillCostText(string skillCost)
        {
            _skillCostText.text = skillCost;
        }

        private void OnEarnPointClick()
        {
            onEarnPointClick?.Invoke();
        }

        private void OnLearnSkillClick()
        {

        }

        private void OnSkillSelect(SkillItemView view)
        {
            _selectedSkill.Unselect();
            _selectedSkill = view;
            _selectedSkill.Select();
        }
    }
}