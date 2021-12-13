using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class SettingCanvas : MonoBehaviour
    {
        public static SettingCanvas Instance { get; private set; }

        private Canvas _canvas;
        private Button _roleSwap;
        private Transform _playerList;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            _canvas = GetComponent<Canvas>();
            _roleSwap = _canvas.transform.Find("role-swap").GetComponent<Button>();
            _roleSwap.onClick.AddListener(delegate { OpenPlayerList(); });
            _playerList = transform.Find("player-list");
            _playerList.gameObject.SetActive(false);
            _canvas.enabled = false;
        }

        public void AddToPlayerList()
        {

        }

        public void RemoveFromPlayerList()
        {

        }

        private void SetPlayerRole(string value)
        {
            
        }

        private void OpenPlayerList()
        {
            _playerList.gameObject.SetActive(true);
        }

        private void ClosePlayerList()
        {
            
            // distribute changed player role data to everyone affected...

            _playerList.gameObject.SetActive(false);
        }
    }
}