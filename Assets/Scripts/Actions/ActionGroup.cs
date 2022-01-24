using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ikatyros.LuckyNight
{
    public abstract class ActionGroup : MonoBehaviour
    {
        public GameObject Token;
        public int TokenCost = 1;
        
        private Transform _tokenHolder;

        protected void SetStamina()
        {
            if (_tokenHolder == null)
            {
                _tokenHolder = transform.Find("tokens");
            }
            foreach (Transform obj in _tokenHolder)
            {
                Destroy(obj.gameObject);
            }
            for (int i = 0; i < TokenCost; i++)
            {
                var token = Instantiate(Token, _tokenHolder).transform;
                token.name = $"token {i}";
                token.GetComponent<RectTransform>().localPosition = new Vector2(80 * i, 0);
            }
        }
    }
}