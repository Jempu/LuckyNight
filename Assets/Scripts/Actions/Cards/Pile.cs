using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class Pile : MonoBehaviour
    {
        [SerializeField] private List<Card> _availableCards = new List<Card>();
        public GameObject _cardPrefab;
        public int _pileSize;

        private void Start()
        {
            _pileSize = GameManager.Rules.StartingPileSize;
            _cardPrefab = GameManager.Rules.PileCardPrefab;
        }

        public void CreatePile()
        {
            for (var i = 0; i < _pileSize; i++)
            {
                var pos = new Vector3(Random.Range(-0.025f, 0.025f), 0, Random.Range(-0.025f, 0.025f));
                var rot = Quaternion.Euler(0, Random.Range(-25f, 25f), 0);
                var card = Instantiate(_cardPrefab, pos, rot, transform);
            }
        }

        public Card PickCard()
        {
            if (_availableCards.Count == 0) return null;
            return _availableCards[Random.Range(0, _availableCards.Count)];
        }
    }
}