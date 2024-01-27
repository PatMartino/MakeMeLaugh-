using System;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private byte speed;

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
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(horizontalInput<0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            
            transform.Translate(horizontalInput*speed*Time.deltaTime,verticalInput*speed*Time.deltaTime,0);
            if (transform.position.y>1.15f)
            {
                var transformPosition = transform.position;
                transformPosition.y = 1.15f;
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
        }

        #endregion
    }
}
