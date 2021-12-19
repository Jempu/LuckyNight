using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucid/Actions/Seal")]
    public class Seal : Action
    {

        public override bool Complete()
        {
            // replace the character to gallery and get a new random character
            return true;
        }

    }
}
