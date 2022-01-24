using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class TurnManager : MonoBehaviour
    {
        public int currentTurn;
        public int remainingTime;

        private bool _updateTimer;
        private int _maxTurnTime;

        private TMP_Text _timerTxt;

        private List<Player> _players => GameManager.Instance.Players;
        public List<Player> playersInTurn = new List<Player>();

        public Dictionary<Player, List<Action>> PlayersAndTheirActions = new Dictionary<Player, List<Action>>();

        public List<Action> actions = new List<Action>();

        internal bool CanPlay { get; private set; }

        private void Start()
        {
            _timerTxt = FindObjectOfType<PlayerHUD>().transform.Find("stats/timer").GetComponent<TMP_Text>();
            StartTimer();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                foreach (var player in PlayersAndTheirActions)
                {
                    foreach (var action in player.Value)
                    {
                        Debug.Log($"{player.Key.name}: {action.name}");
                    }
                }
            }
        }

        internal void SetTeamSeats()
        {
            // first set seats
            for (var i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                player.AssignedSeat = i;
                // var player2 = players[i + 1];
                // if (player.AssignedTeam[GameManager.Instance.TeamPlayerCounts] < player.)
                // {
                //     Mathf.Round();
                // }
            }
            // second set playersInTurn
            foreach (var player in _players)
            {
                PlayersAndTheirActions.Add(player, new List<Action>());
                playersInTurn.Add(player);
            }
        }

        private bool IsEveryPlayerTurnReady()
        {
            if (playersInTurn.Count == 0) return false;
            foreach (var player in playersInTurn)
            {
                if (!player.IsTurnReady())
                {
                    return false;
                }
            }
            return true;
        }

        private void StartTimer()
        {
            _updateTimer = GameManager.Rules.TurnDuration > 0;
            _maxTurnTime = _updateTimer ? GameManager.Rules.TurnDuration : 300000;
            if (_updateTimer)
            {
                StartCoroutine(StartTimerCoroutine());
                return;
            }
            _timerTxt.text = "∞";
        }

        private IEnumerator StartTimerCoroutine()
        {
            CanPlay = true;
            Debug.Log("TurnManager: Starting the next turn...");
            foreach (var player in _players)
            {
                if (!player.AssignedTeam.UseStaticSeat)
                {
                    player.AssignedSeat += 1;
                }
            }
            remainingTime = _maxTurnTime;
            while (remainingTime > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (IsEveryPlayerTurnReady()) break;
                remainingTime--;
                _timerTxt.text = remainingTime.ToString();
            }
            EndTurn();
        }

        public void EndTurn() => StartCoroutine(ProcessActions());

        private IEnumerator ProcessActions()
        {
            CanPlay = false;
            Debug.Log("TurnManager: Ending turn and processing all of the turn's actions...");

            var tempOrderedPlayerList = new List<Player>();

            /*
                example of the order of processing:
                2 agents
                1 maestro

                A1
                A2
                M1
                A1
                A2
                M2
                ...

                1 agents
                2 maestros
                A1
                M1
                M2
                A1
                M1
                M2
                ...

                READY: TEAM: ACTIONS
                M1 | 1 | parry
                A1 | 0 | attack, heal
                M2 | 1 | heal, taunt, spell
            */

            foreach (var player in playersInTurn)
            {
                foreach (var action in player.actions)
                {
                    Debug.Log($"TurnManager: Processing an action: {action.name}...");
                    action.Process();
                    yield return new WaitForSecondsRealtime(1f);
                }
                player.actions.Clear();
                player.ResetStamina();
            }
            Debug.Log($"TurnManager: Done processing...");
            // then wait for server's "ok" response
            yield return new WaitForSecondsRealtime(2f);
            StartCoroutine(StartTimerCoroutine());
        }

        public void AddPlayerAction(Player player, Action action)
        {
            if (player.AddAction(action))
            {
                PlayersAndTheirActions[player].Add(action);
            }
        }

        public void RemovePlayerAction(Player player, Action action)
        {
            PlayersAndTheirActions[player].Remove(action);
            player.actions.Remove(action);
        }

        public void CancelPlayerActions(Player player)
        {
            // remove selected actions from the turn holding player
            PlayersAndTheirActions[player].Clear();
            player.actions.Clear();
        }
    }
}