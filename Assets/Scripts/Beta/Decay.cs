/*
 * Zachary Speckan
 * 03/29/24
 * Removes an object after a short delay
 * 
 * CHANGE LOG
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FallAway());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FallAway()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
