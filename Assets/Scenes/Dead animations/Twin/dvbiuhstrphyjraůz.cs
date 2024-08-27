using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dvbiuhstrphyjraůz : MonoBehaviour
{
    // Start is called before the first frame updatepubic gamobeaaaaaaaaaaa

    public GameObject AAAAA1;
public GameObject AAAAA2;
    public GameObject AAAAA3;
    public GameObject AAAAA4;
    public GameObject AAAAA5;
    public GameObject AAAAA6;
        
        
    public GameObject AAAAA7;
        
        
        
        
        
        
    public GameObject AAAAA8;
    public GameObject AAAAA9;
    public GameObject AAAAA10;
        
        public GameObject AAAAA11;
    public GameObject AAAAA12;


    public GameObject AAAAA13;

    //inteli má zpoždění, nejde to aaaaaaaaaaaaa
	void Start()
    {
        StartCoroutine(IT());
    }

    // Update is called once per frame
    IEnumerator IT()
    {
		yield return new WaitForSeconds(0.999999F);
		AAAAA2.SetActive(true);
		AAAAA1.SetActive(false);
		yield return new WaitForSeconds(7.1F);
		AAAAA3.SetActive(true);
        AAAAA2.SetActive(false);
		yield return new WaitForSeconds(5);
		AAAAA4.SetActive(true); AAAAA5.SetActive(true); AAAAA6.SetActive(true);
		AAAAA3.GetComponent<Strela>().enabled = true;
		yield return new WaitForSeconds(5);
		AAAAA5.GetComponent<Strela>().enabled = true;
		AAAAA4.GetComponent<Strela>().enabled = true;
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("Menu");
	}
}
