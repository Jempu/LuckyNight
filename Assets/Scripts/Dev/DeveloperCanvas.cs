using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ikatyros.LuckyNight
{
    public class DeveloperCanvas : MonoBehaviour
    {
        private TMP_Text _version;

        private void Start()
        {
            _version = transform.Find("game-version").GetComponent<TMP_Text>();
            _version.text = Application.version;
        }
    }
}