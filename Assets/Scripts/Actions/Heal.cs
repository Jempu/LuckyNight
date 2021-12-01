using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Heal")]
    public class Heal : Action
    {
        public override bool Complete()
        {
            // heal yourself
            return true;
        }
    }
}