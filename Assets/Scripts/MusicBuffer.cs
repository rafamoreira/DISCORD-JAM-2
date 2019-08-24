using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuffer : MonoBehaviour
{
    public List<bool> beatList = new List<bool>();
    public List<float[]> pianoList = new List<float[]>();

    public void AddBeat()
    {
        beatList.Add(true);
    }

    public void AddPiano(float[] spectrum)
    {
        pianoList.Add(spectrum);
    }

    public void AddNonBeat()
    {
        beatList.Add(false);
    }

    public float[] SpectrumRetrieve()
    {
        float[] ret = pianoList[0]; 
        pianoList.RemoveAt(0);
        return ret;
    }

    public bool RetrieveBeat()
    {
        bool ret = beatList[0];
        beatList.RemoveAt(0);
        return ret;
    }
}
