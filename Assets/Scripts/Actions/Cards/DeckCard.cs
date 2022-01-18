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
        private Outline _outline;

        public bool isSelected;

        private void Start()
        {
            _deck = GetComponentInParent<Deck>();
            _outline = GetComponentInChildren<Outline>();
            
            Deselect();
        }

        public void OnPointerClick(PointerEventData data)
        {
            _deck.SelectCard(this);
        }

        public void Select()
        {
            if (isSelected)
            {
                // process placing the card as it has been double clicked
                return;
            }
            isSelected = true;
            _outline.enabled = true;
        }

        public void Deselect()
        {
            isSelected = true;
            _outline.enabled = false;
        }
    }
}