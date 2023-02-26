using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scripts.Views
{
    public class SkillItemView : MonoBehaviour, IPointerDownHandler
    {
        public event Action<SkillItemViewData> onSelect;
        [SerializeField] private Image _itemBack;
        [SerializeField] private Image _selectionOutline;
        [SerializeField] private TMP_Text _skillName;
        [SerializeField] private Color _active;
        [SerializeField] private Color _inactive;

        private SkillItemViewData _data;

        public void UpdateData(SkillItemViewData data)
        {
            _data = data;
            _skillName.text = _data.skillName;
        }

        public void Select()
        {
            _selectionOutline.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            _selectionOutline.gameObject.SetActive(false);
        }

        public void Forget()
        {
            _itemBack.color = _inactive;
        }

        public void Activate()
        {
            _itemBack.color = _active;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Select();
            onSelect?.Invoke(_data);
        }
    }
}

