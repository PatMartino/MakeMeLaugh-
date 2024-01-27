using System;
using Controllers;
using UnityEngine;

namespace GameObjects
{
    public class BasicToy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                col.GetComponent<PlayerHand>().HoldObject(this.gameObject);


                // if (!col.transform.GetChild(2).gameObject.activeSelf)
                // {
                //     col.transform.GetChild(2).gameObject.SetActive(true);
                //     Destroy(gameObject);
                // }
            }
        }
    }
}
