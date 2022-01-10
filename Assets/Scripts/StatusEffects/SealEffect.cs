using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/StatusEffects/Seal")]
    public class SealEffect : StatusEffect
    {
        protected override void ProcessEffect(Character target)
        {
            // target.KillPlayer();
        }
    }
}