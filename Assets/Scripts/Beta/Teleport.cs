/*
 * Zachary Speckan
 * 03/25/24
 * Moves the subject to one of six locations.
 * 
 * boss - The subject
 * leftX - Leftmost location
 * middleX - Center location
 * rightX - Rightmost location
 * TopY - Topmost location
 * bottomY - Bottommost location
 * position - A location from a combined X and Y position
 * 
 * CHANGE LOG
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject boss;
    public GameObject warning;

    public float leftX = -12.0f;
    public float middleX = 0.0f;
    public float rightX = 12.0f;
    public float topY = 3.75f;
    public float bottomY = -4.0f;
    public float bossHeight = 1.2f;

    int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    MoveIt();
        //}
    }

    public IEnumerator MoveIt()
    {
        int prePosition = Random.Range(1, 7);

        if (prePosition == position)
        {
            StartCoroutine(MoveIt());
        }
        else
        {
            position = prePosition;
        }

        if (position == 1) //top left
        {
            warning.transform.position = new Vector3(leftX, topY, topY + 0.1f);
        }
        else if (position == 2) //top middle
        {
            warning.transform.position = new Vector3(middleX, topY, topY + 0.1f);
        }
        else if (position == 3) //top right
        {
            warning.transform.position = new Vector3(rightX, topY, topY + 0.1f);
        }
        else if (position == 4) //bottom left
        {
            warning.transform.position = new Vector3(leftX, bottomY, bottomY + 0.1f);
        }
        else if (position == 5) //bottom middle
        {
            warning.transform.position = new Vector3(middleX, bottomY, bottomY + 0.1f);
        }
        else if (position == 6) //bottom right
        {
            warning.transform.position = new Vector3(rightX, bottomY, bottomY + 0.1f);
        }
        Debug.Log("Warning position: " + warning.transform.position.y);
        Instantiate(warning, warning.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        boss.transform.position = new Vector3 (warning.transform.position.x, warning.transform.position.y + bossHeight, 0);
        Debug.Log("Boss position:" + boss.transform.position.y);
    }
}
