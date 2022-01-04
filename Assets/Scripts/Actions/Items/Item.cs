using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Item")]
    public class Item : Card
    {
        public enum Type
        {
            Armor,
            Motivation,
            Weapon,
        }
        public Type type;

        public override void OnPlay()
        {
            // add stats to character
        }
        
        public override void Process()
        {
            
        }
    }
}