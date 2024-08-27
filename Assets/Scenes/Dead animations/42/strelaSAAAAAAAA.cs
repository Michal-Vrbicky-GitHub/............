using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strelaSAAAAAAAA : Strela
{
	protected override bool JeMimoMapu()
	{	Bounds hraniceMapy = mapaObjekt.GetComponent<Renderer>().bounds;
		Vector3 poziceProjektilu = transform.position;
		float velikostProjektilu;
		if (!GetComponent<Renderer>() && GetComponentInChildren<Renderer>())
			velikostProjektilu = GetComponentInChildren<Renderer>().bounds.size.x;
		else if (GetComponentInChildren<Renderer>())
			velikostProjektilu = GetComponent<Renderer>().bounds.size.x;
		else
		{ //return false;
			velikostProjektilu = 42;
			Debug.LogError("What da hell means kilometer????????");
			//Debug.LogException
		}
		byte jak_za_hranice = 0;
		if (poziceProjektilu.x > hraniceMapy.max.x +jak_za_hranice*velikostProjektilu ||
			poziceProjektilu.x < hraniceMapy.min.x -jak_za_hranice*velikostProjektilu ||
			poziceProjektilu.y > hraniceMapy.max.y +jak_za_hranice*velikostProjektilu ||
			poziceProjektilu.y < hraniceMapy.min.y -jak_za_hranice*velikostProjektilu)
			return true;
		return false;
}	}

