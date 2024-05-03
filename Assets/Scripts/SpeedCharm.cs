/*
 * Dylan Rothbauer
 * 03/25/24
 * Speed charm script for unity to be happy
 * 
 * CHANGE LOG
 * Dylan - 03/25/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedCharm : Charm
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
        float randomSpeedBuff = Random.Range(0.05f, 0.15f);
        playerStats.speed += (playerStats.speed * randomSpeedBuff);
        //Debug.Log("Speed Charm Collected! Speed increased by " + (100 * randomSpeedBuff) + "percent");
        string text = "+" + System.Math.Round(100 * randomSpeedBuff, 2) + "% Speed";

        ShowIndicator(text, this);
    }

}
