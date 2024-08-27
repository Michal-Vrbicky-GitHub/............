using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst.CompilerServices;

public class AAAAAAAA : Pytliik
{
	public GameObject telAnim; // Animation object for teleportation effect
	public GameObject flame; // for throwing
	public RuntimeAnimatorController /*Animator*/ plAnimator; // The new animator to swamp in
	char actionChar = 'A'; // The action char, starting with 'A', dal tam: public string actionChar = 'A'; xd
	public AudioSource awakeTrack;
	public AudioSource yellTrack;
	public AudioSource Á;//HEAT
	public AudioSource P;//HE

	void Start()
	{
		sightRange = PsightRange;
		attackRange = PattackRange;
		moveSpeed = PmoveSpeed;
		attackMoveSpeed = PattackMoveSpeed;
	}

	void Update()
	{	if (stunVNE) StartCoroutine(StunHendl());
		if (stunVNI && !boost) return;
		float distanceToPlayer = Vector3.Distance(transform.position, hrac.transform.position);
		if (vzbuzenej)
		{	if (actionChar != 'P') { 
				MoveTowardsPlayer(attackMoveSpeed);
				if (distanceToPlayer <= attackRange  &&  actionChar == 'A')
					PerformAction();// Perform an attack based on the randomly chosen action
				if(!yellTrack.isPlaying)
					yellTrack.Play();
				if (distanceToPlayer <= attackRange  &&  !Á.isPlaying)
					Á.Play();
			}
			else { 
				RotateTowardsPlayer(0); yellTrack.Stop(); yellTrack.Stop(); yellTrack.Stop(); yellTrack.Stop(); yellTrack.Stop(); yellTrack.Stop();//proč se to nezastaví??????? AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
				if (distanceToPlayer <= attackRange  &&  !atk)
				{
					//GameObject flamewar = Instantiate(flame, transform.position +new Vector3(0f,0,0), Quaternion.Euler(transform.rotation.eulerAngles +new Vector3(0,0,-90)));
					Vector3 offset = new Vector3(1.5f, .1f, 0);
					Vector3 newPosition = transform.position + transform.TransformDirection(offset);//float rotationAdjustment = -90f; // Adjust as necessary
					Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, -90));
					GameObject flamewar = Instantiate(flame, newPosition, newRotation);
					flamewar.SetActive(true);
					StartCoroutine(Plamenomet());
				}
			}
		}
		else
		{   // Wake up and move towards the player if within sight range Malignant Butcher,' Maniacs FULL ALBUM (2014 - Groovy Goregrind).M4A2
			//float distanceToPlayer = Vector3.Distance(transform.position, hrac.transform.position);
			if (distanceToPlayer <= sightRange)
			{	/*if (awakeSound != null) */awakeTrack.Play();// to je takovej posera ten GPT, dyš neni awakeSound, tak ať to slítne, ať si všimnu, že ho tam nemam né
				vzbuzenej = true;
	}	}	}
		
	void PerformAction()
	{	actionChar = GetRandomAction();
		switch (actionChar)
		{	case 'P':
				PerformPAction();
				break;
			case 'T':
				PerformTAction();
				break;
			default: // 'aa' or any other char does nothing xd
				break;
	}	}
	

	char GetRandomAction()
	{//return 'T';
		// Randomly choose 'P', 'T', or 'G'
		int rand = Random.Range(0, 3);
		if (rand == 0) return 'P';
		else if (rand == 1) return 'T';
		else return 'a';
	}

	void PerformPAction()
	{
		// Change the Animator to a new one and stop movement
		GetComponentInChildren<Animator>().runtimeAnimatorController = plAnimator;//.runtimeAnimatorController;
		attackMoveSpeed = 0;
		moveSpeed = 0;
		/*
		// вращайся, товарищ!
		RotateTowardsPlayer();

		// If player is within range, spawn the flame object
		float distanceToPlayer = Vector3.Distance(transform.position, hrac.transform.position);
		if (distanceToPlayer <= attackRange)
		{
			GameObject flamewar = Instantiate(flame, transform.position, transform.rotation);
			flamewar.SetActive(true);
		}*/
		Transform childTransform = transform.GetChild(0);
		childTransform.localPosition = new Vector3(0.67f, childTransform.localPosition.y, childTransform.localPosition.z);
		BoxCollider2D collider = transform.GetComponent<BoxCollider2D>();
		collider.offset = new Vector2(0.19f, 0.01f);
		collider.size = new Vector2(0.69f, 0.7793427f);
		yellTrack.Stop();
		P.Play();
		attackRange *=2;
	}

	IEnumerator Plamenomet(){
		atk = true; 
		yield return new WaitForSeconds(0.13F);
		atk = false;
	}/*

	void PerformTAction()
	{	GameObject telesprite = Instantiate(telAnim, transform.position, Quaternion.identity);
		telesprite.SetActive(true);
		Vector3 direction = (transform.position - hrac.transform.position).normalized;
		transform.position = hrac.transform.position + direction * (2 * Vector3.Distance(transform.position, hrac.transform.position));
		telesprite = Instantiate(telAnim, transform.position, Quaternion.identity);
		telesprite.SetActive(true);
	}*/
	void PerformTAction()
	{
		// Create a teleportation effect at the current position
		GameObject telesprite = Instantiate(telAnim, transform.position, Quaternion.identity);
		telesprite.SetActive(true);

		// Calculate the direction from the player to the object (i.e., behind the player)
		Vector3 direction = (transform.position - hrac.transform.position).normalized;

		// Calculate the new position by moving the object the same distance, but in the opposite direction
		transform.position = hrac.transform.position - direction * Vector3.Distance(transform.position, hrac.transform.position);

		// Create another teleportation effect at the new position
		telesprite = Instantiate(telAnim, transform.position, Quaternion.identity);
		telesprite.SetActive(true);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{	if (collision.gameObject.GetComponent<Aktor>() != null)
		{	gameObject.GetComponent<LifeController>().ž = 0;
}	}	}
/*	captain void OnCollisionStay2D(Collision2D collision)
	{
		// Check if the collided object has a LifeController component
		if (collision.gameObject.GetComponent<LifeController>() != null)
		{
			// Set player's life to 0
			collision.gameObject.GetComponent<LifeController>().currentLife = 0;

			// Trigger death or destruction
			Destroy(gameObject);
		}
	}
}
*/