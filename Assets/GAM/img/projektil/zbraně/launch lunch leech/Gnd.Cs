//Bez colidéru vìtší sranda
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
		// NE cursorPosition.z = startPosition.z; // Ujisti se, že pozice kurzoru má stejnou hodnotu Z
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
				Destroy(gameObject); // Zniè objekt po aukci
			}
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale, Time.deltaTime * 2f);
		}
	}
	/*
	 * 		// Urèi vìtší rozdíl a nastav midpoint a endpoint
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
				Debug.Log("Dosažen cíl!");
				Strela strelaScript = GetComponent<Strela>();
				if (strelaScript != null)
				{
					strelaScript.NaklonujBum(); // Zavolá metodu ze skriptu Strela
				}
				Destroy(gameObject); // Zniè objekt po akci
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

	//	// Vypoèítá støední bod mezi startPosition a cursorPosition
	//	midPoint = (startPosition.x + cursorPosition.x) / 2;

	//	// Uloží poèáteèní mìøítko
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
	//			// Zmenšuje mìøítko zpìt na pùvodní velikost
	//			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale, Time.deltaTime * 2f);

	//			// Pohyb smìrem k pozici kurzoru


	//			if (Vector3.Distance(transform.position, cursorPosition) < 0.5f)
	//			{
	//				// Zavolá metodu Bum ze skriptu Strela, který je na stejném objektu
	//				Strela strelaScript = GetComponent<Strela>();
	//				if (strelaScript != null)
	//				{
	//					strelaScript.NaklonujBum();
	//				}

	//				// Znièí granát po odpálení
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
potøebuju, aby si pøi spuštìní zjsistil world pozici kurzoru a svojí aktuální, je tam 2. skript co to hejbe tim smìrem, tady chci, aby se zvìtšoval obrázek, dokud nedosáhne støedu mezi poèátkem a pozicí kurzoru zjištìný na startu, po dosažení støedu se plynule zmenèí na pùvodní velikost, když dosáhne pozice, kede zjistil kurzor, zavolá naklonuj bum ze skriptu Strela, co je tam na tom stejnym objektu
*/