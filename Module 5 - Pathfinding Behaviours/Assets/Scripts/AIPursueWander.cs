using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPursueWander : MonoBehaviour
{
    NavMeshAgent agentPW;

    public GameObject targetPW;

    public WASDMovement playerMovementPW;

    Vector3 wanderTargetPW;

    void Seek(Vector3 location)
    {
        agentPW.SetDestination(location);
    }

    void Wander()
    {
        float wanderRadius = 20;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTargetPW += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                    0,
                                    Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTargetPW.Normalize();
        wanderTargetPW *= wanderRadius;

        Vector3 targetLocal = wanderTargetPW + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    void Pursue()
    {
        Vector3 targetDirection = targetPW.transform.position - this.transform.position;

        if (targetDirection.x < 7.0f && targetDirection.x > -7.0f && targetDirection.z < 7.0f && targetDirection.z > -7.0f)
        {
            float lookAhead = targetDirection.magnitude / (agentPW.speed + playerMovementPW.currentSpeed);

            Seek(targetPW.transform.position + targetPW.transform.forward * lookAhead);
        }
        else
        {
            Wander();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agentPW = this.GetComponent<NavMeshAgent>();
        playerMovementPW = targetPW.GetComponent<WASDMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Pursue();
    }
}
