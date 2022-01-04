using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Acts/Parry")]
    public class Parry : Action
    {
        public override void OnPlay()
        {
            
        }

        public override void Process()
        {
            // Jos vastus hyökkää, väistää vahingon ja tekee +2 vahinkoa.
        }
    }
}