using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scripts.Views
{
    public class SkillItemView : MonoBehaviour, IPointerDownHandler
    {
        public event Action<SkillItemView, string> onSelect;
        [SerializeField] private Image _itemBack;
        [SerializeField] private Image _selectionOutline;
        [SerializeField] private TMP_Text _skillName;
        private string _id;

        public void Init(ViewData data)
        {
            _skillName.text = data.skillName;
            _id = data.skillId;
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
            _itemBack.color = Color.cyan;
        }

        public void Activate()
        {
            _itemBack.color = Color.green;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Select();
            onSelect?.Invoke(this, _id);
        }
    }
}

