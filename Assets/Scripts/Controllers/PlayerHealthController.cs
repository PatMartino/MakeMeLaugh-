using Extensions;
using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerHealthController : MonoBehaviour
    {
        #region Private Fields

        private short _health = 3;
        private readonly short _maxHealth = 3;

        #endregion

        [SerializeField] private GameObject EndPanel;
        
        [SerializeField] private LevelManager LevelManager;

        #region OnEnable

        private void OnEnable()
        {
            SubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangeHealth += OnChangeHealth;
            CoreGameSignals.Instance.OnGetHealth += OnGetHealth;
        }

        private void OnChangeHealth(GainOrLose states, short value)
        {
            switch (states)
            {
                case GainOrLose.Lose:
                    _health -= value;
                    CoreGameSignals.Instance.OnHitPlayer?.Invoke();
                    IsDead();
                    
                    break;
                case GainOrLose.Gain:
                    _health += value;
                    IsReachedMaxHealth();
                    break;
            }
            CoreGameSignals.Instance.OnChangeHealthIcon?.Invoke();
            Debug.LogWarning(_health);
            //CoreGameSignals.Instance.OnUpdatingHealthBar?.Invoke(MaxHealth,health);
        }

        private void IsReachedMaxHealth()
        {
            if (_health>_maxHealth)
            {
                _health = _maxHealth;
            }
        }
        
        private void IsDead()
        {
            if (_health <= 0)
            {
                Debug.Log("Dead");
                CoreGameSignals.Instance.OnChangingGameStates.Invoke(GameStates.OnDead);
                EndPanel.SetActive(true);
                
                //LevelManager.DestroySelf();
            }
        }

        private short OnGetHealth()
        {
            return _health;
        }

        #endregion
    }
}
