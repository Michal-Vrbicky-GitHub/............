using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pju : MonoBehaviour
{	Animator animator;
	float originalHeight;
	float animationDuration;
	Vector3 originalPosition;
	Coroutine growHeightCoroutine;
	void Start()
	{	animator = GetComponent<Animator>();
		originalPosition = transform.localPosition;
			AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
				animationDuration = clips[0].length;
		originalHeight = transform.localScale.y;
		transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
		growHeightCoroutine = StartCoroutine(GrowHeightOverTime());
	}

	private IEnumerator GrowHeightOverTime()
	{	float elapsedTime = 0f;
		//float previousHeight = 0f;
		while (elapsedTime < animationDuration)
		{	elapsedTime += Time.deltaTime;
			// Lineární interpolace výšky od 0 do pùvodní výšky bìhem trvání animace
			float newHeight = Mathf.Lerp(0, originalHeight, elapsedTime/animationDuration);
			transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);
			float heightDifference = newHeight - transform.localScale.y;//- previousHeight;
			transform.localPosition = new Vector3(transform.localPosition.x, originalPosition.y + (newHeight / 1), transform.localPosition.z);//transform.position += new Vector3(0, heightDifference/2, 0);previousHeight = newHeight;
			yield return null;
}	}	}//transform.localScale = new Vector3(transform.localScale.x, originalHeight, transform.localScale.z);.position
