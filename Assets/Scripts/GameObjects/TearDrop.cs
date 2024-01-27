using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameObjects
{
    public class TearDrop : MonoBehaviour
    {
        #region OnEnable

        private void OnEnable()
        {
            ActivatingCollider();
            DestroyTearDrop();
        }

        #endregion

        #region Private Functions

        private async Task  ActivatingCollider()
        {
            await Task.Delay(1500);
            transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        }

        private async Task DestroyTearDrop()
        {
            await Task.Delay(2830);
            Destroy(gameObject);
        }

        #endregion
    }
}
