using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer {
	public Vector3 beat_scale;
	public Vector3 rest_scale;

	IEnumerator MoveToScale(Vector3 target_scale)
	{
		Vector3 current_scale = transform.localScale;
		Vector3 initial_scale = current_scale;
		float timer = 0;

		while (current_scale != target_scale)
		{
			current_scale = Vector3.Lerp(initial_scale, target_scale, timer / timeToBeat);
			timer += Time.deltaTime;

			transform.localScale = current_scale;

			yield return null;
		}

		m_isBeat = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;

		transform.localScale = Vector3.Lerp(transform.localScale, rest_scale, resetSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();

		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beat_scale);
	}


}
