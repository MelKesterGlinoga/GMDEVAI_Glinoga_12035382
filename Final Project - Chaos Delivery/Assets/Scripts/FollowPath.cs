using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;

    float speed = 30.0f;
    float accuracy = 5.0f;
    float rotSpeed = 5.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;

    int currentWaypointIndex = 0;

    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        // closest node atm
        currentNode = graph.getPathPoint(currentWaypointIndex);

        // if we are close enough to the current waypoint, move to the next
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
                            transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        // if !endPath
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoHome()
    {
        graph.AStar(currentNode, wps[16]);
        currentWaypointIndex = 0;
    }

    public void GoToSuburbOne()
    {
        graph.AStar(currentNode, wps[3]);
        currentWaypointIndex = 0;
    }

    public void GoToSupermarket()
    {
        graph.AStar(currentNode, wps[8]);
        currentWaypointIndex = 0;
    }

    public void GoToPizza()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }

    public void GoToSuburbTwo()
    {
        graph.AStar(currentNode, wps[14]);
        currentWaypointIndex = 0;
    }

    public void GoToFoodAlley()
    {
        graph.AStar(currentNode, wps[19]);
        currentWaypointIndex = 0;
    }

    public void GoToCornerApt()
    {
        graph.AStar(currentNode, wps[24]);
        currentWaypointIndex = 0;
    }

    public void GoToCoffee()
    {
        graph.AStar(currentNode, wps[25]);
        currentWaypointIndex = 0;
    }

    public void GoToFactory()
    {
        graph.AStar(currentNode, wps[27]);
        currentWaypointIndex = 0;
    }

    public void GoToGasStation()
    {
        graph.AStar(currentNode, wps[22]);
        currentWaypointIndex = 0;
    }
}
