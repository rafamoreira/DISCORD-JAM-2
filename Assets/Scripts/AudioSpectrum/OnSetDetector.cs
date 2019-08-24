using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSetDetector : MonoBehaviour
{

    MusicBuffer mb;

    void Start ()
    {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
        mb = FindObjectOfType<MusicBuffer>();
    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected ()
    {
        mb.AddBeat();
        Debug.LogWarning("Beat!!!");
    }

    //This event will be called every frame while music is playing
    void onSpectrum (float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands
        mb.AddPiano(spectrum);
        
        // for (int i = 0; i < spectrum.Length; ++i) {
        //     Vector3 start = new Vector3 (i, 0, 170);
        //     Vector3 end = new Vector3 (i, spectrum [i]*10, 0);
        //     Debug.DrawLine (start, end);
        // }
    }
}
