using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class Card : Action
    {
        public int id;
        public Sprite icon;
        public int power;
        public int duration;
        public string ShortName;
    }
}