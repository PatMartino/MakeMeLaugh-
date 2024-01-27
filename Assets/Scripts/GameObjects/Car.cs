using System;
using UnityEngine;
using Enums;
using Signals;

namespace GameObjects
{
    public class Car : MonoBehaviour
    {
        #region Serialize Field

        [SerializeField] private VecihleTypes type;

        #endregion

        #region Private Field

        private int _speed;

        #endregion

        #region OnEnable, Update

        private void OnEnable()
        {
            SetSpeedByType();
        }

        private void Update()
        {
            Movement();
        }

        #endregion

        #region Private Fields

        private void SetSpeedByType()
        {
            switch (type)
            {
                case VecihleTypes.Car:
                    _speed = 3;
                    break;
                case VecihleTypes.Train:
                    _speed = 2;
                    break;
            }
        }

        private void Movement()
        {
            transform.Translate(_speed*Time.deltaTime,0,0);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                CoreGameSignals.Instance.OnChangeHealth?.Invoke(GainOrLose.Lose,1);
            }
        }

        #endregion
    }
}
