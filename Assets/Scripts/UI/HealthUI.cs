using System;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Sprite noHealth;
        [SerializeField] private Sprite oneHealth;
        [SerializeField] private Sprite twoHealth;
        [SerializeField] private Sprite threeHealth;
        private Image _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<Image>();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnChangeHealthIcon += OnChangeHealthIcon;
        }

        private void OnChangeHealthIcon()
        {
            if (CoreGameSignals.Instance.OnGetHealth() ==0)
            {
                _spriteRenderer.sprite = noHealth;
            }
            else if (CoreGameSignals.Instance.OnGetHealth() ==1)
            {
                _spriteRenderer.sprite = oneHealth;
            }
            else if (CoreGameSignals.Instance.OnGetHealth() ==2)
            {
                _spriteRenderer.sprite = twoHealth;
            }
            else if (CoreGameSignals.Instance.OnGetHealth() ==3)
            {
                _spriteRenderer.sprite = threeHealth;
            }
        }
    }
}
