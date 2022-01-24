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

        [HideInInspector] public Team AssignedTeam;
        public int AssignedSeat;

        public int currentStamina;
        public int maximumStamina = 2;

        private TurnManager TurnManager => GameManager.TurnManager;

        public PlayerHUD hud;

        private void Start()
        {
            if (hud != null) hud.Ready(this);
        }

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

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                CancelActions();
            }

            if (Extensions.IsNumKey())
            {
                SelectInHand(Extensions.GetNumKey());
            }
        }

        private void SelectInHand(int index)
        {
            hud?.SelectInHand(index);
            // AddAction(GameManager.Rules.Spells[0]);
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
            var cost = 0;
            foreach (var action in actions)
            {
                cost += action.StaminaCost;
                if (cost >= characters[TurnManager.currentTurn].stamina)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void KillPlayer()
        {
            // once all of players characters are dead
        }

        public void KillCharacter()
        {
            // remove and hide character from board
        }

        public bool AddAction(Action action)
        {
            if (currentStamina - action.StaminaCost < 0) return false;
            currentStamina =- action.StaminaCost;
            actions.Add(action);
            TurnManager.PlayersAndTheirActions[this].Add(action);
            return true;
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
        
        public void ResetStamina()
        {
            currentStamina = maximumStamina;
        }
    }
}