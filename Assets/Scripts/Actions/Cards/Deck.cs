using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class Deck : MonoBehaviour
    {
        private PlayerHUD _hud;
        [SerializeField] private Card[] _cards;
        [SerializeField] private List<DeckCard> _deckCards = new List<DeckCard>();

        internal void Ready(PlayerHUD hud)
        {
            _hud = hud;
            _cards = GameManager.Rules.AllCards;
            CreateDeck();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                CreateDeck();
            }
        }

        private void CreateDeck()
        {
            VoidDeck();
            switch (GameManager.Rules.StartDeckLoadout)
            {
                case GameRules.StartingDeckLoadout.Full:
                    foreach (var card in _cards)
                    {
                        CreateDeckCard(card);
                    }
                    break;
                case GameRules.StartingDeckLoadout.Random:
                    for (var i = 0; i < Random.Range(0, GameManager.Rules.MaxHandCardCount); i++)
                    {
                        CreateDeckCard(GameManager.Rules.RandomCard);
                    }
                    break;
            }
        }

        private void CreateDeckCard(Card cardSO)
        {
            var prefab = Instantiate(GameManager.Rules.DeckCardPrefab, transform).transform;
            prefab.name = cardSO.name;
            var portrait = prefab.transform.Find("portrait").GetComponent<Image>();
            if (cardSO.icon != null)
            {
                portrait.sprite = cardSO.icon;
            }
            var typeTxt = prefab.transform.Find("type-txt").GetComponent<TMP_Text>();
            if (GameManager.Rules.DisplayCardType)
            {
                typeTxt.text = cardSO.ShortName;
            }
            else
            {
                typeTxt.enabled = false;
            }
            var deckCard = prefab.GetComponent<DeckCard>();
            deckCard.Ready(this, cardSO);
            _deckCards.Add(deckCard);
        }

        private void VoidDeck()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void SelectCard(int index)
        {
            if (_deckCards.Count - 1 < index)
            {
                SelectCard(null);
                return;
            }
            SelectCard(_deckCards[index]);
        }

        public void SelectCard(DeckCard selectCard)
        {
            foreach (var card in _deckCards)
            {
                if (card == selectCard)
                {
                    card.Click();
                }
                else
                {
                    card.Deselect();
                }
            }
        }

        public void PlayCard(DeckCard card)
        {
            card.gameObject.SetActive(false);
            GameManager.TurnManager.AddPlayerAction(_hud.owner, card.Base);
        }

        public void ReturnCard(DeckCard card)
        {
            card.gameObject.SetActive(true);
            GameManager.TurnManager.RemovePlayerAction(_hud.owner, card.Base);
        }
    }
}