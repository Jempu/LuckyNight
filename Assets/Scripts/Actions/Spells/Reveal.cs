using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Reveal")]
    public class Reveal : Action
    {
         public override bool Complete()
        {
            return true;
        }
    }
}
