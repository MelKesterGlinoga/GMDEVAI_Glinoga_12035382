using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject turret;

    public float enemyHealth;
    private float maxEnemyHp = 1;

    public GameObject GetPlayer()
    {
        return player = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        enemyHealth = maxEnemyHp;
        Debug.Log("enemy script: " + enemyHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        }
        else if (player == null)
        {
            GetPlayer();
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent <Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 2.0f);
    }

    public void DecreaseHealth()
    {
        enemyHealth--;
        Debug.Log("Enemy health: " + enemyHealth);
        if (enemyHealth <= 0)
        {
            Debug.Log("destroy enemy");
            Destroy(gameObject);
        }
    }
}
