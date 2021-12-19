using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/CardSnatch")]
    public class CardSnatch : Action
    {
        public override bool Complete()
        {
            return true;
        }
    }
}
