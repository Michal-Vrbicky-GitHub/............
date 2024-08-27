using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour//:G
{	void Start()
	{	StartCoroutine(Dylej());
	}

	double aleToJePolomerNePrumer = 6.6666666666666666666666666666666666666666666666666666666666666666666667;
	IEnumerator Dylej()
	{
		yield return new WaitForSeconds(1.42f);
		//}
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(/*expl.*/transform.position, (float)aleToJePolomerNePrumer/2);
		foreach (Collider2D hitCollider in hitColliders)
		{
			Pytliik pytliikComponent = hitCollider.GetComponent<Pytliik>();
			if (pytliikComponent != null)
				pytliikComponent.stunVNE = true; // Nastav stunVNE na true
			PeaShooter peaComponent = hitCollider.GetComponent<PeaShooter>();
			if (peaComponent != null)
				peaComponent.stunVNE = true;
			AAAAAAAA AAAAAAAAComponent = hitCollider.GetComponent<AAAAAAAA>();
			if (AAAAAAAAComponent != null)
				AAAAAAAAComponent.stunVNE = true;

		}

		// Nakresli debug k�� na pozici exploze
		DrawDebugCross(transform.position); //DrawDebugCross(expl.transform.position);
		//tGameObject gameObject = new GameObject()
		GameObject tenfles = Instantiate(expl, transform.position, transform.rotation);
		tenfles.SetActive(true);
		Destroy(gameObject);
	}

	void DrawDebugCross(Vector3 position)
	{
		// D�lka �ar k��e
		float crossLength = (float)aleToJePolomerNePrumer;//*2f;//AAAAAAAAAAAAAAA ale ta chyba je naho�e, n� tady!

		// Definice sm�r� pro �ty�i ��ry, ka�d� pooto�en� o 45�
		Vector3[] directions = {
			new Vector3(1, 1, 0).normalized,  // Sm�r 45�
            new Vector3(-1, 1, 0).normalized, // Sm�r 135�
            new Vector3(-1, -1, 0).normalized,// Sm�r 225�
            new Vector3(1, -1, 0).normalized,	// Sm�r 315�
			//KURVO V�GUS, KAM SM��UJE�
			new Vector3(0, 1, 0).normalized,
            new Vector3(-1, 0, 0).normalized,
            new Vector3(0, -1, 0).normalized,
            new Vector3(1, 0, 0).normalized//norm�ln� jako
        };

		// Nakresli ka�dou ��ru
		foreach (Vector3 dir in directions)
		{
			Debug.DrawLine(position -dir*crossLength/2, position +dir*crossLength/2, Color.magenta, 18);
		}
	}


	public GameObject expl;
}
