using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dm : MonoBehaviour
{
	public string scena;

	public void Start()
	{
		Cursor.visible = true;
		gameObject.GetComponent<Button>().onClick.AddListener(StartKoroutine);
	}
	
	IEnumerator S()
	{
		Cursor.visible = false;
		yield return new WaitForSeconds(0.2f);
		SceneManager.LoadScene(scena);
	}

	void StartKoroutine()
	{
		StartCoroutine(S());
	}
}
