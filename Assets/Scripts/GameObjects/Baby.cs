using System;
using Signals;
using UnityEngine;

namespace GameObjects
{
    public class Baby : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (col.transform.GetChild(0).gameObject.activeSelf)
                {
                    col.transform.GetChild(0).gameObject.SetActive(false);
                    CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(15);
                }
            }
        }
    }
}
