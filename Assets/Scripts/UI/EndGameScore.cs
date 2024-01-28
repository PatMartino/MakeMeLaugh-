using Signals;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGameScore : MonoBehaviour
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
            _text.text = "Your Score is " + CoreGameSignals.Instance.OnGetScore().ToString();
        }
    }
}
