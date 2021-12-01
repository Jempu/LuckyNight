using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class Action : ScriptableObject
    {
        public abstract bool Complete();
    }
}