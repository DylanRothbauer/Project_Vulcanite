using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //[SerializeField]
    //public PlayerStats playerStats;


    public PlayerStats playerStats;

    private float startingHealth = 100.0f;
    private float currentHealth = 100.0f; //playerStats.health;
    private GameObject healthContainer;
    private float scaleAdjustment;
    private float basePosition;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = Resources.Load("PlayerStats") as PlayerStats;
        scaleAdjustment = transform.localScale.x / startingHealth;
        basePosition = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerStats.health;
        transform.localScale = new Vector3(currentHealth * scaleAdjustment,transform.localScale.y, 0f) ;
        float positionXAdjustment = (currentHealth * scaleAdjustment - startingHealth * scaleAdjustment) / 2;
        transform.localPosition = new Vector3(basePosition+positionXAdjustment, 0, 1);
    }
}
