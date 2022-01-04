using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Acts/Heal")]
    public class Heal : Action
    {
        public override void OnPlay()
        {
            
        }

        public override void Process()
        {
            // heal yourself / everyone on your team
            // in future there will be AoE and self-heal
        }
    }
}