using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
	public GameObject Napis;
	public GameObject Zvyrazneenej;

	void Start()
	{
		Napis.SetActive(true);
		Zvyrazneenej.SetActive(false);
	}

	void OnMouseEnter()
	{
		Napis.SetActive(false);
		Zvyrazneenej.SetActive(true);
	}

	void OnMouseExit()
	{
		Napis.SetActive(true);
		Zvyrazneenej.SetActive(false);
	}
}
