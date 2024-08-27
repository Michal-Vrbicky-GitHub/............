using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strela : MonoBehaviour
{
	public float speed;               // Rychlost pohybu projektilu
	public GameObject kour;           // Objekt, kter�  se m� vytvo�it p�i Rychlost pohybu projektilu
	public GameObject bum;            // Objekt, kter�  se m� vytvo�it p�i kolizi
	public GameObject mapaObjekt;     // Objekt, kter�m se m� definovat hranice mapy
	public int dmg;

	void Update()
	{   // Posun projektilu vp�ed
		transform.Translate(Vector3.up * speed * Time.deltaTime); //transform.Translate(Vector3.right * speed * Time.deltaTime); jo tak vp�ed j�? xd
		// Kontrola, zda nen� projektil mimo lampu
		if (JeMimoMapu())
		{
			NaklonujBum();
			Destroy(gameObject);
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{	if (gameObject.name.Contains("plamen") || (transform.parent != null && transform.parent.name.Contains("plamen")))//proto�e wtf s kolid�rem, najednou se mu chce se�rat z potomka, dy� se mi to nehod�, ale s motorovkou sem musel d�lat AAAAAAAAAAAAAAAAAAAAAAAAAAAAA
			// Pokud ano, nic ned�lej
			return;
		// Zkontroluj, zda m� objekt LifeController
		LifeController lifeController = collision.GetComponent<LifeController>();
		if (lifeController != null)
		{
			// Zavolej metodu DMG()
			lifeController.DMG(dmg);

			// Naklonuj bum a zni� projektil
			NaklonujBum();
			Destroy(gameObject);
		}
	}

	protected virtual bool JeMimoMapu()
	{
		// Zjisti velikost mapov�ho objektu
		Bounds hraniceMapy = mapaObjekt.GetComponent<Renderer>().bounds;

		// Zjisti pozici projektilu
		Vector3 poziceProjektilu = transform.position;

		// Zjisti velikost projektilu
		float velikostProjektilu;
		if (!GetComponent<Renderer>() && GetComponentInChildren<Renderer>())
			velikostProjektilu = GetComponentInChildren<Renderer>().bounds.size.x;
		else if (GetComponentInChildren<Renderer>())
			velikostProjektilu = GetComponent<Renderer>().bounds.size.x;
		else { //return false;
			velikostProjektilu = 42;
			Debug.LogError("Projektil ani jeho pitomci nemaj� Renderer komponentu, co� je dost zvl�tn�.");
			//Debug.LogException
		}
		// Zkontroluj, zda je projektil mimo hranice mapy s p�i�ten�m 42x velikosti projektilu
		if (poziceProjektilu.x > hraniceMapy.max.x + 42 * velikostProjektilu ||
			poziceProjektilu.x < hraniceMapy.min.x - 42 * velikostProjektilu ||
			poziceProjektilu.y > hraniceMapy.max.y + 42 * velikostProjektilu ||
			poziceProjektilu.y < hraniceMapy.min.y - 42 * velikostProjektilu)
		{
			return true;
		}

		return false;
	}

	public void NaklonujBum()
	{
		if (bum == null) { return; ; }
		// Vytvo�en� klonu objektu "bum" na pozici projektilu
		GameObject nezapominatToAktivovatDycky = Instantiate(bum, transform.position, Quaternion.identity);
		nezapominatToAktivovatDycky.SetActive(true);
	}
}


//Chcete-li vytvo�it skript, kter� posune projektil podle zadan� rychlosti, zkontroluje kolizi, zavol� metodu DMG() na komponent� LifeController, a pokud dojde ke kolizi nebo pokud projektil opust� mapu, naklonuje objekt "bum" a s�m se vyma�e, m��ete pou��t n�sleduj�c� k�d: