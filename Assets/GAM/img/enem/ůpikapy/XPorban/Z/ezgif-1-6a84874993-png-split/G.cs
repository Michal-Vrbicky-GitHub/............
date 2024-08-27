using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(Dylej());//a dìlej!
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator Dylej()
	{	yield return new WaitForSeconds(1.42f);
		Destroy(GetComponent<SpriteRenderer>());
		transform.GetChild(0).gameObject.SetActive(true);
		//}
	}
}
