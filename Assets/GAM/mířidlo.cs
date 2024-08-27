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

        //tyDva = GetComponentsInChildren<GameObject>();chèildrenofthenextlevel
        tyDva = new GameObject[2];//fmmm#1
        tyDva[0] = transform.GetChild(0).gameObject;
        tyDva[1] = transform.GetChild(1).gameObject;
        if (tyDva.Length != 2)   //fmmm#2
            Debug.LogError("AAAAAAAAAAAA!!!! COŽE??");
    }

	void Update(){
        Vector2 cursorPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorTransform.position = worldPos + offset;
		if (tyDva.Length >= 2){/*Závažnost	Kód	Popis	Projekt	Soubor	Øádek	Stav potlaèení Chyba	CS1061	GameObject neobsahuje definici pro enabled a nenašla se žádná dostupná metoda rozšíøení enabled, která by pøijímala první argument typu GameObject. (Nechybí direktiva using nebo odkaz na sestavení?)	Assembly-CSharp	D:\jako takový nìco\VOŠ\2\Lrrrrrrrr\Pjù\pyèo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\míøidlo.cs	24	Aktivní
			tyDva[0].enabled =  dam1nebo2;
			tyDva[1].enabled = !dam1nebo2;*/
			tyDva[0].SetActive( dam1nebo2);
			tyDva[1].SetActive(!dam1nebo2);
		}
    }	}
