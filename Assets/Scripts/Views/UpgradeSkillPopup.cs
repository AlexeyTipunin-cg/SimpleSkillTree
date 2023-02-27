using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class UpgradeSkillPopup : MonoBehaviour, ISkillPopup<SkillItemViewData>
    {
        public event Action onEarnPointClick;
        public event Action<string> onSkillLearnClick;
        public event Action<string> onSkillForgetClick;
        public event Action onForgetAllClick;

        [SerializeField] private TMP_Text _skillPointsText;
        [SerializeField] private TMP_Text _skillCostText;

        [SerializeField] private Button _learnSkillBtn;
        [SerializeField] private Button _forgetSkillBtn;
        [SerializeField] private Button _foregetAllBtn;

        [SerializeField] private Button _earnPointBtn;

        [SerializeField] private SkillItemView[] _skillItemView;

        private Dictionary<string, SkillItemView> _idsToView = new Dictionary<string, SkillItemView>();
        private SkillItemViewData _selectedData;

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

            OnSkillSelect(viewData[0]);
        }

        private void ProcessData(List<SkillItemViewData> viewData)
        {
            foreach (var data in viewData)
            {
                var view = _skillItemView[data.index];

                _idsToView.Add(data.skillId, view);

                UpdateView(data);
            }
        }

        private void UpdateView(SkillItemViewData data)
        {
            var view = _idsToView[data.skillId];

            view.UpdateData(data);

            if (data.activated)
            {
                view.Activate();
            }
            else
            {
                view.Forget();
            }
        }

        public void UpdateScoreText(int score)
        {
            _skillPointsText.text = score.ToString();
        }

        public void OnSkillLearn(SkillItemViewData data)
        {
            UpdateView(data);
        }

        public void OnSkillForget(SkillItemViewData data)
        {
            UpdateView(data);
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

        private void OnSkillSelect(SkillItemViewData data)
        {
            if (_selectedData != null)
            {
                _idsToView[_selectedData.skillId].Unselect();
            }

            _selectedData = data;

            _idsToView[_selectedData.skillId].Select();
            _skillCostText.text = data.cost.ToString();
        }
    }
}