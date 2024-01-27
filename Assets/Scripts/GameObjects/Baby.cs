using System;
using System.Collections;
using MoreMountains.Feedbacks;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameObjects
{
    public class Baby : MonoBehaviour
    {

        private Animator _animator;
        private static readonly int AttackNumber = Animator.StringToHash("AttackNumber");

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks attackFb;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(Intimidate());
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
        
        
         private void OnTriggerEnter2D(Collider2D col)
         {
            if (col.gameObject.CompareTag("Player"))
            {
                if (col.transform.GetChild(0).GetChild(0).childCount>0) 
                {
                    if (col.transform.GetChild(0).GetChild(0).GetChild(0).CompareTag("BasicToy"))
                    {
                        Destroy(col.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
                        CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(18);
                        CoreGameSignals.Instance.OnChangeSprite?.Invoke();
                    } 
                }
            }
         }
    }
}
