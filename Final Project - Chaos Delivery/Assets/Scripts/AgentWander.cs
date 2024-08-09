using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentWander : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject target;

    public PlayerController playerMovement;

    Vector3 wanderTargetEW;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        playerMovement = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Evade();
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeDirection = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeDirection);
    }

    void Wander()
    {
        float wanderRadius = 20;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTargetEW += new Vector3(wanderJitter,
                                    0,
                                    wanderJitter);
        wanderTargetEW.Normalize();
        wanderTargetEW *= wanderRadius;

        Vector3 targetLocal = wanderTargetEW + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    void Evade()
    {
        Vector3 targetDirection = target.transform.position - this.transform.position;

        if (targetDirection.x < 12.0f && targetDirection.x > -12.0f && targetDirection.z < 12.0f && targetDirection.z > -12.0f)
        {
            float lookAhead = targetDirection.magnitude / (agent.speed + playerMovement.speed);

            Flee(target.transform.position + target.transform.forward * lookAhead);
        }
        else
        {
            Wander();
        }
    }
}
