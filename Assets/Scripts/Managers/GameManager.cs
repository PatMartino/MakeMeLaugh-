using System;
using UnityEngine;
using Enums;
using Signals;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private GameStates gameState;
        
        #endregion

        #region Awake, OnEnable, OnDisable

        private void Awake()
        {
            Time.timeScale = 0.0f;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Fields

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangingGameStates += OnChangingGameState;
        }

        private void OnChangingGameState(GameStates states)
        {
            gameState = states;
            GameStates();
        }

        private void GameStates()
        {
            switch (gameState)
            {
                case Enums.GameStates.OnPause:
                    Time.timeScale = 0.0f;
                    break;
                case Enums.GameStates.OnPlay:
                    Time.timeScale = 1f;
                    break;
                case Enums.GameStates.OnDead:
                    Time.timeScale = 0.0f;
                    break;
            }
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangingGameStates -= OnChangingGameState;
        }

        #endregion
    }
}
