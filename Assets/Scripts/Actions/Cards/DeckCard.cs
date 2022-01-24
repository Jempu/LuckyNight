using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ikatyros.LuckyNight
{
    public class DeckCard : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Card _base;
        public Card Base => _base;

        private Deck _deck;
        private Image _outline;

        public bool isSelected;

        internal void Ready(Deck parent, Card _base)
        {
            this._base = _base;
            _deck = parent;
            _outline = transform.Find("outline").GetComponent<Image>();
            Deselect();
        }

        public void OnPointerClick(PointerEventData data)
        {
            _deck.SelectCard(this);
        }

        public void Click()
        {
            if (isSelected)
            {
                Play();
                return;
            }
            Select();
        }

        private void Select()
        {
            Debug.Log($"Selected card {_base.name}");
            isSelected = true;
            if (_outline != null) _outline.enabled = true;
        }

        private void Play()
        {
            Debug.Log($"Played card {_base.name}");
            _deck.PlayCard(this);
        }

        public void Deselect()
        {
            isSelected = false;
            if (_outline != null) _outline.enabled = false;
        }
    }
}