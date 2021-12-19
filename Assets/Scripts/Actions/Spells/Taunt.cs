using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Taunt")]
    public class Taunt : Action
    {
        public override bool Complete()
        {
            return true;
        }
    }
}
