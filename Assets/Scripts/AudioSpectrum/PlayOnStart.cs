using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    public AudioSource audio_source;
    
    // Start is called before the first frame update
    void Start()
    {
        audio_source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
