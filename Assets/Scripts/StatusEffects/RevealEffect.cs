using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/StatusEffects/Reveal")]
    public class RevealEffect : StatusEffect
    {
        protected override void ProcessEffect(Character target)
        {
            // target.KillPlayer();
        }
    }
}