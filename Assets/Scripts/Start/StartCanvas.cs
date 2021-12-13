using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class StartCanvas : MonoBehaviour
    {
        private TMP_InputField _input;
        private Button _join;
        private Transform _overlay;
        private Canvas _settingCanvas;
        
        public string SpectatorPassword = "$q";
        public string AdminPassword = "$aike";

        private void Start()
        {
            _input = GetComponentInChildren<TMP_InputField>();
            _input.onValueChanged.AddListener(delegate { CheckInput(); });
            _join = GetComponentInChildren<Button>();
            _join.onClick.AddListener(delegate { Join(); });
            _overlay = transform.Find("overlay");
            _settingCanvas = FindObjectOfType<SettingCanvas>().GetComponent<Canvas>();
            _overlay.gameObject.SetActive(false);
        }

        private void CheckInput()
        {
            Char[] special = { '&', '£', '$', '€' };
            _input.contentType = special.Any(c => _input.text.Contains(c))
                ? TMP_InputField.ContentType.Password
                : TMP_InputField.ContentType.Standard;
        }

        private void Join()
        {
            if (_overlay.gameObject.activeSelf) return;
            NetworkManager.Instance.StartCanvas = this;
            if (_input.text == AdminPassword)
            {
                NetworkManager.Instance.JoinAsMaestro();
                _settingCanvas.enabled = true;
            }
            else if (_input.text == SpectatorPassword)
            {
                NetworkManager.Instance.JoinAsSpectator();
            }
            else
            {
                NetworkManager.Instance.JoinAsAgent(_input.text);
            }
            _input.DeactivateInputField();
            _overlay.gameObject.SetActive(true);
        }

        public void ReturnToInput()
        {
            _overlay.gameObject.SetActive(false);
        }
    }
}