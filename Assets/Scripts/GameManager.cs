using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public List<Player> agents = new List<Player>();
        public List<Player> maestros = new List<Player>();

        public CardManager CardManager { get; private set; }
        public Pile Pile { get; private set; }

        public GameObject AgentPrefab;

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
            CardManager = GetComponent<CardManager>();
            Pile = FindObjectOfType<Pile>();

            _warningCanvas = GameObject.Find("Warning UI").GetComponent<Canvas>();
            _victoryCanvas = GameObject.Find("Victory UI").GetComponent<Canvas>();

            StartCoroutine(SpawnPlayersAround());
        }

        private IEnumerator SpawnPlayersAround()
        {
            var parent = new GameObject("AgentSpawnerParent").transform;
            for (var i = 0; i < agents.Count; i++)
            {
                var player = Instantiate(AgentPrefab, parent.position, parent.rotation, parent).transform;
                player.name = $"Agent {i + 1}";
                player.Translate(0, 0, -8);
                player.SetParent(null);
                parent.Rotate(0, 360 / (float)agents.Count, 0);
            }
            Destroy(parent.gameObject);
            yield return null;
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

        public void PlaceHolder() { }
    }
}