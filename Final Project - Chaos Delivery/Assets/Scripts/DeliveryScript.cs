using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryScript : MonoBehaviour
{
    public GameObject player;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && player.GetComponent<PlayerInventory>().packageOnHand > 0)
        {
            player.GetComponent<PlayerInventory>().DeliverPackage();
        }
    }
}
