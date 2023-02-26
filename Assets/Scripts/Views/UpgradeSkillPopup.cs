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
        public event Action onForgetAllClick;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _skillCostText;

        [SerializeField] private Button _learnSkillBtn;
        [SerializeField] private Button _forgetSkillBtn;
        [SerializeField] private Button _foregetAllBtn;

        [SerializeField] private Button _earnPointBtn;

        [SerializeField] private SkillItemView[] _skillItemView;

        Dictionary<string, SkillItemView> _idsToView = new Dictionary<string, SkillItemView>();
        private SkillItemViewData _selectedData;
        private SkillItemView _selectedSkill;

        public void Init(List<SkillItemViewData> viewData)
        {
            _earnPointBtn.onClick.AddListener(OnEarnPointClick);
            _learnSkillBtn.onClick.AddListener(OnLearnSkillClick);
            _forgetSkillBtn.onClick.AddListener(OnSkillForgetClick);
            _foregetAllBtn.onClick.AddListener(OnForgetAllClick);

            foreach (var view in _skillItemView)
            {
                view.onSelect += OnSkillSelect;
            }

            ProcessData(viewData);

            _selectedSkill = _skillItemView[0];
            _selectedSkill.Select();
        }

        private void ProcessData(List<SkillItemViewData> viewData)
        {
            foreach (var data in viewData)
            {
                var view = _skillItemView[data.index];
                _idsToView.Add(data.skillId, view);


                view.UpdateData(data);
                view.Unselect();

                if (data.activated)
                {
                    view.Activate();
                }
            }
        }

        public void UpdateScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }

        public void UpdateSkillCostText(int skillCost)
        {
            _skillCostText.text = skillCost.ToString();
        }

        public void OnSkillLearn(string id)
        {
            _idsToView[id].Activate();
        }

        public void OnSkillForget(string id)
        {
            _idsToView[id].Forget();
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

        private void OnForgetAllClick()
        {
            onForgetAllClick?.Invoke();
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