using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Card")]
    public class Card : ScriptableObject
    {
        public int id;
        public enum Type
        {
            tool,
            motivation,
            weapon,
        }
        public Type type;
        public Sprite icon;
        public int power;

        public void UseCard()
        {

        }

        public void PlaceCard()
        {
            
        }
    }
}