using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Spells/Seal")]
    public class Seal : SpellCard
    {
        public override void OnPlay()
        {
            
        }

        public override void Process()
        {
            // disable all character's actions except acting.
        }
    }
}