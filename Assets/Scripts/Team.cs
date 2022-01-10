using UnityEngine;

namespace Ikatyros.LuckyNight
{
    [CreateAssetMenu(menuName = "Lucky/Team")]
    public class Team : ScriptableObject
    {
        public string TeamName = "Agent";
        [Range(0, 40)] public int TeamLimit;
        public GameObject PlayerPrefab;
        
        // additional benefits from playing turns
        public int TierUpTurnCount = 10;

        // when processing actions, the index is used to order teams
        // and delay adds additional delay to each action
        public int TurnActionOrderDelay;

        // allows limiting player addition to certain teams
        public bool IsTeamFull(int count)
        {
            return TeamLimit > 0 && count < TeamLimit;
        }
    }
}