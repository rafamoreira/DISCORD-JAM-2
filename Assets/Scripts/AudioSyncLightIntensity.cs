using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AudioSyncLightIntensity : AudioSyncer {
    public float intensity_scale;
    public float rest_intensity;

    Light m_light;

    private void Start()
    {
	m_light = GetComponent<Light>();
    }
    
    private IEnumerator MoveToIntensity(float target_intensity )
    {
	float current = m_light.intensity;
	float initial_intensity = current;
	float timer = 0;
		
	while (current !=  target_intensity) {
	    current = Mathf.Lerp(initial_intensity,  target_intensity, timer / timeToBeat);
	    timer += Time.deltaTime;

	    m_light.intensity = current;

	    yield return null;
	}

	m_isBeat = false;
    }

    public override void OnUpdate() {
	base.OnUpdate();

	if (m_isBeat) return;

	m_light.intensity = Mathf.Lerp(m_light.intensity, rest_intensity, resetSmoothTime * Time.deltaTime);
    }

    public override void OnBeat() {
	base.OnBeat();

	StopCoroutine("MoveToIntensity");
	StartCoroutine("MoveToIntensity", intensity_scale);
    }
}
