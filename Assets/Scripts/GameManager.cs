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
        public HealthManager HealthManager { get; private set; }
        public Pile Pile { get; private set; }

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
            HealthManager = GetComponent<HealthManager>();
            Pile = FindObjectOfType<Pile>();
        }

        private void Update()
        {
            
        }

        private void NextTurn()
        {
            
        }
    }
}