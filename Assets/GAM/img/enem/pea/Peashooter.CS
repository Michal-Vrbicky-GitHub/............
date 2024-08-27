

















using Unity.Burst.CompilerServices;
using UnityEngine;
using System.Collections;
public class PeaShooter : MonoBehaviour{
	public Vector2 offsetBum;
	public Vector2 offsetStrela;
	float perioda;
	public float rozptyl;//public float rozptyr; inteli xd				public float rozptyr2;public float rozptyr3;
	bool capturetheflag;
	public GameObject pifpaf;
	public GameObject Projektil;
	public GameObject boostTento;
	public GameObject hrac;
	private float boostTime;
	private float stunTajm = 2.1f;
	private int sightRange;
	private bool boost;
	private bool stunVNI;
	public bool stunVNE;//a proè je to prevet, vy jako nevidíte, že máte f kuchyni pneumatyky????? Chete se vùbec ještì vrtat?
	private bool cekej;
	private GameObject boostTentoTady;
	private AudioSource awakeSound;
	//private AudioSource attackSound;
	public int PattackRange;
	public float Pperioda;
	bool woke;
	byte stovosumdesát;/*
	public float voco;
	public float pleco;*/

	private void Start()
	{
		awakeSound  = transform.Find("awake") .GetComponent<AudioSource>();
	  //attackSound = transform.Find("attack").GetComponent<AudioSource>();
		sightRange  = PattackRange;
		perioda		= Pperioda;

	}

	void Update()
	{	if (stunVNE)
			StartCoroutine(StunHendl());
		if (stunVNI && !boost)
			return;
		float distanceToPlayer = Vector3.Distance(transform.position, hrac.transform.position);
		if (!woke)
		{	if (distanceToPlayer <= sightRange)
			{	awakeSound.Play();
				woke = true;
		}	}
		else
		{	RotateTowardsPlayer();
			if (distanceToPlayer <= sightRange  &&  !awakeSound.isPlaying  &&  !capturetheflag)
				StartCoroutine(Vystrel());
		}

		// Bootování
		if (boostTime > 0)
		{
			boostTime -= Time.deltaTime;
		}/*
		else if (boost)
		{
			boost = false;
			Destroy(boostTentoTady);
			ResetStats();
		}*/
	}
	byte hodneStunu = 0;
	IEnumerator StunHendl()
	{
		stunVNE = false;
		stunVNI = true;
		hodneStunu++;
		yield return new WaitForSeconds(stunTajm); // Poèkej 2 sekundy pøed dalším útokem
		hodneStunu--;
		if (hodneStunu == 0)
			stunVNI = false;
	}

	void RotateTowardsPlayer()
	{	Vector3 direction = (hrac.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;/*
		//float voco  = .052f;
		//float pleco = .025f;
		if (direction.x < 0  &&  !GetComponentInChildren<SpriteRenderer>().flipX)
		{
			GetComponentInChildren<SpriteRenderer>().flipX = true;
			transform.localPosition = new Vector3(-0.08f, .37f, -0);// transform.localPosition += new Vector3(-voco, -pleco, 0); // Posunutí spritu vlevo(-.072f, 0, 0);
			stovosumdesát = 180;
			offsetBum	 = new Vector2(-0.7f,  offsetBum   .y);
			offsetStrela = new Vector2(-0.63f, offsetStrela.y);
		}*/GameObject H = null;
		SpriteRenderer[] renderery = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer renderer in renderery)
			if (renderer != null) { 
				H = renderer.gameObject;
				break;}
		SpriteRenderer spratek = H.GetComponent<SpriteRenderer>();
		if (direction.x < 0  &&  !spratek.flipX)
		{
			spratek.flipX = true;
			H.transform.localPosition = new Vector3(-.08f, .37f, -0);
			stovosumdesát = 180;
			offsetBum	 = new Vector2(-0.7f,  offsetBum   .y);
			offsetStrela = new Vector2(-0.63f, offsetStrela.y);
		}
		else if (direction.x > 0  &&  spratek.flipX)
		{
			spratek.flipX = false;
			H.transform.localPosition = new Vector3(0.11f, .37f, 0);
			stovosumdesát = 0;
			offsetBum	 = new Vector2(0.86F,offsetBum	 .y);
			offsetStrela = new Vector2(0.84F,offsetStrela.y);
		}
		if(GetComponentInChildren<SpriteRenderer>().flipX)
			angle-=180;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	IEnumerator Vystrel()
	{
		capturetheflag = true;
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;
		Vector3 newPositionV = startPosition + transform.TransformDirection(offsetBum);
		Vector3 newPositionS = startPosition + transform.TransformDirection(offsetStrela);
		float randomAngle = Random.Range(-rozptyl/2, rozptyl/2);
		Quaternion newRotation = startRotation * Quaternion.Euler(0, 0, randomAngle-90-stovosumdesát);
		GameObject Pafpif = Instantiate(Projektil, newPositionS, newRotation);
		GameObject Pifpaf = Instantiate(pifpaf, newPositionV, newRotation);
		Pifpaf.transform.SetParent(transform);
		Pifpaf.SetActive(true);
		Pafpif.SetActive(true);
		yield return new WaitForSeconds(perioda);
		capturetheflag = false;
	}

	private void OnTriggerStay2D(Collider2D other)
	{	if (other.TryGetComponent<BuffTotem>(out BuffTotem bafTosem))
		{	boostTime = 6;
			if (!boost)
			{	StartCoroutine(BoostTimeout());
				boost = true;
				sightRange = 25;
				perioda /= 1.6f;
				boostTentoTady = Instantiate(boostTento, transform.position, Quaternion.identity, transform);
				boostTentoTady.SetActive(true);
	}	}	}
		
	

	IEnumerator BoostTimeout()
	{	while (boostTime > 0)
			yield return null;

		Destroy(boostTentoTady);/*
		ResetStats();
		//blbost = false;
		private void ResetStats()*/
		{
		sightRange = PattackRange;
		Destroy(boostTentoTady);
		perioda = Pperioda;
		boost = false;
	}
	}

	
}