using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    public GameObject owner;
    public float speed = 3f;
    public float rotationSpeed = 3f;

    void Update()
    {
        Vector3 lookAtOwner = new Vector3(owner.transform.position.x, this.transform.position.y, owner.transform.position.z);

        Vector3 direction = lookAtOwner - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(lookAtOwner, transform.position) > 10)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
