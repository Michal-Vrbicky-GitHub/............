using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Tank : MonoBehaviour
{
	public GameObject fat;
	public GameObject lan;
	AudioSource horn;
	AudioSource motor;
	AudioSource kleine;
	AudioSource donner;
	public GameObject hrac;
	char attackType;
	public int sightRange;
	public int moveSpeed, rotSpeed;
	public int attackSpeed;
	public int strange;
	bool vzhuru, hit;
	float plrDist;
	float atkTimer;
	GameObject buffVec, buffVecL;
	public Vector2 off;

	private void Awake()
	{
		horn = transform.Find("horn").GetComponent<AudioSource>();
		motor = transform.Find("motor").GetComponent<AudioSource>();
		kleine = transform.Find("kleine").GetComponent<AudioSource>();
		donner = transform.Find("donnerweter").GetComponent<AudioSource>();
		buffVec = GameObject.Find("wgg");
	}

	void Start()
	{
		StartCoroutine(AtkTimerCoroutine());
	}

	void Update()
	{
		plrDist = Vector3.Distance(transform.position, hrac.transform.position);
		if (!vzhuru  &&  plrDist <= sightRange)
			vzhuru = true;
		if (vzhuru)
		{	RotateTowardsPlayer();
			if (atkTimer <= 0) {
				attackType = GetRandomAttack();
				if (attackType == 's')
					atkTimer = Random.Range(.3f, 2.1f);
				else
					atkTimer = 6;
				PerformAttack();
			}



		}
	}

	void PerformAttack()
	{
		if (attackType == 's')
		{	//vystøel
			Vector3 Pos = transform.position + transform.TransformDirection(off);
			GameObject projektilInstance = Instantiate(fat, Pos, transform.rotation);
			projektilInstance.SetActive(true);
			GameObject bumInstance = Instantiate(lan, Pos, transform.rotation);
			bumInstance.SetActive(true);
		}
		else if (attackType == 'S')
			StartCoroutine(WaitForHornThenMoveXD());
	}
	IEnumerator WaitForHornThenMoveXD()
	{
		horn.Play();
		yield return new WaitForSeconds(horn.clip.length/2.5f);
		StartCoroutine(MoveForward());
	}

	char GetRandomAttack()
	{
		int rand = Random.Range(0, 5);
		return rand == 0 ? 'S' : 's';
	}

	IEnumerator MoveForward()
	{
		hit = false;
		motor.Play();
		float moveDistance = plrDist*1.42F;//tvl to je moc, kde se to tu vzalo*2.1F;//*1.6f;;//strange * 2.2f; // Vzdálenost, kterou urazí – 
		Vector3 startPos = transform.position;
		Vector3 endPos = transform.position + transform.up * moveDistance;//transform.right * moveDistance; tak si blbej??
		float t = 0;
		while (t < 1){
			t += Time.deltaTime * attackSpeed / moveDistance;
			transform.position = Vector3.Lerp(startPos, endPos, t);
			yield return null;
		}
		hit = true;
	}

	IEnumerator AtkTimerCoroutine()
	{	for (; ; ) { 
			atkTimer -= Time.deltaTime;
			yield return null;
	}	}

	void RotateTowardsPlayer()
	{
		Vector3 direction = (hrac.transform.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
	}

	void OnCollisionStay2D(Collision2D collision)
	{	if (collision.gameObject.GetComponent<Aktor>() != null && !hit)
		{	collision.gameObject.GetComponent<Aktor>().dmg(50);
			hit = true;
		}
	}
}
