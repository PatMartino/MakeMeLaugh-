using System;
using System.Threading.Tasks;
using UnityEngine;
using Signals;

namespace GameObjects
{
    public class Stick : MonoBehaviour
    {
        #region Serialize Field

        [SerializeField] private Sprite noRing;
        [SerializeField] private Sprite oneRing;
        [SerializeField] private Sprite twoRing;
        [SerializeField] private Sprite threeRing;
        [SerializeField] private Sprite fourRing;
        [SerializeField] private Sprite fiveRing;

        #endregion
        
        #region Private Field

        private int _ringCount=0;
        private SpriteRenderer _spriteRenderer;

        #endregion

        #region Awake, OnEnable

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnGetRingCount += OnGetRingCount;
        }

        private async void ResetStick()
        {
            await Task.Delay(3000);
            _spriteRenderer.sprite = noRing;
            CoreGameSignals.Instance.OnIncreaseScore?.Invoke(250);
        }

        private int OnGetRingCount()
        {
            return _ringCount;
        }

        #endregion
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (col.transform.GetChild(0).GetChild(0).childCount>0)
                {
                    if (col.transform.GetChild(0).GetChild(0).GetChild(0).CompareTag("Ring"))
                    {
                        switch (_ringCount)
                        {
                            case 0:
                                _ringCount++;
                                _spriteRenderer.sprite = oneRing;
                                break;
                            case 1:
                                _ringCount++;
                                _spriteRenderer.sprite = twoRing;
                                break;
                            case 2:
                                _ringCount++;
                                _spriteRenderer.sprite = threeRing;
                                break;
                            case 3:
                                _ringCount++;
                                _spriteRenderer.sprite = fourRing;
                                break;
                            case 4:
                                _ringCount = 0;
                                _spriteRenderer.sprite = fiveRing;
                                CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(60);
                                ResetStick();
                                break;
                                
                        }
                        CoreGameSignals.Instance.OnIncreaseScore?.Invoke(15);
                        Destroy(col.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
                        CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(10);
                        CoreGameSignals.Instance.OnChangeSprite?.Invoke();
                    }
                }
            }
        }
    }
}
