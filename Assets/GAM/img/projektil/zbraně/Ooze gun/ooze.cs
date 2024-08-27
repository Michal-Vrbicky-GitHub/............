using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze : MonoBehaviour
{
	protected int dmg = 1;  // Poèáteèní hodnota dmg
	public float elapsedTime = 0f;

	protected/**/void OnTriggerStay2D(Collider2D other)
	{	if (other.gameObject.GetComponentInChildren<Ooze>() == null)
		{	GameObject oozeContainer = new GameObject("OozeContainer");
			oozeContainer.transform.SetParent(other.transform);
			oozeContainer.AddComponent<Ooze>();
		}else
			other.gameObject.GetComponentInChildren<Ooze>().elapsedTime=0;// a pak velký dmg
	}

	void Start()
	{
		StartCoroutine(DmgCoroutine());
	}

	protected virtual IEnumerator DmgCoroutine(){
		LifeController lifeController = GetComponentInParent<LifeController>();
		Aktor hrac = GetComponentInParent<Aktor>();
		while (elapsedTime <= 13f){
			yield return new WaitForSeconds(1f);

			if (lifeController != null)
				lifeController.DMG(dmg, Color.green);
			else if(hrac != null) { 
				hrac.dmg(dmg/2);
				hrac.zivot -= dmg/4;
			}
			if (elapsedTime % 2f == 0)
				dmg *= 2;
			elapsedTime += 1f;
		}
		Destroy(gameObject);
}	}

