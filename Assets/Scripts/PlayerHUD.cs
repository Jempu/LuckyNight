using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class PlayerHUD : MonoBehaviour
    {
        private Deck _deck;

        private void Start()
        {
            _deck = transform.GetComponentInChildren<Deck>();
        }

        public void SelectInHand(int index) => _deck.SelectCard(index);
    }
}