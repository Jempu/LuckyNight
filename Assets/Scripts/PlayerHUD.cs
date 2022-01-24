using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class PlayerHUD : MonoBehaviour
    {
        internal Player owner;
        private Deck _deck;

        internal void Ready(Player owner)
        {
            this.owner = owner;
            _deck = transform.GetComponentInChildren<Deck>();
            _deck.Ready(this);
        }

        public void SelectInHand(int index) => _deck.SelectCard(index);
    }
}