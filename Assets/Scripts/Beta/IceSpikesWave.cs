/*
 * Zachary Speckan
 * 03/30/24
 * Causes several rows of spikes to emerage from the ground.
 * 
 * warning - A warning symbol
 * spike - An ice spike
 * 
 * xPosition - The x position of a spike
 * yPosition - The y position of a spike
 * sequence - An int that decides 
 * spikePosition - An array of all spike locations
 * spikeCount - Keeps track of the total number of spikes generated
 * 
 * CHANGE LOG
 * Zach - 04/19/24 - Added sound effects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikes : MonoBehaviour
{
    public GameObject warning;
    public GameObject spike;
    public AudioSource src;
    public AudioClip playWarning;
    public AudioClip playEmerge;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    StartCoroutine(SendTheSpikes());
        //}
    }

    public IEnumerator SendTheSpikes()
    {
        float xPosition;
        int sequence = Random.Range(0, 2);
        if (sequence == 0)
        {
            xPosition = -14.5f;
        }
        else
        {
            xPosition = -13.5f;
        }
        
        float yPosition = -5.5f;
        Vector3[] spikePosition = new Vector3[90];
        int spikeCount = 0;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                warning.transform.position = new Vector3(xPosition, yPosition, 0);
                spike.transform.position = new Vector3(xPosition, yPosition + 1.9f, yPosition + 0.1f);
                Instantiate(warning, warning.transform.position, Quaternion.identity);
                spikePosition[spikeCount] = spike.transform.position;
                spikeCount++;
                yPosition += 1.5f;
            }
            xPosition += 3.5f;
            yPosition = -5.5f;
        }
        src.clip = playWarning;
        src.Play();

        spikeCount = 0;

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 9;i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Instantiate(spike, spikePosition[spikeCount], Quaternion.identity);
                spikeCount++;
            }
        }
        src.clip = playEmerge;
        src.Play();
    }
}
