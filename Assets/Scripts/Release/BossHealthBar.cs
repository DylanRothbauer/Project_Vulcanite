using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHealthBar : MonoBehaviour
{
    //public float startingHealth = 1000.0f;
    //public float currentHealth = 1000.0f;
    public GameObject boss;

    private float scaleAdjustment;
    private float basePosition;
    private float baseYPosition;

    private EnemyHealth potato;

    // Start is called before the first frame update
    void Start()
    {
        //potato = GetComponent<EnemyHealth>();
        potato = boss.GetComponent<EnemyHealth>();
        scaleAdjustment = transform.localScale.x / potato.maxHealth;
        basePosition = transform.localPosition.x;
        baseYPosition = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //need to correct the positioning of the transform.position
        //potato = GetComponent<EnemyHealth>();
        transform.localScale = new Vector3(potato.currentHealth * scaleAdjustment, baseYPosition, 0f);
        float positionXAdjustment = (potato.currentHealth * scaleAdjustment - potato.maxHealth * scaleAdjustment) / 2;
        transform.localPosition = new Vector3(basePosition + positionXAdjustment, -0.03f, 1);
    }
}
