using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;

    public float playerHealth;
    private float maxHealth = 10;
    private int bulletCount;

    void Awake()
    {
        playerHealth = maxHealth;
        Debug.Log("player script: " + playerHealth);
        bulletCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && bulletCount > 0)
        {
            GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
            bulletCount--;
            StartCoroutine(ReloadGun());
        }
    }

    public void DecreasePlayerHealth()
    {
        playerHealth--;
        if (playerHealth <= 0 )
        {
            Debug.Log("Destry player");
            Destroy(this.gameObject);
        }
    }

    IEnumerator ReloadGun()
    {
        float timer = 1.0f;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        bulletCount = 1;
    }
}
