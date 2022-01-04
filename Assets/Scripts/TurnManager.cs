using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class TurnManager : MonoBehaviour
    {
        public int maxTurnTime = 12;
        public int remainingTime;

        public int currentTurn;
        public int maestroTierUpTurnCount = 10;

        private TMP_Text _timerTxt;

        public List<Action> actions = new List<Action>();

        // both need to be ready for turn to end
        // check data from cloud server
        public bool player1Ready;
        public bool player2Ready;

        private void Start()
        {
            _timerTxt = GameObject.Find("UI/stats/timer").GetComponent<TMP_Text>();
            StartCoroutine(StartTimer());
        }

        private bool GetTurnCompletion()
        {
            return player1Ready && player2Ready;
        }

        private IEnumerator StartTimer()
        {
            Debug.Log("Starting the next turn...");

            remainingTime = maxTurnTime;
            while (remainingTime > 0 && !GetTurnCompletion())
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

            player1Ready = false;
            player2Ready = false;
            foreach (var action in actions)
            {
                action.Process();
            }

            // then wait for server's "ok" response
            StartCoroutine(StartTimer());

            yield return null;
        }
    }
}