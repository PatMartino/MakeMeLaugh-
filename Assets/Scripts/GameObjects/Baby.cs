using System;
using System.Collections;
using System.Threading.Tasks;
using MoreMountains.Feedbacks;
using Signals;
using UnityEngine;
using Enums;
using Random = UnityEngine.Random;

namespace GameObjects
{
    public class Baby : MonoBehaviour
    {

        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private static readonly int AttackNumber = Animator.StringToHash("AttackNumber");
        
        private bool _hit = false;

        [SerializeField] private Sprite face1;
        [SerializeField] private Sprite face2;
        [SerializeField] private Sprite face3;
        [SerializeField] private Sprite face4;
        [SerializeField] private Sprite face5;
        [SerializeField] private Sprite face6;
        [SerializeField] private Sprite face7;
        [SerializeField] private Sprite face8;

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks attackFb;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(Intimidate());
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnChangeFace += OnChangeFace;
            CoreGameSignals.Instance.OnHitPlayer += OnHitPlayer;
            CoreGameSignals.Instance.OnGetHit += OnGetHit;
        }

        private void OnHitPlayer()
        {
            _spriteRenderer.sprite = face6;
            Debug.Log("Degis");
            _hit = true;
            StartCoroutine(WaitBum());
        }

        IEnumerator WaitBum()
        {
            yield return new WaitForSeconds(1.5f);
            //OnChangeFace();
            _hit = false;
            Debug.Log("222222");
        }

        private void OnChangeFace()
        {
            if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Beginner)
            {
                _spriteRenderer.sprite = face1;
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Easy)
            {
                _spriteRenderer.sprite = face2;
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Medium)
            {
                _spriteRenderer.sprite = face3;
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Hard)
            {
                _spriteRenderer.sprite = face4;
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Impossible)
            {
                _spriteRenderer.sprite = face5;
            }
        }

        private IEnumerator Intimidate()
        {
            var wait = Random.Range(8f, 15f);
            yield return new WaitForSeconds(wait);
            
            
            var random = Random.Range(1, 3);
            PlayAttack(random);
            
            yield return new WaitForSeconds(0.1f);
            _animator.SetInteger(AttackNumber, 0);
        }

        private void PlayAttack(int attackNumber)
        {
            _animator.SetInteger(AttackNumber, attackNumber);

            attackFb.PlayFeedbacks();
            
            StartCoroutine(Intimidate());
        }

        private bool OnGetHit()
        {
            return _hit;
        }
        
        
         private void OnTriggerEnter2D(Collider2D col)
         {
            if (col.gameObject.CompareTag("Player"))
            {
                if (col.transform.GetChild(0).GetChild(0).childCount>0) 
                {
                    if (col.transform.GetChild(0).GetChild(0).GetChild(0).CompareTag("BasicToy"))
                    {
                        Destroy(col.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
                        CoreGameSignals.Instance.OnIncreaseScore?.Invoke(50);
                        CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(18);
                        CoreGameSignals.Instance.OnChangeSprite?.Invoke();
                    } 
                }
            }
         }
    }
}
