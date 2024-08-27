using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozar : Ooze
{	new protected int dmg = 8;
	protected override IEnumerator DmgCoroutine()
	{	CircleCollider2D circularSaw = GetComponent<CircleCollider2D>();
		while (elapsedTime <= 18f)
		{	yield return new WaitForSeconds(0.66f);
			Collider2D[] horici;
			horici = Physics2D.OverlapCircleAll(circularSaw.transform.position, circularSaw.radius);//Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, 0f);//Physics2D.OverlapCollider(GetComponent<Collider2D>(), new ContactFilter2D());
			foreach (Collider2D skvarek in horici)
			{	LifeController lifeController = skvarek.GetComponent<LifeController>();
				Aktor hrac = skvarek.GetComponent<Aktor>();
				if (lifeController != null)
					lifeController.DMG(dmg, new Color(1, .42f, 0, 1));
				else if (hrac != null)
				{	hrac.dmg(dmg);}
			}
			elapsedTime += 1f;
		}
		Destroy(gameObject);
	}

	new protected/**/void OnTriggerStay2D(Collider2D kdoMaUhoretTenSeNeobesi)
	{	if (kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Pozar>() == null  &&  kdoMaUhoretTenSeNeobesi.gameObject.GetComponent<Strela>() == null  &&  kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Strela>() == null)//{	if (kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Pozar>() == null  &&  !kdoMaUhoretTenSeNeobesi.gameObject.GetComponent<Strela>()  &&  !kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Strela>()) takle dìlá kraviny
		{	GameObject oohenContainer = Instantiate(gameObject);
			Vector3 originalLossyScale = transform.lossyScale;
			oohenContainer.transform.SetParent(kdoMaUhoretTenSeNeobesi.transform);
			oohenContainer.transform.localPosition = Vector3.zero;//new Vector3(0,0);//other.transform.position;
			oohenContainer.transform.rotation = Quaternion.identity;
			Vector3 newLossyScale = oohenContainer.transform.lossyScale;
			oohenContainer.transform.localScale = new Vector3(
				oohenContainer.transform.localScale.x*(originalLossyScale.x/newLossyScale.x),
				oohenContainer.transform.localScale.y*(originalLossyScale.y/newLossyScale.y),
				oohenContainer.transform.localScale.z*(originalLossyScale.z/newLossyScale.z)
			);
		}
   else if (kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Pozar>() != null)
			kdoMaUhoretTenSeNeobesi.gameObject.GetComponentInChildren<Pozar>().elapsedTime=0;
	}

	private void Update(){
		gameObject.transform.rotation = Quaternion.identity;
}	}

