using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRetriever : MonoBehaviour
{
    MusicBuffer mb;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 15;
        mb = FindObjectOfType<MusicBuffer>();
        timer = 4.5f;    
    }

    void Update()
    {
        if (timer > 0)
           timer -= Time.deltaTime; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            mb.RetrieveBeat();
        }
    }
}
