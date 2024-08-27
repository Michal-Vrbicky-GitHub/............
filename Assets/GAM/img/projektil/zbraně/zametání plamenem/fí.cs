using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fí : MonoBehaviour
{	AudioSource audioSource;
	void Start()
	{	audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{	if(transform.parent.parent.parent.parent.GetComponent<Aktor>().zbraně[7][1] > 0){
			if (Input.GetMouseButton(0) && !audioSource.isPlaying)
				audioSource.Play();
			else if (!Input.GetMouseButton(0) && audioSource.isPlaying)///*!Input.GetMouseButton(0) && */false!&audioSource.isPlaying)
				audioSource.Stop();}//bez závorek debuger ukazuje,
		else audioSource.Stop();//že sem to neskočí, ale skočí a AAAAAAAAAAAA
	}

	void OnEnable()
	{	if (audioSource.isPlaying)
			audioSource.Stop();
}	}

