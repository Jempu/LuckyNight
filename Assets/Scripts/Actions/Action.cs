using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class Action : ScriptableObject
    {
        [SerializeField] private int _staminaCost = 1;
        public int StaminaCost => _staminaCost;

        protected Player _target;
        public bool autoTarget = true;
        public StatusEffect[] statusEffects;

        public abstract void OnPlay();
        public abstract void Process();
    }
}