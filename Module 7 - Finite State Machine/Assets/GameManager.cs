using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    public GameObject enemy;
    public int enemyCount = 3;

    private GameObject currentPlayer;
    private GameObject currentEnemy;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer(); // spawns player
        StartCoroutine(DelayedSpawn()); // delayed spawn of enemy
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPlayer();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemy();
        }
        currentEnemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void CheckCurrentPlayerHp()
    {
        if (currentPlayer.GetComponent<PlayerShooting>().playerHealth != 0)
        {
            // Decrease player HP
            currentPlayer.GetComponent<PlayerShooting>().playerHealth--;
            Debug.Log("currentPlayerHp: " + currentPlayer.GetComponent<PlayerShooting>().playerHealth);
            if (currentPlayer.GetComponent<PlayerShooting>().playerHealth <= 0)
            {
                DestroyObject(currentPlayer);
                //SpawnPlayer();
            }
        }
    }

    public void CheckCurrentEnemyHp()
    {
        if (currentEnemy.GetComponent<TankAI>().enemyHealth != 0 && currentEnemy != null)
        {
            // decrease enemy hp
            currentEnemy.GetComponent<TankAI>().enemyHealth--;
            if (currentEnemy.GetComponent<TankAI>().enemyHealth <= 0)
            {
                DestroyObject(currentEnemy);
                //SpawnEnemy();
            }
        }
    }

    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    private void SpawnPlayer()
    {
        currentPlayer = Instantiate(player);
    }

    private void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemy);
    }

    IEnumerator DelayedSpawn()
    {
        float timer = 2.0f;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        Debug.Log("spawned");
        SpawnEnemy();
        enemyCount--;
        
        if (enemyCount != 0)
        {
            StartCoroutine(DelayedSpawn());
        }
        else if (enemyCount <= 0)
        {
            StopCoroutine(DelayedSpawn());
        }
    }
}
