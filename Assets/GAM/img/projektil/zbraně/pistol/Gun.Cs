using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static UnityEngine.UI.Image;

public class Gun : MonoBehaviour
{
	public GameObject Projektil;
	public GameObject pifpaf;//ProjektilPrefab;
	protected float zpozdeni;
	public float kadence;//resp kadence^-1 AAAA perioda
	public float rozptyl;
	protected bool tomudleserikaflag;
	public Vector2 offsetBum;
	public Vector2 offsetStrela;
	protected Aktor cirkus;
	protected int nZbrane;
	protected/*private*/ float devadesat = -90;
	/*private*/protected bool cekej;

	bool tst;// = true;

	protected virtual void Awake()//private void Awake()
	{if(nZbrane==9) devadesat = 00;
		//zpozdeni = UnityEngine.Random.Range(0, kadence/1.8f);//0.1f//Time.realtimeSinceStartup;
		cirkus = transform.parent.parent.parent.GetComponent<Aktor>(); 
		nZbrane = int.Parse(transform.parent.name);
		zpozdeni = UnityEngine.Random.Range(0, kadence/4.2f);
   /*}*/if(nZbrane==9) zpozdeni = 00.000f;}

	protected virtual void Update()
	{
		if (Input.GetMouseButton(0) && !tomudleserikaflag && cirkus.zbranì[nZbrane][1]!=0 && !cekej)
		{//if (/*Input.GetMouseButton(0) && */!tomudleserikaflag && cirkus.zbranì[nZbrane][1]!=0) {
			StartCoroutine(Vystrel());
		}
		if (!!true && !tomudleserikaflag && tst)
			StartCoroutine(Vystrel());
	}

	protected IEnumerator Vystrel(){
		tomudleserikaflag = true;
		yield return new WaitForSeconds(zpozdeni);
		if (cirkus.zbranì[nZbrane][1] == 0) yield break; 
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;
		Vector3 newPositionV = startPosition + transform.TransformDirection(offsetBum);
		Vector3 newPositionS = startPosition + transform.TransformDirection(offsetStrela);
		float randomAngle = Random.Range(-rozptyl, rozptyl);
		Quaternion newRotation = startRotation * Quaternion.Euler(0, 0, randomAngle+devadesat);
		GameObject projektil = Instantiate(Projektil, newPositionS, newRotation);
		GameObject Pifpaf = Instantiate(pifpaf, newPositionV, newRotation);
		Pifpaf.transform.SetParent(transform);//Pifpaf.transform.parent = transform;
		projektil.SetActive(true);
		Pifpaf.SetActive(true);
		if(!tst) cirkus.zbranì[nZbrane][1]--;//
		yield return new WaitForSeconds(kadence-zpozdeni);//lze obejit maèkánim AAAAAAAAAAAAAAAAAA
		//if(nZbrane==9) if(!tst) cirkus.zbranì[nZbrane][0]--;
		tomudleserikaflag = false;
		yield break;
	}

	private void OnDisable()
	{
		tomudleserikaflag=false;
	}

	void OnEnable()
	{
		StartCoroutine(Cekej());
	}
	IEnumerator Cekej()
	{//if(nZbrane!=9){
		float koeficientCekani = .333f;
		if(nZbrane==9) koeficientCekani = .0101f;
		cekej = true;
		yield return new WaitForSeconds(kadence*koeficientCekani);//0.42f);//0.66f);//0.8f);
		cekej = false;
	}//}
}