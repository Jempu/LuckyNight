using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ikatyros.LuckyNight
{
    public class DeckCard : MonoBehaviour, IPointerClickHandler
    {
        private Deck _deck;
        private Outline _outline;

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
            _outline.enabled = true;
        }

        public void Deselect()
        {
            _outline.enabled = false;
        }
    }
}