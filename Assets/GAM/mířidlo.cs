using UnityEngine;
using UnityEngine.UI;

public class M : MonoBehaviour{
	private Transform cursorTransform;
    public Vector2 offset;
    public bool dam1nebo2;
	GameObject[] tyDva;

	void Start(){
		cursorTransform = GetComponent<Transform>();
		/*//*/Cursor.visible = false;

        //tyDva = GetComponentsInChildren<GameObject>();ch�ildrenofthenextlevel
        tyDva = new GameObject[2];//fmmm#1
        tyDva[0] = transform.GetChild(0).gameObject;
        tyDva[1] = transform.GetChild(1).gameObject;
        if (tyDva.Length != 2)   //fmmm#2
            Debug.LogError("AAAAAAAAAAAA!!!! CO�E??");
    }

	void Update(){
        Vector2 cursorPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorTransform.position = worldPos + offset;
		if (tyDva.Length >= 2){/*Z�va�nost	K�d	Popis	Projekt	Soubor	��dek	Stav potla�en� Chyba	CS1061	GameObject neobsahuje definici pro enabled a nena�la se ��dn� dostupn� metoda roz���en� enabled, kter� by p�ij�mala prvn� argument typu GameObject. (Nechyb� direktiva using nebo odkaz na sestaven�?)	Assembly-CSharp	D:\jako takov� n�co\VO�\2\Lrrrrrrrr\Pj�\py�o junyty\2! AAAAA\AAAAAAAA\Assets\GAM\m��idlo.cs	24	Aktivn�
			tyDva[0].enabled =  dam1nebo2;
			tyDva[1].enabled = !dam1nebo2;*/
			tyDva[0].SetActive( dam1nebo2);
			tyDva[1].SetActive(!dam1nebo2);
		}
    }	}
