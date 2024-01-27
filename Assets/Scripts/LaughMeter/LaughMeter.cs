using Signals;
using UnityEngine;
using Enums;

namespace LaughMeter
{
    public class LaughMeter : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private float reduction;
        [SerializeField] private LaughMeterLevels level;

        #endregion
        
        #region Private Fields

        private float _laughMeter = 70;

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
            CoreGameSignals.Instance.OnGetLaughMeterLevels += OnGetLaughMeterLevel;
            CoreGameSignals.Instance.OnIncreaseLaughMeter += OnIncreaseLaughMeter;
        }

        private void ReductionOfLaughMeter()
        {
            if (Time.timeScale != 0)
            {
                _laughMeter -= reduction * Time.deltaTime;
                //Debug.Log(_laughMeter);
                if (_laughMeter < 0)
                {
                    _laughMeter = 0;
                }
                else if(_laughMeter>100)
                {
                    _laughMeter = 100;
                }
            }
            
            ChangeLevel();
        }

        private float OnGetLaughMeter()
        {
            return _laughMeter;
        }

        private void ChangeLevel()
        {
            level = _laughMeter switch
            {
                >= 75 => LaughMeterLevels.Easy,
                >= 50 and < 75 => LaughMeterLevels.Medium,
                >= 25 and < 50 => LaughMeterLevels.Hard,
                _ => LaughMeterLevels.Impossible
            };
        }

        private LaughMeterLevels OnGetLaughMeterLevel()
        {
            return level;
        }

        private void OnIncreaseLaughMeter(float amount)
        {
            _laughMeter += amount;
        }

        #endregion
    }
}
