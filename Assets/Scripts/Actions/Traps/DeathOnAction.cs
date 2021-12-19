using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/DeathOnAction")]
    public class DeathOnAction : Action
    {
         public override bool Complete()
        {
            return true;
        }
    }
}
