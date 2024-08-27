using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhenControl : MonoBehaviour
{
	float ET;
	private void Update()
	{
		ET += Time.deltaTime;
        if (ET >= 42f)
            GetComponent<Pozar>().elapsedTime = 42;
	}
}
