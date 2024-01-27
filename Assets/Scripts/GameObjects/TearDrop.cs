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
            DestroyTearDrop();
        }

        #endregion

        #region Private Functions
        

        private async Task DestroyTearDrop()
        {
            await Task.Delay(1500);
            Destroy(gameObject);
        }

        #endregion
    }
}
