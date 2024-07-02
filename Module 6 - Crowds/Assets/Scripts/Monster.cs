using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject chaseObj;

    GameObject[] agents;

    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                GameObject monster = Instantiate(obstacle, hit.point, obstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControl>().DetectNewObstacle(hit.point);
                }
                StartCoroutine(DeleteSpawnedItem(monster));
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                GameObject gold = Instantiate(chaseObj, hit.point, chaseObj.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControl>().RunToObstacle(hit.point);
                }
                StartCoroutine(DeleteSpawnedItem(gold));
            }
        }
    }

    IEnumerator DeleteSpawnedItem(GameObject itemToDelete)
    {
        float timer = 5.0f;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }

        Destroy(itemToDelete);
    }
}
