using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class enemyGND : Greande
{
	public GameObject target;

	protected override void Start()
	{
		initialScale = transform.localScale.x;
		Vector3 startPosition = transform.position;
		Vector3 playerPosition =  target.transform.position;
		// NE cursorPosition.z = startPosition.z; // Ujisti se, e pozice kurzoru má stejnou hodnotu Z
		float diffX = Mathf.Abs(playerPosition.x - startPosition.x);
		float diffY = Mathf.Abs(playerPosition.y - startPosition.y);
		if (diffX > diffY)
		{
			midPoint = (startPosition.x + playerPosition.x) / 2;
			endPoint = playerPosition.x;
			X = true;
		}
		else
		{
			midPoint = (startPosition.y + playerPosition.y) / 2;
			endPoint = playerPosition.y;
		}
		if (midPoint > endPoint)
			vetsi = true;//zvetsuje resp
	}
}
