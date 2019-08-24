using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncLightColor : AudioSyncer {
    public Color[] beatColors;
    public Color restColor;

    private int m_randomIndx;    
    Light m_light;

    private void Start() {
	m_light = GetComponent<Light>();
    }
    
    private IEnumerator MoveToColor(Color target ) {
	Color current = m_light.color;
	Color initial_color = current;
	float timer = 0;
		
	while (current !=  target)
	{
	    current = Color.Lerp(initial_color,  target, timer / timeToBeat);
	    timer += Time.deltaTime;

	    m_light.color = current;

	    yield return null;
	}
	m_isBeat = false;
    }

    private Color ColorRanges() {
	if (beatColors == null || beatColors.Length == 0) return Color.white;
	m_randomIndx = Random.Range(0, beatColors.Length);
	return beatColors[m_randomIndx];
    }

    public override void OnUpdate() {
	base.OnUpdate();

	if (m_isBeat) return;

	m_light.color = Color.Lerp(m_light.color, restColor, resetSmoothTime * Time.deltaTime);
    }

    public override void OnBeat() {
	base.OnBeat();

	Color color = ColorRanges();

	StopCoroutine("MoveToColor");
	StartCoroutine("MoveToColor", color);
    }
}
