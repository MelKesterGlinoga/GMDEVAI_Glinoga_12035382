using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public GameObject player;
	public GameObject enemy;

	private GameManager manager;
	
	void OnCollisionEnter(Collision col)
    {
    	GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);

		if (col.gameObject.CompareTag("Player"))
		{
			manager.GetComponent<GameManager>().CheckCurrentPlayerHp();
		}
		else if (col.gameObject.CompareTag("Enemy"))
		{
			manager.GetComponent<GameManager>().CheckCurrentEnemyHp();
		}

    	Destroy(e,1.5f);
    	Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
		manager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
