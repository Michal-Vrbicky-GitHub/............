using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
	private AudioSource audioSource;
	public  GameObject  xp;
	public  float		xpSpyd = 808;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)//všichni rozbíjí, juchù
	{	if (!audioSource.isPlaying)
		{	audioSource.Play();
			for (int i=0; i<18; i++)//(int i=0; i<5; i++)//(int i=0; i<3; i++)
			{	GameObject clone = Instantiate(xp, transform.position, Quaternion.identity);/*
				Vector3 direction = Quaternion.Euler(0, 120*i, 0) * Vector3.forward;
				Rigidbody rb = clone.AddComponent<Rigidbody>();
				rb.useGravity = false;
				rb.velocity = direction*xpSpyd;*/
				Vector2 direction = Quaternion.Euler(0, 0, 20 * i) * Vector2.right;//12 72
				Rigidbody2D klonRb = clone.GetComponent<Rigidbody2D>();
				klonRb.velocity = direction * xpSpyd;
			}
			StartCoroutine(DestroyAfterSound());
		}
	}

	IEnumerator DestroyAfterSound()
	{
		yield return new WaitWhile(() => audioSource.isPlaying);
		Destroy(gameObject);
}	}


