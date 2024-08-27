using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAJesteToZapal : MonoBehaviour
{	public GameObject HoøSviòo;
	private void OnDestroy(){
		if (Random.Range(0, 100) < 13) { 
			GameObject newHoøSviòo = Instantiate(HoøSviòo, transform.position, Quaternion.identity);
			newHoøSviòo.SetActive(true);
}	}	}
	
