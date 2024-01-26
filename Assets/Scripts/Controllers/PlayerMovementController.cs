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
            transform.Translate(horizontalInput*speed*Time.deltaTime,verticalInput*speed*Time.deltaTime,0);
        }

        #endregion
    }
}
