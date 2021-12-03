using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class Pile : MonoBehaviour
    {
        public List<Card> availableCards = new List<Card>();

        public Card PickCard()
        {
            if (availableCards.Count == 0) return null;
            return availableCards[Random.Range(0, availableCards.Count)];
        }
    }
}