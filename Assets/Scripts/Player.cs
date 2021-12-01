using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class Player : MonoBehaviour
    {
        public List<Character> characters = new List<Character>();

        private void Start()
        {

        }
        
        public void KillPlayer()
        {
            // once all of players characters are dead
        }

        public void KillCharacter()
        {
            // remove and hide character from board
        }

        // all of player's available actions

        public void Attack()
        {

        }

        public void Defend()
        {

        }

        public void Heal()
        {
            
        }

        // Defend & Heal limited to every 3 turns.

        public void PickCard()
        {
            GameManager.Instance.Pile.PickCard();
        }

        public void PlaceCardCharacter()
        {

        }

        public void PlaceCardPile()
        {

        }

        public void SwapCharacter()
        {

        }
    }
}