using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/GameRules")]
    public class GameRules : ScriptableObject
    {
        public List<Team> Teams = new List<Team>();
        public List<CharacterSO> Characters = new List<CharacterSO>();
        public List<SpellCard> Spells = new List<SpellCard>();
        public List<TrapCard> Traps = new List<TrapCard>();
        public List<Item> Items = new List<Item>();

        public Card[] AllCards
        {
            get
            {
                var list = new List<Card>();
                foreach (var item in Spells)
                {
                    list.Add(item);
                }
                foreach (var item in Items)
                {
                    list.Add(item);
                }
                foreach (var item in Traps)
                {
                    list.Add(item);
                }
                return list.ToArray();
            }
        }

        public Card RandomCard => Random.Range(0, 2) switch
        {
            1 => Spells.Random(),
            2 => Items.Random(),
            _ => Traps.Random()
        };

        [Header("Deck")]
        public GameObject DeckCardPrefab;
        public bool DisplayCardType = true;
        public StartingDeckLoadout StartDeckLoadout;
        public enum StartingDeckLoadout
        {
            None,
            Full,
            Random,
        }
        public int MaxHandCardCount = 3;

        [Header("Turns")]
        public int TurnDuration = 12;
        public int CardActionCost = 1;
        public int CharacterActionCost = 1;

        [Header("Networking")]
        public int MaxRoomSize = 20;

        [Header("Pile")]
        public GameObject PileCardPrefab;
        [Min(0)] public int StartingPileSize = 50;

        [Header("Rarity")]
        public float SpellCardRarity = 20f;
        public float TrapCardRarity = 15f;

        // an additional effect on card like stamina despite being a weapon
        public float CardExtraBonusRarity = 5f;
        
        [Header("HUD")]
        public Icon StaminaIcon;
    }
}