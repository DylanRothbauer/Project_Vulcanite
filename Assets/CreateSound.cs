using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        src.clip = clip;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
