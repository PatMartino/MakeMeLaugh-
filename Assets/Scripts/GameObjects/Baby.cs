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
                 if (col.transform.GetChild(0).GetChild(0).childCount>0)
                {
                    if (col.transform.GetChild(0).GetChild(0).GetChild(0).CompareTag("BasicToy"))
                    {
                        Destroy(col.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
                        CoreGameSignals.Instance.OnIncreaseLaughMeter?.Invoke(18);
                        CoreGameSignals.Instance.OnChangeSprite?.Invoke();
                    }
                }
             }
         }
    }
}
