using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class Player : MonoBehaviour
    {
        public List<Action> actions = new List<Action>();
        public List<Character> characters = new List<Character>();
        public List<Card> cards = new List<Card>();
        public List<StatusEffect> ActiveStatusEffects = new List<StatusEffect>();

        public Team AssignedTeam;

        public int currentStamina;
        public int maximumStamina = 2;

        private TurnManager TurnManager => GameManager.Instance.TurnManager;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject.Find("Sample Maestro").GetComponentInChildren<Character>().ChangeHealth(-3);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Sample Maestro").GetComponentInChildren<Character>().ChangeHealth(+2);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                actions.Add(GameManager.Rules.Spells[0]);
            }
        }

        public bool IsAlive()
        {
            foreach (var character in characters)
            {
                if (character.IsAlive())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsTurnReady()
        {
            return true;
        }
        
        public void KillPlayer()
        {
            // once all of players characters are dead
        }

        public void KillCharacter()
        {
            // remove and hide character from board
        }

        public void CancelActions()
        {
            TurnManager.CancelPlayerActions(this);
        }

        // Defend & Heal limited to every 3 turns.

        public void PickCard()
        {
            GameManager.Instance.Pile.PickCard();
        }
    }
}