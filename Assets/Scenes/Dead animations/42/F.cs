using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fa : MonoBehaviour
{

	void Start()
	{
		StartCoroutine(FadeIn());

	}

	IEnumerator FadeIn()
	{
		Image uiImage = GetComponent<Image>();
		float elapsedTime = 0;
		Color color = uiImage.color;
		color.a = 0;
		uiImage.color = color;
		while (elapsedTime < 4)
		{
			elapsedTime += Time.deltaTime;
			color.a = Mathf.Clamp01(elapsedTime/4);
			uiImage.color = color;
			yield return null;
		}
	}
}
