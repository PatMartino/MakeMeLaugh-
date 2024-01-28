using System;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LaughMeterUI : MonoBehaviour
    {
        #region Update

        private void Start()
        {
            GetComponent<Image>().fillAmount = 0.70f;
        }

        void Update()
        {
            LaughMeter();
        
        }

        #endregion
        
        #region Private Functions

        private void LaughMeter()
        {
            GetComponent<Image>().fillAmount = CoreGameSignals.Instance.OnGetLaughMeter() / 100;
        }

        #endregion
    }
}
