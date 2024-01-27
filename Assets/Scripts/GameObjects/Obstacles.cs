using Signals;
using UnityEngine;
using Enums;

namespace GameObjects
{
    public class Obstacles : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                CoreGameSignals.Instance.OnChangeHealth?.Invoke(GainOrLose.Lose,1);
            }
        }
    }
}
