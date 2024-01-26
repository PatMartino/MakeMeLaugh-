using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LaughMeterUI : MonoBehaviour
    {
        #region Update

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
