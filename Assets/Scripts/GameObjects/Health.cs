using Signals;
using UnityEngine;
using Enums;

namespace GameObjects
{
    public class Health : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                CoreGameSignals.Instance.OnChangeHealth?.Invoke(GainOrLose.Gain,1);
                Destroy(gameObject);

            }
        }
    }
}
