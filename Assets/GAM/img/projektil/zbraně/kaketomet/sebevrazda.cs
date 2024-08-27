using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sebevrazda : MonoBehaviour
{   // Start is called before the first frame update
	private void OnDisable(){
		Destroy(gameObject);}
	void Update()
	{
		// Získá všechny potomky s komponentou AudioSource
		//AudioSource[] audioSources = GetComponentsInChildren<AudioSource>(includeInactive: true);

		foreach (Transform child in transform)
		{	AudioSource audioSource = child.GetComponent<AudioSource>();
			if (audioSource == null)
				return;
			if (audioSource.isPlaying)
				return;
		}
		Destroy(gameObject);
}	}

