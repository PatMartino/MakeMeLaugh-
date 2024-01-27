using System;
using UnityEngine;

namespace GameObjects
{
    public class BasicToy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                if (!col.transform.GetChild(0).gameObject.activeSelf)
                {
                    col.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
