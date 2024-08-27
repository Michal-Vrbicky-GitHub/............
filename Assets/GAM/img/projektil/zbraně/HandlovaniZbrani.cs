using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandlovaniZbrani : MonoBehaviour
{
	public GameObject p;
	public GameObject d;
	public GameObject t;
	public GameObject c;
	GameObject[] pdthc;
	Aktor a;
	byte n;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		int i = 0;
		foreach(GameObject h in pdthc) {
			if (a.vybraneZbrane[i] == n  &&  !h.activeSelf)
				h.SetActive(true);
			else if (a.vybraneZbrane[i] != n  &&  h.activeSelf)
				h.SetActive(false);
			i++;
			if (i == a.vybraneZbrane.Length)
				break;
		}
	}

	private void Awake()
	{
		a = transform.parent.parent.GetComponent<Aktor>();
		n = byte.Parse(gameObject.name);//byte.TryParse(gameObject.name, out n);
		pdthc = new GameObject[] {p,d,t,c};
		foreach(GameObject h in pdthc)
				h.SetActive(false);
	}
}
