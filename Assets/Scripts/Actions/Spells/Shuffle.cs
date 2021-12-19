using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Shuffle")]
    public class Shuffle : Action
    {
        public override bool Complete()
        {
            return true;
        }
    }
}
