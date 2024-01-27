using System;
using Signals;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private Transform handTransform;
        [SerializeField] private Sprite emptySprite;
        [SerializeField] private Sprite holdingSprite;

        private bool _isHolding;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangeSprite += ChangeSprite;
        }

        public void HoldObject(GameObject objectToHold)
        {
            
            if (handTransform.childCount==0)
            {
                objectToHold.transform.SetParent(handTransform);
                objectToHold.transform.position = handTransform.position;
                objectToHold.transform.rotation = handTransform.rotation;
            
                HandSprite();
            }
        }

        // public GameObject GetObjectFromHand()
        // {
        //     if (_isHolding) return handTransform.GetChild(0).gameObject;
        //     else return //empty
        // }

        private void ChangeSprite()
        {
            //if (handTransform.childCount>0) GetComponentInChildren<SpriteRenderer>().sprite = holdingSprite;
            //else
            GetComponentInChildren<SpriteRenderer>().sprite = emptySprite;
        }

        private void HandSprite()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = holdingSprite;
        }
    }
}
