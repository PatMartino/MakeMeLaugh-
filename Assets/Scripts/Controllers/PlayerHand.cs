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

        public void HoldObject(GameObject objectToHold)
        {
            if (_isHolding) return;
            objectToHold.transform.SetParent(handTransform);
            objectToHold.transform.position = handTransform.position;
            objectToHold.transform.rotation = handTransform.rotation;
            _isHolding = true;
            ChangeSprite();
        }

        // public GameObject GetObjectFromHand()
        // {
        //     if (_isHolding) return handTransform.GetChild(0).gameObject;
        //     else return //empty
        // }

        private void ChangeSprite()
        {
            if (_isHolding) GetComponentInChildren<SpriteRenderer>().sprite = holdingSprite;
            else GetComponentInChildren<SpriteRenderer>().sprite = emptySprite;
        }
    }
}
