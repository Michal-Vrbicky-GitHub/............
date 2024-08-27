using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpO : MonoBehaviour
{
	public GameObject Circular;
	public float G = 1;//6,472×10−11 N·m2·kg−2
	private Rigidbody2D rb;
	public float maxVelocity;
	public float forceForceToHaveMaxForce;    // 
  //public Rect boundaryRect;
	public GameObject boundaryRect;
	Vector2 boundaryCenter;
	Vector2 boundarySize;
	/// <summary>
	/// /
	/// </summary>
	bool[] colApakHam = new bool[2];
	float collTimer = 0f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		boundaryCenter = boundaryRect.transform.position;
		boundarySize = boundaryRect.GetComponent<SpriteRenderer>().bounds.size;
	}

	void FixedUpdate()
	{	Rigidbody2D targetRb = Circular.GetComponent<Rigidbody2D>();
		Vector2 direction = (Vector2)Circular.transform.position - rb.position;
		float distance = direction.magnitude;
		float forceMagnitude = G*(rb.mass*targetRb.mass)/Mathf.Pow(distance, 2);//F = G * (m1 * m2) / R^2
		Vector2 force = direction.normalized * forceMagnitude;
		if (force.magnitude > forceForceToHaveMaxForce)
			force = force.normalized*forceForceToHaveMaxForce;
		rb.AddForce(force);
		if (rb.velocity.magnitude > maxVelocity)
			rb.velocity = rb.velocity.normalized *maxVelocity;
		Bounce();
	}
	void Bounce()
	{	Vector2 position = rb.position;
		float halfWidth = boundarySize.x/2;
		float halfHeight = boundarySize.y/2;
		float xMin = boundaryCenter.x -halfWidth;
		float xMax = boundaryCenter.x +halfWidth;
		float yMin = boundaryCenter.y -halfHeight;
		float yMax = boundaryCenter.y +halfHeight;
		if (position.x < xMin  ||  position.x > xMax)
			rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
		if (position.y < yMin  ||  position.y > yMax)
			rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
		position.x = Mathf.Clamp(position.x, xMin, xMax);
		position.y = Mathf.Clamp(position.y, yMin, yMax);
		/*
		Vector2 position = rb.position;
		if (position.x < boundaryRect.xMin  ||  position.x > boundaryRect.xMax)
			rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
		if (position.y < boundaryRect.yMin  ||  position.y > boundaryRect.yMax)
			rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
		position.x = Mathf.Clamp(position.x, boundaryRect.xMin, boundaryRect.xMax);
		position.y = Mathf.Clamp(position.y, boundaryRect.yMin, boundaryRect.yMax);*/
		rb.position = position;
	}

	/*	void OnCollisionStay2D(Collision2D collision)
	{	if (collision.gameObject.GetComponent<Aktor>() != null)
		{	colApakHam[0] = true;
			collTimer += Time.deltaTime;
			if (collTimer >= 4.2F)
			{colApakHam[1] = true;
}	}	}	}*/

	void OnTriggerStay2D(Collider2D collision)
	{	if (collision.gameObject.GetComponent<Aktor>() != null  &&  !colApakHam[0])
		{	colApakHam[0] = true;
			StartCoroutine(CollisionCoroutine());
		}
		else if (colApakHam[1])
		{	colApakHam[1]=false;
			int childCount = transform.childCount;//Transform[] children = GetComponentsInChildren<Transform>();
			int randomIndex = Random.Range(0, childCount-1/*children.Length*/);
			for (int i = 0; i < childCount-1/*children.Length*/; i++)
			{	//if(transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>() != null)
					//continue;
				if (i == randomIndex){
					transform.GetChild(i).gameObject.SetActive(false);//children[i].gameObject.SetActive(false);
				}else{
					Destroy(transform.GetChild(i).gameObject);//transform.GetChild(i).gameObject.SetActive(true);//children[i].gameObject.SetActive(true);
			}	}
			GetComponent<PowerUp>().enabled = true;
	}	}
			
		
	

	IEnumerator CollisionCoroutine()
	{	while (collTimer < 4.2F)
		{	collTimer += Time.deltaTime;
			yield return null;
		}
		colApakHam[1] = true;
		//GetComponent<PowerUp>().enabled = true;//PowerUp.SetActive(true);

		
		
	}

}





//111