using UnityEngine;
using Enums;
using Managers;
using Signals;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private UIEventSubscriptionTypes type;

        #endregion
        
        #region Private Field

        private Button _button;
        private bool _isInitialized = false;

        #endregion
        
        #region OnEnable, Start, OnDisable

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        private void OnEnable()
        {
            if (!_isInitialized)
            {
                SubscribeEvents();
                _isInitialized = true;
            }
        }

        #endregion

        #region Private Fields

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.PlayButton:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnChangingGameStates?.Invoke(GameStates.OnPlay));
                    _button.onClick.AddListener(() =>Destroy(transform.parent.gameObject));
                    break;
                case UIEventSubscriptionTypes.PlayAgain:
                    _button.onClick.AddListener(() =>SceneManager.LoadScene("Scenes/GameScene"));
                    break;
                case UIEventSubscriptionTypes.PlayAgain2:
                    _button.onClick.AddListener(() =>SceneManager.LoadScene("Scenes/GameScene"));
                    break;
            }
        }

        #endregion
    }
}
