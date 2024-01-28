using System;
using Signals;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = "Score " + CoreGameSignals.Instance.OnGetScore().ToString();
        }
    }
}
