using Signals;
using UnityEngine;

namespace LaughMeter
{
    public class LaughMeter : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private float reduction;

        #endregion
        
        #region Private Fields

        private float _laughMeter = 100;

        #endregion

        #region OnEnable, Update, OnDisable

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void Update()
        {
            ReductionOfLaughMeter();
        }

        #endregion
        

        #region Private Funtions

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnGetLaughMeter += OnGetLaughMeter;
        }

        private void ReductionOfLaughMeter()
        {
            _laughMeter -= reduction;
            Debug.Log(_laughMeter);
        }

        private float OnGetLaughMeter()
        {
            return _laughMeter;
        }

        #endregion
    }
}
