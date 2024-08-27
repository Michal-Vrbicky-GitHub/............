using System.Collections;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pytliik : MonoBehaviour
{/// <summary>
/// //// lomeno je jediná klávesa, co se nepíše furt, dyš se drží AAAAAAAAAA
/// </summary>
	public GameObject hrac;
	protected int sightRange = 10;
	protected int attackRange = 2;
	protected int moveSpeed   = 2;
	protected int attackMoveSpeed = 8;
	protected bool vzbuzenej = false;
	protected bool attacknul = false;
	protected bool hit, atk, stunVNI;//pro odpočet
	public bool stunVNE;//pro nastavení flashem
	AudioSource Kladno;
	AudioSource awakeSound;
	AudioSource attackSound;
	protected float stunTajm = 2.1F;

	protected bool boost;
	protected float boostTime;
	public GameObject boostTento;
	protected GameObject boostTentoTady;

	public int PsightRange;
	public int PattackRange;
	public int PmoveSpeed;
	public int PattackMoveSpeed;
	public float SHHHHHtime = 1.2808f;
	public float dmg = 21;

	void Start()
	{
		awakeSound = transform.Find("awakw").GetComponent<AudioSource>();
		attackSound = transform.Find("attack").GetComponent<AudioSource>();
		Kladno = transform.Find("hit").GetComponent<AudioSource>();

		sightRange = PsightRange;
		attackRange = PattackRange;
		moveSpeed = PmoveSpeed;
		attackMoveSpeed = PattackMoveSpeed;
	}

	void Update()
	{	if (stunVNE) StartCoroutine(StunHendl());
		if(stunVNI &&  !boost) return;
		if(atk) { MoveTowardsPlayer(attackMoveSpeed); return; }//CS0212 Adresu volného výrazu jde převzftjenom uvnitř inicializátoru přikazu fixed.
		float distanceToPlayer = Vector3.Distance(transform.position, hrac.transform.position);
		if (!vzbuzenej)
		{	if (distanceToPlayer <= sightRange)
			{	if(awakeSound!=null)
				awakeSound.Play();
				vzbuzenej = true;
		}	}
		else
		{	RotateTowardsPlayer(-90);
			if (distanceToPlayer <= attackRange  &&  !attacknul  &&  !hit  &&  attackSound != null)
			{	MoveTowardsPlayer(attackMoveSpeed);
				//if ()
					StartCoroutine(Attack());
			}
			else
				MoveTowardsPlayer(moveSpeed);
	}	}



	protected void RotateTowardsPlayer(int oto)
	{/*
		Vector3 direction = (hrac.transform.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
		*/
		Vector3 direction = (hrac.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Získání úhlu v 2D
		transform.rotation = Quaternion.Euler(0, 0, angle+oto); // Rotace pouze podle osy Z
	}

	protected void MoveTowardsPlayer(float speed)
	{
		transform.position = Vector3.MoveTowards(transform.position, hrac.transform.position, speed * Time.deltaTime);
	}

	IEnumerator Attack()
	{
		atk =
		attacknul = true;

		// Přehraj útokový zvuk
		attackSound.Stop();//pretože j
		attackSound.Play();

		// Kód pro útok, např. poškození hráče nebo jiného objektu
		// Implementace závisí na tom, jak je Collider a damage mechanika nastavena


		//if(hit)
		yield return new WaitForSeconds(0.3f); // Počkej 2 sekundy před dalším útokem
		atk = false;

		yield return new WaitForSeconds(1.8f);
		attacknul = false;
	}

	private void OnCollisionStay2D(Collision2D collision)// AtEmsionEscape3D je prostě na hovno a lepčí si dělat FLEG  a  používat výhradně stejk
	{
		// Pokud nepřítel narazí do něčeho s komponentou "Aktor"
		if (collision.gameObject.GetComponent<Aktor>() != null  &&  !hit)
		{
			// Zavolej metodu dmg() na objektu s komponentou Aktor
			collision.gameObject.GetComponent<Aktor>().dmg(dmg);//dmg(smg);
			StartCoroutine(AttackShhh());
			hit=true;
			// Spusť útok, pokud zrovna neprobíhá
			Kladno.Play();
		}
	}

	IEnumerator AttackShhh()
	{
		int moveSpeed = this.moveSpeed;
		int attackMoveSpeed = this.attackMoveSpeed;
		this.moveSpeed = 0;
		this.attackMoveSpeed = 0;
		yield return new WaitForSeconds(SHHHHHtime);
		this.moveSpeed = moveSpeed;
		this.attackMoveSpeed = attackMoveSpeed;
		hit = false;
	}

	byte hodneStunu = 0;
	protected IEnumerator StunHendl()
	{	stunVNE = false;
		stunVNI = true;
		hodneStunu++;
		yield return new WaitForSeconds(stunTajm); // Počkej 2 sekundy před dalším útokem
		hodneStunu--;
		if(hodneStunu==0)
		stunVNI = false;
	}

	/**/
	void OnTriggerStay2D(Collider2D other)
	{	if (other.TryGetComponent<BuffTotem>(out BuffTotem buffTotem))/*  &&  !boost)*/
		{	boostTime = 5;
			if (!boost)
			{	StartCoroutine(BoostTimeout());
				boost = true;
				sightRange *= 16/10;
				attackRange *= 5/2;
				moveSpeed *= 3/2;
				attackMoveSpeed *= 24/8;
				// 8;//2.42f;
				boostTentoTady = Instantiate(boostTento, transform.position, Quaternion.identity, transform);
				boostTentoTady.SetActive(true);
			}
		}
	}//*//*
	IEnumerator BoostTimeout()
	{	while (boostTime > 0)
		{	boostTime -= Time.deltaTime;// Odpočítáváme čas
			yield return null; // Počká na další frame
		}
		Destroy(boostTentoTady);/*
		sightRange = 10;
		attackRange = 2;
		moveSpeed = 2;
		attackMoveSpeed = 8;*/
		boost = false;/*
		yield return new WaitForSeconds(boostTime);
		yield return null;*/
		Start();
	}
}
