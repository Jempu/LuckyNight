using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class StatusEffect : ScriptableObject
    {
        private List<Character> _targets = new List<Character>();
        
        public int duration = 1;

        public void AddTarget(params Character[] targets)
        {
            foreach (var target in _targets)
            {
                _targets.Add(target);
            }
        }

        public void Process()
        {
            foreach (var target in _targets)
            {
                ProcessEffect(target);
            }
        }

        protected abstract void ProcessEffect(Character target);
    }
}