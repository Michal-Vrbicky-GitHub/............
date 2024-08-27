using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacak : Gun
{
	public GameObject ratata;
	public AudioSource tataKonec;
	bool jede, strilej;

	override protected void Update(){
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		Vector2 direction = mousePosition - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

		//if (Input.GetMouseButton(0))
		if (Input.GetMouseButton(0) && !tomudleserikaflag) {//true
			StartCoroutine(Vystrel());
		}
		/*else */if (!Input.GetMouseButton/*Up*/(0)){
			StartCoroutine(ZvukHandl(false));//Upale
		}
	}

	new protected IEnumerator Vystrel()
	{
		if(strilej && !jede)
			strilej = false;
		tomudleserikaflag = true;
		yield return new WaitForSeconds(zpozdeni);
		if (cirkus.zbranì[nZbrane][1] == 0){
			tomudleserikaflag = false;
			StartCoroutine(ZvukHandl(false));
			yield break;
		} else
			StartCoroutine(ZvukHandl(true));
		if (/*cirkus.zbranì[nZbrane][1] == 0  ||  */!strilej) {
			tomudleserikaflag = false;
			yield break;
		}
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;
		Vector3 newPositionV = startPosition + transform.TransformDirection(offsetBum);
		Vector3 newPositionS = startPosition + transform.TransformDirection(offsetStrela);
		float randomAngle = Random.Range(-rozptyl, rozptyl);
		Quaternion newRotation = startRotation * Quaternion.Euler(0, 0, randomAngle);
		GameObject projektil = Instantiate(Projektil, newPositionS, newRotation);//Quaternion.Euler(0, 0, 0)
		GameObject Pifpaf = Instantiate(pifpaf, newPositionV, newRotation);
		Pifpaf.transform.SetParent(transform);
		//projektil.transform.Rotate(Vector3.forward, 90f);
		projektil.SetActive(true);
		Pifpaf.SetActive(true);
		cirkus.zbranì[nZbrane][1]--;//cirkus.zbranì[nZbrane][1]--;
		yield return new WaitForSeconds(kadence -zpozdeni);
		tomudleserikaflag = false;
		yield break;
	}

	private void OnDisable(){
		tomudleserikaflag = jede = strilej = false;
		ratata.SetActive(false);
		tataKonec.Stop();
	}

	IEnumerator ZvukHandl(bool zapNeboVyp){
		if (zapNeboVyp && !jede){
			jede = true;
			tataKonec.Stop();
			ratata.SetActive(true);
			yield return new WaitForSeconds(0.9f);
			strilej = true;
		}
		else if (jede && !!!zapNeboVyp){
			ratata.SetActive(false);
			tataKonec.Play();
			strilej = jede = false;
		}
		yield break;
	}
}
