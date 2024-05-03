using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCharm : Charm
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ApplyBuff(PlayerStats playerStats)
    {
        //base.applyBuff();
        float randomHealthBuff = Random.Range(0.15f, 0.35f); // More forgiving
        playerStats.health += (playerStats.GetMaxHealth() * randomHealthBuff);

        if (playerStats.health >= 100.00f)
        {
            playerStats.health = 100.00f;
        }
        //Debug.Log("Damage Charm Collected! Damage increased by " + (100 * randomDamageBuff) + "percent");
        string text = "+" + System.Math.Round(100 * randomHealthBuff, 2) + "% Health";

        ShowIndicator(text, this);
    }
}
