using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class Action : ScriptableObject
    {
        [SerializeField] private int _tokenCost = 1;
        public int TokenCost => _tokenCost;

        public abstract bool Complete();
    }
}