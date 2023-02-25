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
        [SerializeField] private Image _skillBack;
        [SerializeField] private TMP_Text _skillName;
        private string _id;

        public void Init(ViewData data)
        {
            _skillName.text = data.skillName;
            _id = data.skillId;
        }

        public void Select()
        {
            _skillBack.color = Color.yellow;
        }

        public void Unselect()
        {
            _skillBack.color = Color.cyan;
        }

        public void Activate()
        {
            _skillBack.color = Color.green;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Select();
            onSelect?.Invoke(this, _id);
        }
    }
}

