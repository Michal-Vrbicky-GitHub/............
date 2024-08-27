using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSaw : MonoBehaviour
{
	public GameObject/*AudioSource*/ nastartovana;
	public GameObject bezi;
	public GameObject reze;
	public BoxCollider2D kolize_protoze_nemuze_bejt_otocenej_collider;

	bool beziAleTentokratBool;
	//List<GameObject> hitnuty = new List<GameObject>();
	private HashSet<GameObject> hitnuty = new HashSet<GameObject>();/*
	Pro váš konkrétní pøípad, kde chcete rychle kontrolovat, zda objekt byl již zasažen, je HashSet vhodnìjší, protože umožòuje efektivní kontrolu na pøítomnost objektu.
	*/HashSet<GameObject> hitnuti = new HashSet<GameObject>();
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)){
			beziAleTentokratBool = true;
			nastartovana.SetActive(false);
			bezi.SetActive(true);
		}
		else if (Input.GetMouseButtonUp(0)){
			beziAleTentokratBool = false;
			nastartovana.SetActive(true);
			bezi.SetActive(false);
		}
		if(beziAleTentokratBool && hitnuty.Count > 0){
			bezi.SetActive(false);
			reze.SetActive(true);
		}
		else if(beziAleTentokratBool  &&  hitnuty.Count == 0  &&  hitnuti.Count == 0){
			bezi.SetActive(true);
			reze.SetActive(false);
		}
		else if (!beziAleTentokratBool && hitnuti.Count == 0){
			bezi.SetActive(false);
			reze.SetActive(false);
			nastartovana.SetActive(true);
		}
	}

	void OnEnable()
	{
		nastartovana.SetActive(true);
		bezi.SetActive(false);
		reze.SetActive(false);
		hitnuty.Clear();hitnuti.Clear();
	}

	IEnumerator Rezani(Collider2D collision)
	{
			GameObject obj = collision.gameObject;
			if (hitnuty.Contains(obj)) yield break;
			hitnuty.Add(obj); hitnuti.Add(obj);// i pro otaznik A)
			LifeController lifeController = collision.GetComponent<LifeController>();
			if (lifeController != null)
				lifeController.DMG(13);
		yield return new WaitForSeconds(0.808f);
		hitnuty.Remove(obj);
		yield return new WaitForSeconds(0.018f);//zZzZZzzerzerzzhdfhdth
		hitnuti.Remove(obj);

	}

	public void/*IEnumerator*/
	OnTriggerStay2D(Collider2D collision)
	{	if (beziAleTentokratBool && !hitnuty.Contains(collision.gameObject) && !collision.gameObject.GetComponent<Strela>())
			StartCoroutine(Rezani(collision));
	}	

	//IEnumerator Casovani
}
