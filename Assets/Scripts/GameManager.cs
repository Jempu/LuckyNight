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

        public TurnManager TurnManager { get; private set; }
        public CardManager CardManager { get; private set; }
        public Pile Pile { get; private set; }

        public List<Player> players = new List<Player>();
        private Dictionary<Team, int> _teamPlayerCounts = new Dictionary<Team, int>();

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
            CardManager = GetComponent<CardManager>();
            Pile = FindObjectOfType<Pile>();

            _warningCanvas = GameObject.Find("Warning UI").GetComponent<Canvas>();
            _victoryCanvas = GameObject.Find("Victory UI").GetComponent<Canvas>();

            GetAllPlayersInScene();
        }

        private void GetAllPlayersInScene()
        {
            foreach (var player in FindObjectsOfType<Player>())
            {
                players.Add(player);
            }
            // if players are found in scene, adjust that in GameManager
            // don't spawn the players already in scene
            // SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            foreach (var player in players)
            {
                if (player.AssignedTeam == null) continue;
                var team = player.AssignedTeam;
                var playerCount = _teamPlayerCounts[team];
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
            }
        }

        public void NextTurn()
        {
            // find the player with that character id
            StartCoroutine(WarnAgent());
        }

        private IEnumerator WarnAgent()
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