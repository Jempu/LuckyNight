using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public class CardGenerator
    {
        public float ArmorBoost = 1.3f;
        public float MotivationBoost = 0.8f;
        public float WeaponBoost = 1.5f;

        public GameRules gameRules;

        public void Generate()
        {
            foreach (var item in gameRules.Items)
            {
                switch (item.type)
                {
                    case Item.Type.Armor:
                        var health = Mathf.Round(Random.Range(1f, 3f) * ArmorBoost);
                        break;
                    case Item.Type.Motivation:
                        var stamina = Mathf.Round(Random.Range(1f, 2f) * MotivationBoost);
                        break;
                    case Item.Type.Weapon:
                        var damage = Mathf.Round(Random.Range(1f, 3f) * WeaponBoost);
                        break;
                }
            }
        }
    }
}