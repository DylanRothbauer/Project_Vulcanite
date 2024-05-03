using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisualization : MonoBehaviour
{
    public Color colorNorm = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    public Color colorDam = new Color(255/255f,55/255f,55/255f);
    private float timer = 3;

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime*3;
        if (timer <= 0)
            timer = 3;
        else if (timer <= 1)
            gameObject.GetComponent<SpriteRenderer>().color = colorDam;
        else if (timer <= 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = colorNorm;
        }
        //Debug.Log("Timer = " + timer);
    }
}
