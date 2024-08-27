using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class čapka : MonoBehaviour
{/*
 //////   // Start is called before the first frame update
 //////   void Start()
 //////   {
        
 //////   }

 //////   // Update is called once per frame
 //////   void Update()
 //////   {
        
 //////   }*/

	//////// Doba trvání animace jedné fáze otáčení
	//////public float rotationDuration = 2f;
	//////// Interval mezi začátky otáčení
	//////public float interval = 20.0f;
	///////*
	//////// Počáteční rotace
	//////private Quaternion startRotation;
	//////// Rotace při otočení o 90 stupňů
	//////private Quaternion rotate90;
	//////// Rotace při otočení o 150 stupňů zpět
	//////private Quaternion rotate150;*/

	//////private Vector3 startRotation;
	//////private Vector3 rotate90;
	//////private Vector3 rotate150;

	//////void Start()
	//////{/*
	//////	// Nastavení počátečních hodnot rotace
	//////	startRotation = transform.rotation;
	//////	rotate90 = startRotation * Quaternion.Euler(0, 0, 90);
	//////	rotate150 = startRotation * Quaternion.Euler(0, 0, -150);*/
	//////	startRotation = transform.localEulerAngles;
	//////	rotate90 = startRotation + new Vector3(0, 0, 90);
	//////	rotate150 = startRotation + new Vector3(0, 0, -150);

	//////	// Spuštění korutiny
	//////	StartCoroutine(RotateRoutine());
	//////}

	//////IEnumerator RotateRoutine()
	//////{
	//////	while (true)
	//////	{/*
	//////		// Otočení o 90 stupňů
	//////		yield return RotateTo(rotate90, rotationDuration);
	//////		// Otočení zpět o 150 stupňů
	//////		yield return RotateTo(rotate150, rotationDuration);
	//////		// Návrat na počáteční rotaci
	//////		yield return RotateTo(startRotation, rotationDuration);*/
	//////		yield return RotateTo(rotate90, rotationDuration);
	//////		// Otočení zpět o 150 stupňů
	//////		yield return RotateTo(rotate150, rotationDuration);
	//////		// Návrat na počáteční rotaci
	//////		yield return RotateTo(startRotation, rotationDuration);
	//////		// Čekání na další rotaci
	//////		yield return new WaitForSeconds(interval);
	//////	}
	//////}

	//////IEnumerator RotateTo(Quaternion targetRotation, float duration)
	//////{
	//////	float timeElapsed = 0;

	//////	while (timeElapsed < duration)
	//////	{
	//////		// Lineární interpolace mezi aktuální a cílovou rotací
	//////		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, timeElapsed / duration);
	//////		timeElapsed += Time.deltaTime;
	//////		yield return null;
	//////	}

	//////	// Nastavení rotace na cílovou rotaci (pro případ zaokrouhlovacích chyb)
	//////	transform.rotation = targetRotation;
	//////}*
	////// Doba trvání animace jedné fáze otáčení
	////public float rotationDuration = 1.0f;
	////// Interval mezi začátky otáčení
	////public float interval = 20.0f;

	////// Počáteční rotace v Eulerových úhlech
	//////private Vector3 startRotation;
	////// Rotace při otočení o 90 stupňů
	////private Vector3 rotate90;
	////// Rotace při otočení o 150 stupňů zpět
	////private Vector3 rotate150;
	////Vector3 rotate60;

	////void Start()
	////{
	////	// Nastavení počátečních hodnot rotace
	////	//startRotation = transform.localEulerAngles;
	////	rotate90 =  new Vector3(0, 0, 90);
	////	rotate150 =  new Vector3(0, 0, -150);
	////	rotate60 =  new Vector3(0, 0, +60);

	////	// Spuštění korutiny
	////	StartCoroutine(RotateRoutine());
	////}

	////IEnumerator RotateRoutine()
	////{
	////	while (true)
	////	{
	////		// Otočení o 90 stupňů
	////		yield return RotateTo(rotate90, rotationDuration);
	////		// Otočení zpět o 150 stupňů
	////		yield return RotateTo(rotate150, rotationDuration);
	////		// Návrat na počáteční rotaci
	////		yield return RotateTo(rotate60, rotationDuration);
	////		// Čekání na další rotaci
	////		yield return new WaitForSeconds(interval);
	////	}
	////}

	////IEnumerator RotateTo(Vector3 targetRotation, float duration)
	////{
	////	Vector3 initialRotation = transform.localEulerAngles;
	////	float timeElapsed = 0;

	////	while (timeElapsed < duration)
	////	{
	////		// Lineární interpolace mezi aktuální a cílovou rotací
	////		transform.localEulerAngles = Vector3.Lerp(initialRotation, targetRotation, timeElapsed / duration);
	////		timeElapsed += Time.deltaTime;
	////		yield return null;
	////	}

	////	// Nastavení rotace na cílovou rotaci (pro případ zaokrouhlovacích chyb)
	////	transform.localEulerAngles = targetRotation;
	////}
	//// Doba trvání animace jedné fáze otáčení
	//public float rotationDuration = 1.0f;
	//// Interval mezi začátky otáčení
	//public float interval = 20.0f;

	//// Počáteční rotace kolem osy Z
	//private float startRotation;
	//// Rotace při otočení o 90 stupňů
	//private float rotate90;
	//// Rotace při otočení o 150 stupňů zpět
	//private float rotate150;

	//void Start()
	//{
	//	// Nastavení počátečních hodnot rotace
	//	startRotation = transform.localEulerAngles.z;
	//	rotate90 = startRotation + 90;
	//	rotate150 = startRotation - 150;

	//	// Spuštění korutiny
	//	StartCoroutine(RotateRoutine());
	//}

	//IEnumerator RotateRoutine()
	//{
	//	while (true)
	//	{
	//		// Otočení o 90 stupňů
	//		yield return RotateTo(90, rotationDuration);
	//		// Otočení zpět o 150 stupňů
	//		yield return RotateTo(-150, rotationDuration);
	//		// Návrat na počáteční rotaci
	//		yield return RotateTo(60, rotationDuration);
	//		// Čekání na další rotaci
	//		yield return new WaitForSeconds(interval);
	//	}
	//}

	//IEnumerator RotateTo(float targetRotation, float duration)
	//{
	//	float initialRotation = transform.localEulerAngles.z;
	//	float timeElapsed = 0;

	//	while (timeElapsed < duration)
	//	{
	//		// Interpolace mezi aktuální a cílovou rotací
	//		float newRotation = Mathf.LerpAngle(initialRotation, targetRotation, timeElapsed / duration);
	//		transform.localEulerAngles = new Vector3(0, 0, newRotation);
	//		timeElapsed += Time.deltaTime;
	//		yield return null;
	//	}

	//	// Nastavení rotace na cílovou rotaci (pro případ zaokrouhlovacích chyb)
	//	transform.localEulerAngles = new Vector3(0, 0, targetRotation);
	//}

	void Start(){
		StartCoroutine(RotateRoutine());
	}

	IEnumerator RotateRoutine()
	{	for(;;){
			yield return RotateTo(81,  1);
			yield return RotateTo(-66, 3);
			yield return RotateTo(0,   2);
			yield return new WaitForSeconds(42);
	}	}

	IEnumerator RotateTo(float targetRotation, float duration)
	{
		float initialRotation = transform.localEulerAngles.z;
		float timeElapsed = 0;

		while (timeElapsed < duration){
			float newRotation = Mathf.LerpAngle(initialRotation, targetRotation, timeElapsed / duration);
			transform.localEulerAngles = new Vector3(0, 0, newRotation);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		// Nastavení rotace na cílovou rotaci (pro případ zaokrouhlovacích chyb) YEÝ
		transform.localEulerAngles = new Vector3(0, 0, targetRotation);
	}
}
