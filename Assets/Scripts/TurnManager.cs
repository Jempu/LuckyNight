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

        private void Start()
        {
            _timerTxt = GameObject.Find("UI/stats/timer").GetComponent<TMP_Text>();
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            remainingTime = maxTurnTime;
            while (remainingTime > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                remainingTime--;
                _timerTxt.text = remainingTime.ToString();
            }
            EndTurn();
        }

        public void EndTurn()
        {
            ProcessActions();
        }

        private IEnumerator ProcessActions()
        {
            foreach (var action in actions)
            {
                yield return new WaitUntil(() => action.Complete());
            }

            // then wait for server's "ok" response
            StartCoroutine(StartTimer());
        }
    }
}