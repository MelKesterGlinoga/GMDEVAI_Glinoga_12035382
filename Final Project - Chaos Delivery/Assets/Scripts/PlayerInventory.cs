using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerInventory : MonoBehaviour
{
    public int packageOnHand = 0;
    public int score = 0;

    public bool canCarry;

    public TMP_Text packageCounter;
    public TMP_Text scoreCounter;

    // Start is called before the first frame update
    void Awake()
    {
        canCarry = true;
        packageCounter = GameObject.Find("PackageCounter").GetComponent<TMP_Text>();
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPackages()
    {
        packageOnHand += 5;
        canCarry = false;
        packageCounter.color = Color.white;
        packageCounter.text = "Package: " + packageOnHand;
    }

    public void DeliverPackage()
    {
        packageOnHand--;
        packageCounter.text = "Package: " + packageOnHand;
        AddScore();

        if (packageOnHand <= 0)
        {
            packageCounter.color = Color.red;
            canCarry = true;
        }
    }

    public void AddScore()
    {
        score++;
        scoreCounter.text = "Score: " + score;
    }
}
