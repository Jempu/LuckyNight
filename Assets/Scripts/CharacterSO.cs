using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Character")]
    public class CharacterSO : ScriptableObject
    {
        public Sprite Portrait;
        public string Name = "Mimi";
        public int Health = 5;
        public int MaxHealth = 5;
        public int Damage = 1;
        public int Stamina = 2;
    }
}