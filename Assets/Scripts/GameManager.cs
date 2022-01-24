using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameRules _rules;
        public static GameRules Rules => Instance._rules;

        public static TurnManager TurnManager { get; private set; }
        public Pile Pile { get; private set; }

        public List<Player> Players = new List<Player>();
        internal Dictionary<Team, int> TeamIndexes = new Dictionary<Team, int>();
        internal Dictionary<Team, int> TeamPlayerCounts = new Dictionary<Team, int>();
        internal Dictionary<Player, int> IndexOfPlayerInTeam = new Dictionary<Player, int>();

        private Canvas _warningCanvas;
        private Canvas _victoryCanvas;

        private void Awake()
        {
            if (GameManager.Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            TurnManager = GetComponent<TurnManager>();
            Pile = FindObjectOfType<Pile>();

            _warningCanvas = GameObject.Find("Warning UI").GetComponent<Canvas>();
            _victoryCanvas = GameObject.Find("Victory UI").GetComponent<Canvas>();

            GetAllPlayersInScene();

            SetIndexOfPlayersInTeams();
            SetTeamOrderByRules();
        }

        private void GetAllPlayersInScene()
        {
            foreach (var player in FindObjectsOfType<Player>())
            {
                Players.Add(player);
                if (!TeamPlayerCounts.ContainsKey(player.AssignedTeam))
                {
                    TeamPlayerCounts.Add(player.AssignedTeam, 0);
                }
                TeamPlayerCounts[player.AssignedTeam] += 1;
            }
            foreach (var team in TeamPlayerCounts)
            {
                Debug.Log(team.Value);
            }
            // if players are found in scene, adjust that in GameManager
            // don't spawn the players already in scene
            SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            foreach (var player in Players)
            {
                if (player.AssignedTeam == null) continue;
                var team = player.AssignedTeam;
                var playerCount = TeamPlayerCounts[team];
                if (team.PlayerPrefab != null)
                {
                    var parent = new GameObject($"TMP_{team.TeamName}SpawnerParent").transform;
                    for (var i = 0; i < playerCount; i++)
                    {
                        var prefab = Instantiate(team.PlayerPrefab, parent.position, parent.rotation, parent).transform;
                        prefab.name = $"{team.TeamName} {i + 1}";
                        prefab.Translate(0, 0, -8);
                        prefab.SetParent(null);
                        parent.Rotate(0, 360 / (float)playerCount, 0);
                    }
                    Destroy(parent.gameObject);
                }
                player.ResetStamina();
            }
            TurnManager.SetTeamSeats();
        }

        private void SetIndexOfPlayersInTeams()
        {
            foreach (var player in Players)
            {
                IndexOfPlayerInTeam.Add(player, Rules.Teams.IndexOf(player.AssignedTeam));
            }
        }

        private void SetTeamOrderByRules()
        {
            foreach (var team in Rules.Teams)
            {
                if (!TeamIndexes.ContainsKey(team))
                {
                    TeamIndexes.Add(team, TeamIndexes.Count);
                }
            }
        }

        public void NextTurn()
        {
            // find the player with that character id
            StartCoroutine(WarnPlayerAboutThreat());
        }

        private IEnumerator WarnPlayerAboutThreat()
        {
            _warningCanvas.enabled = true;
            yield return new WaitForSecondsRealtime(1.5f);
            _warningCanvas.enabled = false;
        }

        private void GameOver()
        {
            _victoryCanvas.enabled = true;
        }
    }
}