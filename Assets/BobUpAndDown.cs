using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BobUpAndDown : MonoBehaviour
{
    public AnimationCurve myCurve;
    //public GameObject dependant1;
    //public GameObject dependant2;
    private GameObject lootBox;
    private bool boxExists = false;

    // Start is called before the first frame update
    void Start()
    {
        lootBox = GameObject.FindGameObjectWithTag("LootBox");
        if (lootBox != null)
        {
            boxExists = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

        if (boxExists)
        {
            if (!lootBox.GetComponent<BoxCollider2D>().enabled)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            //if (dependant1 == null)
            //{
            //    gameObject.SetActive(false);
            //}
        }
    }
}
