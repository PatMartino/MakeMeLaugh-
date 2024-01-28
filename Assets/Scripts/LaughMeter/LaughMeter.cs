using System;
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

        [SerializeField] private float _laughMeter = 70;

        #endregion

        #region OnEnable, Update, OnDisable

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void Start()
        {
            _laughMeter = 70;
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
            if (_laughMeter >= 80)
                level = LaughMeterLevels.Beginner;
            else if (_laughMeter is >= 60 and < 80)
                level = LaughMeterLevels.Easy;
            else if (_laughMeter is >= 40 and < 60)
                level = LaughMeterLevels.Medium;
            else if (_laughMeter is >= 20 and < 40)
                level = LaughMeterLevels.Hard;
            else
                level = LaughMeterLevels.Impossible;

            if (level == LaughMeterLevels.Easy)
            {
                reduction = 4.3f;
            }
            else if (level == LaughMeterLevels.Medium)
            {
                reduction = 4.1f;
            }
            else
            {
                reduction = 3.9f;
            }

            if (CoreGameSignals.Instance.OnGetHit() == false)
            {
                CoreGameSignals.Instance.OnChangeFace?.Invoke();
            }
            
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
