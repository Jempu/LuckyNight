using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/StatusEffects/Disable")]
    public class DisableEffect : StatusEffect
    {
        protected override void ProcessEffect(Character target)
        {
            // target.KillPlayer();
        }
    }
}