//Bez colid�ru v�t�� sranda
using UnityEngine;

public class Greande : MonoBehaviour{
	//private Vector3 startPosition;
	//private Vector3 cursorPosition;
	//private Vector3 midPoint;
	//private Vector3 endPoint;
	protected float midPoint;
	protected float endPoint;
	protected bool vetsi, reachedMidPoint, X;
	protected float initialScale;

	protected virtual void Start()
	{
		initialScale = transform.localScale.x;
		Vector3 startPosition;
		Vector3 cursorPosition;
		startPosition = transform.position;
		cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// NE cursorPosition.z = startPosition.z; // Ujisti se, �e pozice kurzoru m� stejnou hodnotu Z
		float diffX = Mathf.Abs(cursorPosition.x - startPosition.x);
		float diffY = Mathf.Abs(cursorPosition.y - startPosition.y);
		if (diffX > diffY)
		{
			midPoint = (startPosition.x + cursorPosition.x)/2;
			endPoint = cursorPosition.x;
			X = true;
		}
		else
		{
			midPoint = (startPosition.y + cursorPosition.y)/2;
			endPoint = cursorPosition.y;
		}
		if (midPoint > endPoint) 
			vetsi = true;//zvetsuje resp
	}

	void Update()
	{
		float transka;
		if (X)
			transka = transform.position.x;
        else
			transka = transform.position.y;

        if (!reachedMidPoint)
		{	if ((!vetsi  &&  transka > midPoint)  ||  (vetsi  &&  transka < midPoint))
				reachedMidPoint = true;
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale * 3f, Time.deltaTime * 2f);
		}
		else
		{	if ((!vetsi && transka>endPoint)  ||  (vetsi && transka<endPoint))
			{	GetComponent<Strela>().NaklonujBum();
				Destroy(gameObject); // Zni� objekt po aukci
			}
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale, Time.deltaTime * 2f);
		}
	}
	/*
	 * 		// Ur�i v�t�� rozd�l a nastav midpoint a endpoint
		if (diffX > diffY)
		{
			vetsi = true;
			float midX = (startPosition.x + cursorPosition.x) / 2;
			midPoint = new Vector3(midX, startPosition.y, startPosition.z);
			endPoint = new Vector3(cursorPosition.x, startPosition.y, startPosition.z);
		}
		else
		{
			vetsi = false;
			float midY = (startPosition.y + cursorPosition.y) / 2;
			midPoint = new Vector3(startPosition.x, midY, startPosition.z);
			endPoint = new Vector3(startPosition.x, cursorPosition.y, startPosition.z);
		}
	}

	void Update()
	{
		if (!reachedMidPoint)
		{
			// Pokud je vetsi true, kontroluj osu x, jinak osu y
			if ((vetsi && transform.position.x > midPoint.x) || (!vetsi && transform.position.y > midPoint.y))
			{
				reachedMidPoint = true;
			}
		}
		else
		{
			// Pokud je vetsi true, kontroluj osu x, jinak osu y
			if ((vetsi && transform.position.x >= endPoint.x) || (!vetsi && transform.position.y >= endPoint.y))
			{
				Debug.Log("Dosa�en c�l!");
				Strela strelaScript = GetComponent<Strela>();
				if (strelaScript != null)
				{
					strelaScript.NaklonujBum(); // Zavol� metodu ze skriptu Strela
				}
				Destroy(gameObject); // Zni� objekt po akci
			}
		}
	}
*/



	///*
	//Vector3 startPosition;
	//Vector3 cursorPosition;
	//float midPoint;
	//float endPoint;
	//bool reachedMidPoint, prvniSnimek = true, druhySnimek;
	//float initialScale;

	//void Start()
	//{
	//	cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	//	startPosition = transform.position;
	//	initialScale = transform.localScale.x;

	//	// Vypo��t� st�edn� bod mezi startPosition a cursorPosition
	//	midPoint = (startPosition.x + cursorPosition.x) / 2;

	//	// Ulo�� po��te�n� m���tko
	//}

	//void Update()
	//{/*
	//	if(druhySnimek){

	//	}
	//	else */if (!prvniSnimek) { 
	//		if (!reachedMidPoint)
	//		{
	//			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale * 3f, Time.deltaTime * 2f);
	//			//float aa = Vector3.Distance(transform.position, midPoint);
	//			if (transform.position.x > midPoint)
	//			{
	//				reachedMidPoint = true;
	//			}
	//		}
	//		else
	//		{
	//			// Zmen�uje m���tko zp�t na p�vodn� velikost
	//			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale, Time.deltaTime * 2f);

	//			// Pohyb sm�rem k pozici kurzoru


	//			if (Vector3.Distance(transform.position, cursorPosition) < 0.5f)
	//			{
	//				// Zavol� metodu Bum ze skriptu Strela, kter� je na stejn�m objektu
	//				Strela strelaScript = GetComponent<Strela>();
	//				if (strelaScript != null)
	//				{
	//					strelaScript.NaklonujBum();
	//				}

	//				// Zni�� gran�t po odp�len�
	//				Destroy(gameObject);
	//			}
	//		}
	//	}else prvniSnimek = false;// druhySnimek = true;


	//}








}




/*  Prompt:

using UnityEngine;

public class Greande : MonoBehaviour{
















}
pot�ebuju, aby si p�i spu�t�n� zjsistil world pozici kurzoru a svoj� aktu�ln�, je tam 2. skript co to hejbe tim sm�rem, tady chci, aby se zv�t�oval obr�zek, dokud nedos�hne st�edu mezi po��tkem a pozic� kurzoru zji�t�n� na startu, po dosa�en� st�edu se plynule zmen�� na p�vodn� velikost, kdy� dos�hne pozice, kede zjistil kurzor, zavol� naklonuj bum ze skriptu Strela, co je tam na tom stejnym objektu
*/