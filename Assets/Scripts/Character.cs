using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class Character : MonoBehaviour
    {
        public CharacterSO Stats;

        public int health;
        public int maxHealth = 5;
        public int damage;

        public int stamina;

        public bool isOwner;
        public bool isAlive = true;
        public bool isAwake;

        private Transform _canvas;

        private void Start()
        {
            health = Stats.Health;
            maxHealth = Stats.MaxHealth;
            stamina = Stats.Stamina;

            _canvas = GetComponentInChildren<Canvas>().transform;
            health = maxHealth;
            Sleep();
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public void Wake()
        {
            isAwake = true;
            SetControls(true);
        }

        public void Sleep()
        {
            isAwake = false;
            SetControls(false);
        }

        private void SetControls(bool value)
        {
            if (isOwner)
            {
                _canvas.Find("swap")?.gameObject.SetActive(value);
                return;
            }
            _canvas.Find("swap")?.gameObject.SetActive(false);
        }

        public void ChangeHealth(int amount)
        {
            health += amount;
            if (!isAlive) return;
            if (health <= 0) Die();
            
            _canvas.Find("health").GetComponent<TMP_Text>().text = health.ToString();
        }

        public void Die()
        {
            isAlive = false;
            gameObject.SetActive(false);
        }
    }
}