using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strela : MonoBehaviour
{
	public float speed;               // Rychlost pohybu projektilu
	public GameObject kour;           // Objekt, který  se má vytvoøit pøi Rychlost pohybu projektilu
	public GameObject bum;            // Objekt, který  se má vytvoøit pøi kolizi
	public GameObject mapaObjekt;     // Objekt, kterým se má definovat hranice mapy
	public int dmg;

	void Update()
	{   // Posun projektilu vpøed
		transform.Translate(Vector3.up * speed * Time.deltaTime); //transform.Translate(Vector3.right * speed * Time.deltaTime); jo tak vpøed jó? xd
		// Kontrola, zda není projektil mimo lampu
		if (JeMimoMapu())
		{
			NaklonujBum();
			Destroy(gameObject);
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{	if (gameObject.name.Contains("plamen") || (transform.parent != null && transform.parent.name.Contains("plamen")))//protože wtf s kolidérem, najednou se mu chce sežrat z potomka, dyš se mi to nehodí, ale s motorovkou sem musel dìlat AAAAAAAAAAAAAAAAAAAAAAAAAAAAA
			// Pokud ano, nic nedìlej
			return;
		// Zkontroluj, zda má objekt LifeController
		LifeController lifeController = collision.GetComponent<LifeController>();
		if (lifeController != null)
		{
			// Zavolej metodu DMG()
			lifeController.DMG(dmg);

			// Naklonuj bum a zniè projektil
			NaklonujBum();
			Destroy(gameObject);
		}
	}

	protected virtual bool JeMimoMapu()
	{
		// Zjisti velikost mapového objektu
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
			Debug.LogError("Projektil ani jeho pitomci nemají Renderer komponentu, což je dost zvláštní.");
			//Debug.LogException
		}
		// Zkontroluj, zda je projektil mimo hranice mapy s pøiètením 42x velikosti projektilu
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
		// Vytvoøení klonu objektu "bum" na pozici projektilu
		GameObject nezapominatToAktivovatDycky = Instantiate(bum, transform.position, Quaternion.identity);
		nezapominatToAktivovatDycky.SetActive(true);
	}
}


//Chcete-li vytvoøit skript, který posune projektil podle zadané rychlosti, zkontroluje kolizi, zavolá metodu DMG() na komponentì LifeController, a pokud dojde ke kolizi nebo pokud projektil opustí mapu, naklonuje objekt "bum" a sám se vymaže, mùžete použít následující kód: