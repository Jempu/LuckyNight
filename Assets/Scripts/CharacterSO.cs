using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Character")]
    public class CharacterSO : ScriptableObject
    {
        public Sprite Portrait;
        public string Name = "Mimi";
        public int Health = 5;
        public int Damage = 1;
        public int Tokens = 2;
    }
}