using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/StatusEffects/Taunt")]
    public class TauntEffect : StatusEffect
    {
        protected override void ProcessEffect(Character target)
        {
            // target.KillPlayer();
        }
    }
}