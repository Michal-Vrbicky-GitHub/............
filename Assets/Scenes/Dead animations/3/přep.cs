using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class přep : MonoBehaviour
{
	public double cas;
	public string scena;
    void Start()
    {
		StartCoroutine(S());//StartCoroutine(S(S(S(S(S(S()))))));inteli???

	}

	IEnumerator S()
	{
		yield return new WaitForSeconds((float)cas);
		SceneManager.LoadScene(scena);
	}
}
