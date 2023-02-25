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
        public event Action<string> onSkillLearnClick;
        public event Action<string> onSkillForgetClick;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _skillCostText;

        [SerializeField] private Button _learnSkillBtn;
        [SerializeField] private Button _forgetSkillBtn;
        [SerializeField] private Button _foregetAllBtn;

        [SerializeField] private Button _earnPointBtn;

        [SerializeField] private SkillItemView[] _skillItemView;

        private SkillItemViewData _selectedData;
        private SkillItemView _selectedSkill;

        public void Init(List<SkillItemViewData> viewData)
        {
            _earnPointBtn.onClick.AddListener(OnEarnPointClick);
            _learnSkillBtn.onClick.AddListener(OnLearnSkillClick);
            _forgetSkillBtn.onClick.AddListener(OnSkillForgetClick);

            foreach (var data in viewData)
            {
                var view = _skillItemView[data.index];

                view.onSelect += OnSkillSelect;
                view.Init(data);
                view.Unselect();

                if (data.activated)
                {
                    view.Activate();
                }
            }

            _selectedSkill = _skillItemView[0];
            _selectedSkill.Select();
        }

        public void UpdateScoreText(string scoreText)
        {
            _scoreText.text = scoreText;
        }

        public void UpdateSkillCostText(string skillCost)
        {
            _skillCostText.text = skillCost;
        }

        public void OnSkillLearn(string id)
        {

            _selectedSkill.Activate();
        }

        public void OnSkillForget(string id)
        {
            _selectedSkill.Forget();
        }

        private void OnEarnPointClick()
        {
            onEarnPointClick?.Invoke();
        }

        private void OnLearnSkillClick()
        {
            onSkillLearnClick?.Invoke(_selectedData.skillId);
        }

        private void OnSkillForgetClick()
        {
            onSkillForgetClick?.Invoke(_selectedData.skillId);
        }

        private void OnSkillSelect(SkillItemView view, SkillItemViewData data)
        {
            _selectedSkill.Unselect();
            _selectedSkill = view;
            _selectedSkill.Select();
            _selectedData = data;
        }
    }
}