using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class Deck : MonoBehaviour
    {
        [SerializeField] private List<DeckCard> _cards = new List<DeckCard>();
        
        private void Start()
        {
            foreach (var card in transform.GetComponentsInChildren<DeckCard>())
            {
                _cards.Add(card);
            }
        }

        public void SelectCard(int index) => SelectCard(_cards[index]);

        public void SelectCard(DeckCard selectCard)
        {
            foreach (var card in _cards)
            {
                if (card == selectCard)
                {
                    card.Select();
                }
                else
                {
                    card.Deselect();
                }
            }
        }
    }
}