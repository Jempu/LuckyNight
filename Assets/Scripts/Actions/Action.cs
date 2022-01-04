using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class Action : ScriptableObject
    {
        [SerializeField] private int _staminaCost = 1;
        public int StaminaCost => _staminaCost;

        public abstract void OnPlay();
        public abstract void Process();
    }
}