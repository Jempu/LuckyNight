using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/GameRules")]
    public class GameRules : ScriptableObject
    {
        // Turns
        public Teams TurnStartingTeam = Teams.Agent;

        public int TurnDuration = 12;

        public int CardActionCost = 1;
        public int CharacterActionCost = 1;

        public List<CharacterSO> Characters = new List<CharacterSO>();
        public List<SpellCard> Spells = new List<SpellCard>();
        public List<TrapCard> Traps = new List<TrapCard>();
        public List<Item> Items = new List<Item>();

        // Networking
        public int MaxRoomSize = 20;

        // Rarity
        public float SpellCardRarity = 20f;
        public float TrapCardRarity = 15f;

        // an additional effect on card like stamina despite being a weapon
        public float CardExtraBonusRarity = 5f;
    }
}