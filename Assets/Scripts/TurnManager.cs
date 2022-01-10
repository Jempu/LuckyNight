using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class TurnManager : MonoBehaviour
    {
        public int currentTurn;
        public int maxTurnTime = 12;
        public int remainingTime;

        private TMP_Text _timerTxt;

        public List<Player> playersInTurn = new List<Player>();

        public List<Action> actions = new List<Action>();

        private void Start()
        {
            _timerTxt = GameObject.Find("UI/stats/timer").GetComponent<TMP_Text>();
            StartCoroutine(StartTimer());
        }

        private bool IsEveryPlayerTurnReady()
        {
            foreach (var player in playersInTurn)
            {
                if (!player.IsTurnReady())
                {
                    return false;
                }
            }
            return true;
        }

        private IEnumerator StartTimer()
        {
            Debug.Log("Starting the next turn...");

            remainingTime = maxTurnTime;
            while (remainingTime > 0 && !IsEveryPlayerTurnReady())
            {
                yield return new WaitForSecondsRealtime(1f);
                remainingTime--;
                _timerTxt.text = remainingTime.ToString();
            }
            EndTurn();
        }

        public void EndTurn() => StartCoroutine(ProcessActions());

        private IEnumerator ProcessActions()
        {
            Debug.Log("Ending turn and processing all of the turn's actions...");
            foreach (var action in actions)
            {
                action.Process();
            }
            // then wait for server's "ok" response
            // ...
            StartCoroutine(StartTimer());
            yield return null;
        }

        public void CancelPlayerActions(Player player)
        {
            // remove selected actions from the turn holding player
        }
    }
}