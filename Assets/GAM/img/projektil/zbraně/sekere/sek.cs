using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class sek : MonoBehaviour
{
	AudioSource audioSource;
	Transform parentTransform;
	Coroutine rotationCoroutine;
	bool bezi, seka;
	List<GameObject> hitnuty = new List<GameObject>();

	void Awake()
	{
		parentTransform = transform.parent;
		audioSource = GetComponentInChildren<AudioSource>();
	}

	void Start()
	{
		
	}

	void OnEnable()
	{
		parentTransform.localEulerAngles = new Vector3(0, 0, -25);
		seka = false; hitnuty.Clear();
	}

	void OnDisable()
    {
		parentTransform.localEulerAngles = Vector3.zero;
		bezi = false;
    }

	void Update()
	{
		if (Input.GetMouseButtonDown(0)  &&  !bezi)
                rotationCoroutine = StartCoroutine(HandleRotation());
	}

	IEnumerator HandleRotation()
	{	bezi = true;
		while (true)
		{	audioSource.Play();
			seka = true;
			yield return RotateTo(42, 0.16f);
			seka = false;
			hitnuty.Clear();
			yield return RotateTo(-28, 0.8f);
			if (!Input.GetMouseButton(0))
				break;
		}
		rotationCoroutine = null;
		bezi = false;
	}

	IEnumerator RotateTo(float targetRotation, float duration)
	{
		float initialRotation = parentTransform.localEulerAngles.z;
		float timeElapsed = 0;
		while (timeElapsed < duration)
		{
			float newRotation = Mathf.LerpAngle(initialRotation, targetRotation, timeElapsed / duration);
			parentTransform.localEulerAngles = new Vector3(0, 0, newRotation);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		parentTransform.localEulerAngles = new Vector3(0, 0, targetRotation);
	}

	private void OnTriggerStay2D/*Enter2D*/(Collider2D collision)
	{	if (seka){
			GameObject obj = collision.gameObject;
			if (hitnuty.Contains(obj)) return;
			hitnuty.Add(obj);
			LifeController lifeController = collision.GetComponent<LifeController>();
			if (lifeController != null)
				lifeController.DMG(10);
}	}	}
	


