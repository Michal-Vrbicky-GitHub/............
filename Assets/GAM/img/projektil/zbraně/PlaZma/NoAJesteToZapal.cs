using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAJesteToZapal : MonoBehaviour
{	public GameObject Ho�Svi�o;
	private void OnDestroy(){
		if (Random.Range(0, 100) < 13) { 
			GameObject newHo�Svi�o = Instantiate(Ho�Svi�o, transform.position, Quaternion.identity);
			newHo�Svi�o.SetActive(true);
}	}	}
	
