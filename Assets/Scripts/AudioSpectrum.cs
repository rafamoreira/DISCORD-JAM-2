﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float spectrumValue {get; private set;}
    public float [] m_audioSpectrum;


    private void Start(){
	m_audioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
	AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);

	if (m_audioSpectrum != null && m_audioSpectrum.Length > 0){
	    // Value only used to dernomalize
	    spectrumValue = m_audioSpectrum[0] * 100;
	}
    }
}
