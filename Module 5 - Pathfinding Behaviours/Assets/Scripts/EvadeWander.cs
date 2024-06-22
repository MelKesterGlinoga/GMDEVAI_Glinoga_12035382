using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvadeWander : MonoBehaviour
{
    NavMeshAgent agentEW;

    public GameObject targetEW;

    public WASDMovement playerMovementEW;

    Vector3 wanderTargetEW;

    void Seek(Vector3 location)
    {
        agentEW.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeDirection = location - this.transform.position;
        agentEW.SetDestination(this.transform.position - fleeDirection);
    }

    void Wander()
    {
        float wanderRadius = 20;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTargetEW += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                    0,
                                    Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTargetEW.Normalize();
        wanderTargetEW *= wanderRadius;

        Vector3 targetLocal = wanderTargetEW + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    void Evade()
    {
        Vector3 targetDirection = targetEW.transform.position - this.transform.position;

        if(targetDirection.x < 12.0f && targetDirection.x > -12.0f && targetDirection.z < 12.0f && targetDirection.z > -12.0f)
        {
            float lookAhead = targetDirection.magnitude / (agentEW.speed + playerMovementEW.currentSpeed);

            Flee(targetEW.transform.position + targetEW.transform.forward * lookAhead);
        }
        else
        {
            Wander();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agentEW = this.GetComponent<NavMeshAgent>();
        playerMovementEW = targetEW.GetComponent<WASDMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Evade();
    }
}
