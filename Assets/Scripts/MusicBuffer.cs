using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuffer : MonoBehaviour
{
    public List<bool> beatList = new List<bool>();

    public void AddBeat()
    {
        beatList.Add(true);
    }

    public void AddNonBeat()
    {
        beatList.Add(false);
    }

    public bool RetrieveBeat()
    {
        bool ret = beatList[0];
        beatList.RemoveAt(0);
        return ret;
    }
}
