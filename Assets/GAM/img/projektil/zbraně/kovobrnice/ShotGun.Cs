using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ShotgGun : Gun
{

	new protected virtual void Update()
	{
		if (Input.GetMouseButton(0) && !tomudleserikaflag && cirkus.zbran�[nZbrane][1] != 0 && !cekej)
		{
			StartCoroutine(Vystrel());
		}
	}

	new protected IEnumerator Vystrel()// a ten neni virtual a stejn� ho overridenu
	{
		tomudleserikaflag = true;
		yield return new WaitForSeconds(zpozdeni);
		if (cirkus.zbran�[nZbrane][1] == 0) yield break;
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;
		Vector3 newPositionV = startPosition + transform.TransformDirection(offsetBum);
		Vector3 newPositionS = startPosition + transform.TransformDirection(offsetStrela);
		GameObject projektil = null;
		Quaternion newRotation = transform.rotation;
		for (int i = 0; i < 18; i++) { 
			float randomAngle = Random.Range(-rozptyl, rozptyl);
			newRotation = startRotation *Quaternion.Euler(0, 0, randomAngle+90);
			projektil = Instantiate(Projektil, newPositionS, newRotation);
			projektil.SetActive(true);
		}
		GameObject Pifpaf = Instantiate(pifpaf, newPositionV, startRotation*Quaternion.Euler(0, 0, 180));
		Pifpaf.transform.SetParent(transform);
		Pifpaf.SetActive(true);
		cirkus.zbran�[nZbrane][1]--;
		yield return new WaitForSeconds(kadence - zpozdeni);
		tomudleserikaflag = false;
		yield break;
	}







	//protected override void Awake()
	//{
	//	base.Awake();
	//}

	//protected override void Update()
	//{
	//	//base.Update();
	//	//		Z�va�nost K�d Popis Projekt Soubor ��dek   Stav potla�en�
	//	//Upozorn�n� CS0114  '�len ShotgGun.Update() skryje zd�d�n� �len Gun.Update(). Pokud m� aktu�ln� �len tuto implementaci p�epsat, p�idejte kl��ov� slovo override. Jinak p�idejte kl��ov� slovo new.	Assembly-CSharp	D:\jako takov� n�co\VO�\2\Lrrrrrrrr\Pj�\py�o junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\projektil\zbran�\kovobrnice\ShotGun.Cs	35	Aktivn�
	//	if (Input.GetMouseButton(0) && !tomudleserikaflag && cirkus.zbran�[nZbrane][1]!=0) 
	//		for (int i = 0; i < 10; i++)
	//			StartCoroutine(Vystrel());
	//}

	//protected void OnDisable()
	//{
	//	tomudleserikaflag = false;
	//}

}