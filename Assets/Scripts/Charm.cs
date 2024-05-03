/*
 * Dylan Rothbauer
 * 03/20/24
 * The Charm object - will be used for inheritance (hopefully)
 * 
 * CHANGE LOG
 * Dylan - 03/20/24 - Added a structure for different charms. Not yet functional
 * Dylan - 03/21/24 - Added more structure | Got feedback from Turner, inheritance looks like the way to go
 * Dylan - 04/17/24 - Added text functionality
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Charm : MonoBehaviour
{
    public string charmName;
    public TextMesh textMesh; // Component/Prefab

    private float Yoffset = 1.0f;
    private float Xoffset = -1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ApplyBuff(PlayerStats playerStats)
    {
        // A virtual function for children to override as needed
    }

    public void ShowIndicator(string text, Charm myself)
    {
        myself.GetComponent<SpriteRenderer>().enabled = false;
        myself.GetComponent<BoxCollider2D>().enabled = false;

        TextMesh tempText = Instantiate(textMesh,new Vector3(transform.position.x + Xoffset, transform.position.y + Yoffset, 0), Quaternion.identity);
        tempText.text = text;
        StartCoroutine(FloatAndFade(tempText, myself));

        // Coroutine
    }

    private IEnumerator FloatAndFade(TextMesh tempText, Charm myself)
    {
        float progress = 0.0f;
        float speed = 0.5f;
        Color startAlpha = tempText.color;
        Color endAlpha = Color.red;

        //TextMesh endAlpha = 0.0f;

        while (progress < 2.0f)
        {
            tempText.transform.Translate(Vector2.up * speed * Time.deltaTime);
            tempText.color = Color.Lerp(startAlpha, endAlpha, progress / 2);

            progress += Time.deltaTime;
            //Debug.Log(progress);
            // Lerp to move from startAlpha to endAlpha
            yield return null;
        }

        Destroy(tempText.gameObject);
        Destroy(myself.gameObject);

        //Debug.Log(progress);
        //yield return null; // stop for this frame, come back
    }
}