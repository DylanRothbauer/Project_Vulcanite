/*
 * Zachary Speckan
 * 03/29/24
 * Causes a random number of ice spikes to emerge from random spots in the ground.
 * 
 * warning - A warning symbol
 * spike - An ice spike
 * numberOfSpikes - The number of spikes that will spawn
 * 
 * xPosition - The x position of a spike
 * yPosition - The y position of a spike
 * spikePosition - An array of all spike locations
 * 
 * CHANGE LOG
 * Zach - 04/19/24 - Added sound effects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IceSpikesRandom : MonoBehaviour
{
    public GameObject warning;
    public GameObject spike;
    int numOfSpikes;
    public Rigidbody2D player;

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
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    numOfSpikes = Random.Range(10, 20);
        //    StartCoroutine(PrepareWarnings(numOfSpikes));
        //}
    }

    public IEnumerator PrepareWarnings(int num)
    {
        float xPosition = Random.Range(player.transform.position.x - 4.0f, player.transform.position.x + 4.0f);
        float yPosition = Random.Range(player.transform.position.y - 4.0f, player.transform.position.y + 4.0f);
        float zPosition = yPosition + 0.1f;
        Vector3[] spikePosition = new Vector3[num];

        for (int i = 0; i < num; i++)
        {   
            if (xPosition < -14.8f)
            {
                xPosition = -14.8f;
            }
            if (xPosition > 14.8f)
            {
                xPosition = 14.8f;
            }
            if (yPosition < -5.0f)
            {
                yPosition = -5.0f;
            }
            if (yPosition > 4.0f)
            {
                yPosition = 4.0f;
            }

            warning.transform.position = new Vector3(xPosition, yPosition, 0);
            spike.transform.position = new Vector3(xPosition, yPosition + 1.9f, zPosition);
            spikePosition[i] = spike.transform.position;
            //Debug.Log(warning.transform.position);
            Instantiate(warning, warning.transform.position, Quaternion.identity);
            xPosition = Random.Range(player.transform.position.x - 4.0f, player.transform.position.x + 4.0f);
            yPosition = Random.Range(player.transform.position.y - 4.0f, player.transform.position.y + 4.0f);
            zPosition = yPosition + 0.1f;
        }
        src.clip = playWarning;
        src.Play();

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < num; i++)
        {
            Instantiate(spike, spikePosition[i], Quaternion.identity);
        }
        src.clip = playEmerge;
        src.Play();
    }
}
