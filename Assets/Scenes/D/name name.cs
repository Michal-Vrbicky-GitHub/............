using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoByloPosledni : MonoBehaviour	//Tohle je Singleton
{
	public static CoByloPosledni Instance { get; private set; }
	public string posledniScceennaa;

	private void Awake()
	{	if (Instance == null)
		{	Instance = this;
			DontDestroyOnLoad(gameObject);
		}else
			Destroy(gameObject);
	}

	public void TodleByloPosledni(string meno){
		posledniScceennaa = meno;
	}

	public string CoByloToPosledni(){
		return posledniScceennaa;//??
}	}
