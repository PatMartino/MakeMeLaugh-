using System;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private byte speed;

        #endregion

        #region Private Fields

        private SpriteRenderer _charSprite;
        private Animator _animator;

        #endregion

        #region Awake

        private void Awake()
        {
            _charSprite = GetComponentInChildren<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Update

        private void Update()
        {
            Movement();
        }

        #endregion

        #region Private Functions

        private void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput>0)
            {
                _charSprite.flipX = false;
            }
            else if(horizontalInput<0)
            {
                _charSprite.flipX = true;
            }
            
            transform.Translate(horizontalInput*speed*Time.deltaTime,verticalInput*speed*Time.deltaTime,0);
            if (transform.position.y>1f)
            {
                var transformPosition = transform.position;
                transformPosition.y = 1f;
                transform.position = transformPosition;
            }
            if (transform.position.y < -3.85f)
            {
                var transformPosition = transform.position;
                transformPosition.y = -3.85f;
                transform.position = transformPosition;
            }
            if (transform.position.x < -8.35f)
            {
                var transformPosition = transform.position;
                transformPosition.x = -8.35f;
                transform.position = transformPosition;
            }
            if (transform.position.x > 8.35f)
            {
                var transformPosition = transform.position;
                transformPosition.x = 8.35f;
                transform.position = transformPosition;
            }

            if (Mathf.Abs(horizontalInput) >= 0.1f || Mathf.Abs(verticalInput) >= 0.1f)
            {
                _animator.Play("Move");
            }
            else
            {
                _animator.Play("Idle");
            }
        }

        #endregion
    }
}
