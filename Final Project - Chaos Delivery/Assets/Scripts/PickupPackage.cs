using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPackage : MonoBehaviour
{
    public GameObject player;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && player.GetComponent<PlayerInventory>().canCarry)
        {
            player.GetComponent<PlayerInventory>().AddPackages();
        }
    }
}
