using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AA : MonoBehaviour{
	public GameObject kra;
	public GameObject red;
	public GameObject blu;
	public GameObject mina;
	public GameObject pea;
	public GameObject sun;
	public GameObject AAAAAAAA;
	public GameObject AAsummoner;
	public GameObject T;
	bool AAAAAAAABigBoSS;

	public GameObject spawn;
	public GameObject WIN;
	public AudioSource arcsound;
	private float moveSpeed = 2f;
	private float moveDistance;
	private Vector3 moveDirection;
	private Vector2 boundaryCenter;
	private Vector2 boundarySize;
	public GameObject boundaryRect;

	void Start()
	{
		StartCoroutine(SpawnObjects());
		StartCoroutine(MoveRandomly());
		if (gameObject.name == "AAAAAAAA big boss")
			AAAAAAAABigBoSS = true;
	}

	private void Awake()
	{
		boundaryCenter = boundaryRect.transform.position;
		boundarySize = boundaryRect.GetComponent<SpriteRenderer>().bounds.size;
	}

	IEnumerator SpawnObjects()
	{	while (true == !false)
		{	yield return new WaitForSeconds(Random.Range(8, 16));
			GameObject objectToSpawn = GetRandomObject();
			int spawnCount = Random.Range(1, 6);
			for (int i = 0; i < spawnCount; i++)
			{	Vector3 randomPosition = transform.position +new Vector3(
					Random.Range(-3f, 3f),
					Random.Range(-3f, 3f),
					Random.Range(0f, 0F));//0);
				GameObject spawnInstance = Instantiate(spawn, randomPosition, Quaternion.identity);
				spawnInstance.GetComponent<AniKill>().spawn = objectToSpawn;
				spawnInstance.SetActive(true);
				yield return new WaitForSeconds(.1F);
	}	}	}
		
	
		IEnumerator MoveRandomly()
	{	while (!false){
			moveDirection = Random.insideUnitCircle.normalized;
			moveDistance = Random.Range(3, 16);
			Vector3 startPosition = transform.position;
			Vector3 endPosition = startPosition +moveDirection*moveDistance;
			float elapsedTime = 0;
			float journeyTime = moveDistance/moveSpeed;
			bool edge = false;
			while (elapsedTime < journeyTime){
				transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / journeyTime);
				elapsedTime += Time.deltaTime;
				if (IsOutsideBoundary(transform.position) && !edge){
					moveDirection = -moveDirection;
					startPosition = transform.position;
					endPosition = boundaryCenter;
					journeyTime = (endPosition - transform.position).magnitude / moveSpeed;
					elapsedTime = 0;
					edge = true;
				}
				yield return null;
			}
			yield return new WaitForSeconds(1.111F);
			arcsound.Play();
	}	}
	//IEnumerator MoveRandomly()
	//{	while (!false){
	//		moveDirection = Random.insideUnitCircle.normalized;
	//		moveDistance = Random.Range(3, 16);
	//		//Vector3 startPosition = transform.position;
	//		//Vector3 endPosition = startPosition +moveDirection*moveDistance;
	//		//float elapsedTime = 0;
	//		//float journeyTime = moveDistance/moveSpeed;
	//		//while (elapsedTime < journeyTime){
	//		//	transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / journeyTime);
	//		//	elapsedTime += Time.deltaTime;
	//		//	if (IsOutsideBoundary(transform.position)){
	//		//		//moveDirection = -moveDirection;/*
	//		//		//endPosition = transform.position + moveDirection * moveDistance;
	//		//		//journeyTime = (endPosition - transform.position).magnitude / moveSpeed;*/
	//		//		//elapsedTime = 0;
	//		//		moveDirection = (boundaryCenter - (Vector2)transform.position).normalized;
	//		//		targetPosition = transform.position + (Vector3)moveDirection * moveDistance;
	//		//		journeyTime = (targetPosition - transform.position).magnitude / moveSpeed;
	//		//		elapsedTime = 0;
	//		//	}
	//		Vector3 targetPosition = transform.position + moveDirection * moveDistance;
	//		float elapsedTime = 0;
	//		float journeyTime = moveDistance/moveSpeed;
	//		while (elapsedTime < journeyTime){
	//			transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / journeyTime);
	//			elapsedTime += Time.deltaTime;
	//			if (IsOutsideBoundary(transform.position))
	//			{	moveDirection = (boundaryCenter - (Vector2)transform.position).normalized;
	//				targetPosition = transform.position + (Vector3)moveDirection * moveDistance;
	//				journeyTime = (targetPosition - transform.position).magnitude / moveSpeed;
	//				elapsedTime = 0;
	//			}
	//			yield return null;
	//		}
	//		yield return new WaitForSeconds(1.111F);
	//		arcsound.Play();
	//}	}
	

	GameObject GetRandomObject()
	{
		GameObject[] objects = { kra, red, blu, mina, pea, sun, AAAAAAAA, pea, pea, pea, pea, pea, pea, pea, /*sun, sun, */sun, sun, AAAAAAAA, AAAAAAAA, AAAAAAAA, AAAAAAAA, AAAAAAAA, mina, mina, mina, mina, mina };
		if(AAAAAAAABigBoSS)
			objects = new GameObject[]{ pea, sun, AAAAAAAA, AAAAAAAA, AAAAAAAA,  T, AAsummoner, AAsummoner, AAsummoner, AAsummoner, AAsummoner };
		return objects[Random.Range(0, objects.Length)];
	}

	bool IsOutsideBoundary(Vector3 position)
	{
		float halfWidth  = boundarySize.x/2;
		float halfHeight = boundarySize.y/2;
		float xMin = boundaryCenter.x -halfWidth;
		float xMax = boundaryCenter.x +halfWidth;
		float yMin = boundaryCenter.y -halfHeight;
		float yMax = boundaryCenter.y +halfHeight;

		return position.x < xMin  || 
			position.x > xMax  ||  
			position.y < yMin  ||
			position.y > yMax;
	}

	private void OnDestroy()
	{
		//Destroy(gameObject); a to se vyplatÌ
		if(WIN!=null  &&  (AAAAAAAABigBoSS || gameObject.name == "AA boss")) Instantiate(WIN, transform.position, Quaternion.identity);
	}
}
//velkej nem· freze Z, aù se v·lÌa