using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    // Valor que seta quando que um Beat eh registrado, Baseado no valor do Spectrum
    // checa se o valor esta acima ou abaixo, e registra a batida.
    public float bias;
    //  Nunca podem ter um tempo dentro desse timeStep
    public float timeStep;
    // Quanto tempo leva para chegar no estipulado
    public float timeToBeat;
    // Quanto tempo leva para voltar ao estipulado
    public float resetSmoothTime;

    float m_previousAudioValue;
    float m_audioValue;
    float m_timer;

    protected bool m_isBeat;

    public virtual void OnBeat(){
	Debug.Log("beat");
	m_timer = 0;
	m_isBeat = true;
    }

    public virtual void OnUpdate(){
	m_previousAudioValue = m_audioValue;
	m_audioValue = AudioSpectrum.spectrumValue;

	if (m_previousAudioValue > bias && m_audioValue <= bias){
	    if(m_timer > timeStep){
		OnBeat();
	    }
	}

	if (m_previousAudioValue <= bias && m_audioValue > bias){
	    if (m_timer > timeStep){
		OnBeat();
	    }
	}
    }

    void Update(){
	OnUpdate();
    }
}
