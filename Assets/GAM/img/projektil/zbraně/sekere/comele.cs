using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class MeleSelect : MonoBehaviour
{
	public Aktor ply;
	public GameObject s;
	public GameObject m;
	//public void Start()
	void OnEnable()
    {/*
		StringWithQualityHeaderValue ddd;
		string ds = string.Empty;*/
		bool S = false;
		if (ply.zbranì[0][0]==1)								//{
			S=!S;
		s.SetActive(S);
		m.SetActive(!S);

	}

	void Update()
    {
        
    }
}
