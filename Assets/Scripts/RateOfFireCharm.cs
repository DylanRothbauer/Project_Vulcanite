using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateOfFireCharm : Charm
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
        Weapon weapon = FindObjectOfType<Weapon>();

        if (weapon != null)
        {
            float randomRateOfFireBuff = Random.Range(0.05f, 0.15f);
            weapon.fireDelay -= (weapon.fireDelay * randomRateOfFireBuff);
            string text = "+" + System.Math.Round(100 * randomRateOfFireBuff, 2) + "% Fire Rate";
            ShowIndicator(text, this);
        } else
        {
            Debug.Log("WEAPON IS NULL");
        }

        //Debug.Log("Damage Charm Collected! Damage increased by " + (100 * randomDamageBuff) + "percent");
        

        
    }

}
