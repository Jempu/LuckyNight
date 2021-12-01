using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Counter")]
    public class Counter : Action
    {
        public override bool Complete()
        {
            // Jos vastus hyökkää, väistää vahingon ja tekee +2 vahinkoa.
            return true;
        }
    }
}