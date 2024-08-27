using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.U2D;
using System.Collections.Generic;

public class Význam_pojmu_behaviorální_je_týkající_se_chování_Můžeme_jím_označit_například_vědy_behaviorální_vědy_jsou_ty_které_se_věnují_studiu_lidského_chování_ve_společnosti_psychologie_sociologie_antropologie_Známe_také_behaviorální_terapii_jež_vychází_z_psychologických_teorií_učení_především_podmiňování : MonoBehaviour
{

	public float mezera = 10f;//-8.08

    private RectTransform[] images; // Pole pro uložení obrázků


    public TextMeshProUGUI livesText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI handsText;//Text je ee
    public Aktor player;
    public GameObject Armor_Games;
		   GameObject[] armorImagey;
	float  startX;//Y=-442.3

    private Image[] dešsirkles;
    public PlayerMovement plrmvmt;
    public Sprite circleSprite; 
    private Color grayColor = new Color(88 / 255f, 88 / 255f, 88 / 255f);
    private Color whiteColor = new Color(1f, 1f, 1f);

    GameObject[] munice;
    byte jedna = 0;

    GameObject/*Image*/[] paci;//ukazatel držené zbraně
    public Sprite RRRRRRrrrrrrrrrrrr;

    public GameObject TextMusíBejtKlonZRučněVytvořenýhoJinakDěláBlbostiPřiŠkálování;
    public GameObject svetylko;
	//public bool prepocitat_kontrolke = false;
	List<GameObject> svetylkaList = new List<GameObject>();
    GameObject[] neni = new GameObject[10];
    public Sprite prazdnyZasobnik;
	GameObject[] guns = new GameObject[10];

    bool prepocitavaniKontrolek;

	void Start()
    {

        // Získání původního obrázku
        RectTransform originalRect = GetComponent<RectTransform>();
        Vector2 originalSize = originalRect.sizeDelta;
        RectTransform canvasRect = transform.parent.GetComponent<RectTransform>();

        float totalWidth = originalSize.x * 10 + mezera * 9;
        float canvasWidth = canvasRect.rect.width;
        float y = originalRect.anchoredPosition.y; //transform.position.y;
        this.startX = (canvasWidth - totalWidth) / 2;//+originalRect.anchoredPosition.x)/2;//protože souřadnice udávaj střed AAAAAAAAAAA, dá se nastavit

        images = new RectTransform[10];
        images[0] = originalRect;
        originalRect.anchoredPosition = new Vector2(this.startX, y);
        //y = 0; startX = 0;
        for (int i = 1; i <= 9; i++) {
            GameObject newImage = Instantiate(gameObject, transform.parent); //GameObject newImage = Instantiate(gameObject, transform);
            RectTransform newRect = newImage.GetComponent<RectTransform>();
            newRect.sizeDelta = originalSize;

            float posX = this.startX + i * (originalSize.x + mezera);
            newRect.anchoredPosition = new Vector2(posX, y);
            images[i] = newRect;
            Destroy(newRect.GetComponent<Význam_pojmu_behaviorální_je_týkající_se_chování_Můžeme_jím_označit_například_vědy_behaviorální_vědy_jsou_ty_které_se_věnují_studiu_lidského_chování_ve_společnosti_psychologie_sociologie_antropologie_Známe_také_behaviorální_terapii_jež_vychází_z_psychologických_teorií_učení_především_podmiňování>());
        }
        int childCount = Armor_Games.transform.childCount;//cndsfdt
        armorImagey = new GameObject[childCount];
        for (int i = 0; i < childCount; i++) {
            armorImagey[i] = Armor_Games.transform.GetChild(i).gameObject;
            armorImagey[i].SetActive(false);
        }
        AktualizaceDashŠipek();
        munice = new GameObject[10];
    }

    void AktualizaceDashŠipek() { //8max
        GameObject[] allObjects = FindObjectsOfType<GameObject>();//A§§
        foreach (GameObject obje in allObjects)
           if (obje.name.Contains("DashCircle"))
                Destroy(obje);
        //,
        float vzdalenostOdKrajePravy =  42f;
    	float vzdalenostOdKrajeSpodni = -8f;
		float velikostKruhu = 111f;
        float startX = transform.parent.GetComponent<RectTransform>().rect.width - vzdalenostOdKrajePravy - velikostKruhu / 2;
        float startY = vzdalenostOdKrajeSpodni + velikostKruhu / 2;

        dešsirkles = new Image[plrmvmt.dashValue];
        /*
        for (int i = 0; i < plrmvmt.dashValue; i++)
        {
            GameObject circleObj = new GameObject("DashCircle" + i, typeof(Image));
            circleObj.transform.SetParent(transform);
            Image circleImage = circleObj.GetComponent<Image>();

            // Vytvoření kruhového tvaru pomocí Image
            circleImage.type = Image.Type.Simple;
            circleImage.color = Color.red;

            // Nastavení pozice a velikosti kruhu
            RectTransform rectTransform = circleObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(velikostKruhu, velikostKruhu);
            rectTransform.anchorMin = new Vector2(1, 0);
            rectTransform.anchorMax = new Vector2(1, 0);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = new Vector2(-vzdalenostOdKrajePravy, startY + i * (velikostKruhu + mezera));

            dešsirkles[i] = circleImage;

            // Přidání komponenty Mask
            Mask mask = circleObj.AddComponent<Mask>();
            mask.showMaskGraphic = false;

            // Vytvoření kruhového objektu pro maskování
            GameObject maskCircle = new GameObject("MaskCircle", typeof(Image));
            maskCircle.transform.SetParent(circleObj.transform);
            Image maskImage = maskCircle.GetComponent<Image>();
            maskImage.sprite = null;
            maskImage.color = Color.black;

            // Nastavení velikosti a pozice masky
            RectTransform maskRectTransform = maskCircle.GetComponent<RectTransform>();
            maskRectTransform.sizeDelta = rectTransform.sizeDelta;
            maskRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            maskRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            maskRectTransform.pivot = new Vector2(0.5f, 0.5f);
            maskRectTransform.anchoredPosition = Vector2.zero;
        }*/
        for (int i = 0; i < plrmvmt.dashValue; i++)
        {
            GameObject circleObj = new GameObject("DashCircle" + i, typeof(Image));
            circleObj.transform.SetParent(transform.parent);
            Image circleImage = circleObj.GetComponent<Image>();

            // Nastavení sprite pro kruh
            circleImage.sprite = circleSprite;

            // Nastavení pozice a velikosti kruhu
            RectTransform rectTransform = circleObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(velikostKruhu, velikostKruhu);
            rectTransform.anchorMin = new Vector2(1, 0);
            rectTransform.anchorMax = new Vector2(1, 0);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = new Vector2(-vzdalenostOdKrajePravy+.3f, startY + i * (velikostKruhu/1.8f + mezera));
            circleObj.transform.localScale = new Vector3(-1, -1, -1);
            dešsirkles[i] = circleImage;
        }
    }

    void Update(){ /*
    {		string Z = player.zivot.ToString();
			string zivotes = Z[0] + Z[1].ToString() + Z[2];
			string setoviz = "";
			bool č = false;
			foreach(char cislice in zivotes.Reverse()) { 
				if (cislice == '0'  &&  zivotes.Contains(',')  &&  !č   ||   cislice == ','  &&  setoviz.Length == 0)
					continue;/*
				else if (cislice == ',')*//*
					č = true;
				//else
				setoviz += cislice;
			}livesText.text = new string(setoviz.Reverse().ToArray());*/
            //livesText.text = /*'\n'+*/player.zivot > 0 ? player.zivot.ToString("F1") : ""/*+'\n'*/+ "";//     //
            armorText.text = Mathf.Round(player.brenni)+"";														//es
            handsText.text = player.ruce.ToString();
			int index = int.MinValue;
            switch(player.brn){
			case 'A':
				index = 3;
			break;
			case 'E':
				index = 2;
			break;
			case 'I':
				index = 1;
			break;
			case 'Ó':
				index = 0;
			break;
			default: Debug.Log("?????aleužitady"); break;
		    }
            for (int i = 0; i < armorImagey.Length; i++)
                    armorImagey[i].SetActive(i == index);
        string Zz = player.zivot.ToString();
		string zZ = "";
		bool[] č0 = new bool[2];
		int m = 3;
		if (Zz.Length-1 < m)
			m = Zz.Length-1;
        if(Zz.Split(',')[0].Length > m)
            č0[0] = true;
        for (int i = m; i >= 0; i--){
			if (Zz.Contains(',') && Zz[i]=='0' && !č0[0])
				continue;
			else if (zZ.Length==0/*i==m*/ && Zz[i]==','){
				č0[0] = true;
				continue;
				}
			else if (Zz[i]==',')
                č0[0] = true;
			zZ += Zz[i];
        }
        livesText.text = new string(zZ.Reverse().ToArray());


        if(dešsirkles.Length != plrmvmt.dashValue) AktualizaceDashŠipek();

        int dashesMissing = plrmvmt.dashValue - plrmvmt.currentDash;/*
        for (int i = dešsirkles.Length-1; i >= 0; i--)
        {
            if (i < dashesMissing)
            {
                dešsirkles[i].color = grayColor;
            }
            else
            {
                dešsirkles[i].color = whiteColor;
            }
		}*/int ite = dešsirkles.Length-1;
		foreach(Image šipka in dešsirkles)
		{
            if (dashesMissing > ite) šipka.color = grayColor;
            else šipka.color = whiteColor;
			ite--;
        }


        // Kontrola player.zbraně a aktualizace obrázků a textů
        for (int i = jedna; i < player.zbraně.GetLength(0); i++)
        {
            if (player.zbraně[i][0] != 0 )/////nejde dát zásobník s kytkou nad zbraň
            {
                if (munice[i] == null &&  player.zbraně[i][1] != 0)
                {
                    // Vytvoření obrázku zbraně
                    GameObject weaponImage = new GameObject("WeaponImage" + i, typeof(Image));
                    weaponImage.transform.SetParent(images[i]);
                    Image weaponImageComponent = weaponImage.GetComponent<Image>();
                    //weaponImageComponent.sprite = /* Vaše sprite z assetů */ null; // Nahraďte null odpovídajícím sprite
                    //weaponImageComponent.sprite = Resources.Load<Sprite>("GAM\\img\\projektil\\zbraně\\pistol\\pistole__malá_textura_do_hry__jednoduchý_pozadí__revolver_s_gripem_a_optickým_zaměřovačem_327cfa96-a40c-40ba-a966-74311b6e95bd-removebg-preview.png");
                    //LoadAndAssignSprite(images[i].GetComponent<Image>(), imagePath);
                    weaponImageComponent.sprite = Resources.Load<Sprite>("guns/"+i);//guns/0.png
                    //weaponImage.transform.SetSiblingIndex(images[i].GetSiblingIndex() - 1);
                    //weaponImage.transform.SetSiblingIndex(0);

                    RectTransform weaponRectTransform = weaponImage.GetComponent<RectTransform>();
                    /*//*/weaponRectTransform.sizeDelta = new Vector2(25, 25); // Nastavení velikosti obrázku
                    //weaponRectTransform.anchoredPosition = Vector2.zero;
                    weaponRectTransform.anchoredPosition = new Vector2(-0.888f, 0);
                    switch (i){
                        case 0:
                            weaponRectTransform.localScale = new Vector3(1.3f, 1.3f, 808f);
                            break;
                        case 1:
                            weaponRectTransform.localScale = new Vector3(1.91f, 1.91f, 808f);
                            break;
						case 2:
							weaponRectTransform.localScale = new Vector3(1.42f, 1.42f, 808f);
							break;
						case 3:
							weaponRectTransform.localScale = new Vector3(1.75f, 0.8350878f, 808f);
							break;
						case 4:
							weaponRectTransform.localScale = new Vector3(1.6f, 1.6f, 808f);
							break;
						case 5:
							weaponRectTransform.localScale = new Vector3(1.3f, 1.3f, 808f);
							break;
						case 6:
							weaponRectTransform.localScale = new Vector3(1.3f, 1.3f, 808f);
							break;
						case 7:
							weaponRectTransform.localScale = new Vector3(1.3f, 1.3f, 808f);
							break;
						case 8:
							weaponRectTransform.localScale = new Vector3(1.5f, 1.5f, 808f);
							break;
						case 9:
							weaponRectTransform.localScale = new Vector3(1.3333f, 1.3333f, 808f);
							break;
					}
					guns[i] = weaponImage;
	 //               /*
	 //               // Vytvoření textu munice
	 //               GameObject ammoTextObject = Insa//new GameObject("AmmoText" + i, typeof(TextMeshProUGUI));
	 //               ammoTextObject.transform.SetParent(images[i]);
	 //               TextMeshProUGUI ammoTextComponent = ammoTextObject.GetComponent<TextMeshProUGUI>();
	 //               ammoTextComponent.text = "NEW GUN!"; //ammoTextComponent.text = "Ammo: " + player.zbraně[i][0];
	 //               ammoTextComponent.color = Color.gray;
	 //               ammoTextComponent.outlineColor = Color.black;
	 //               ammoTextComponent.outlineWidth = 42f;
	 //               ammoTextComponent.alignment = TextAlignmentOptions.Right;
	 //               ammoTextComponent/*.municeText*/.fontSize = 7.5f;
	 //               ammoTextComponent.fontStyle = FontStyles.Bold;
	 //               //Material textMaterial = new Material(Shader.Find("LiberationSans SDF - Metalic Green"));
	 //               //Material textMaterial = new Material(Shader.Find("TextMeshPro/Distance Field"));
	 //               //textMaterial.color = Color.green; // Změň na požadovanou barvu
	 //               //ammoTextComponent.fontSharedMaterial = textMaterial; // Použití sdíleného materiálu

					//               RectTransform ammoRectTransform = ammoTextObject.GetComponent<RectTransform>();
					//               ammoRectTransform.sizeDelta = new Vector2(25, 16); /*// Nastavení velikosti textového pole
					//ammoRectTransform.anchorMin = new Vector2(0, 0.5f);
					//ammoRectTransform.anchorMax = new Vector2(0, 0.5f);
					//ammoRectTransform.pivot = new Vector2(0, 0.5f);*/
					//ammoRectTransform.anchoredPosition = new Vector2(0, 34); // P

					//               // Uložení reference na vytvořený objekt do pole munice
					//               munice[i] = ammoTextObject;*/
					GameObject ammoTextObject = Instantiate(TextMusíBejtKlonZRučněVytvořenýhoJinakDěláBlbostiPřiŠkálování, images[i].transform/*weaponImage.transform*/);
                    //ammoTextObject.transform.localPosition = new Vector3(-4.8F, 17.5F/*4.8F*/, 0F);//(-24F, 12.5F, 0F);// Vector3.zero;
                    //ammoTextObject.transform.localScale = new Vector3(.18F, .18F, .42F); //(.38F, .38F, .42F);//Vector3.one;
					ammoTextObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.0f, 33.3F);
					ammoTextObject.transform.localScale = new Vector3(.25F, .25F, .42F);


					TextMeshProUGUI ammoText = ammoTextObject.GetComponent<TextMeshProUGUI>();
					ammoText.fontSize = 7.5F;
					ammoText.enableAutoSizing = true;
					ammoText.alignment = TextAlignmentOptions.BottomRight;
					ammoText.color = new Color(232/255f, 136/255f, 8f/255f);//ammoText.color = Color.gray;
					ammoText.fontStyle = FontStyles.Bold;
					//RectTransform ammoRectTransform = ammoTextObject.GetComponent<RectTransform>();
					//ammoRectTransform.localScale.x = 
					//ammoRectTransform.pivot = new Vector2(0, nahoru);

					munice[i] = ammoTextObject;
					if (i == 0){
                        Destroy(ammoTextObject);
                        jedna = 1;
                    }
                }
                else if (player.zbraně[i][1] == 0  &&  neni[i] == null)
                {
					//Destroy(munice[i]);
					//munice[i] = null;
                    GameObject prazdnyZasobnik = new GameObject("PrazdnyZasobnik" + i, typeof(Image));//= new GameObject("PrazdnyZasobnik");
					//prazdnyZasobnik.AddComponent<RectTransform>();
					//SpriteRenderer renderer = prazdnyZasobnik.AddComponent<SpriteRenderer>();
                    Image renderer = prazdnyZasobnik.GetComponent<Image>();
					renderer.sprite = this.prazdnyZasobnik;
					//renderer.sortingOrder = 999;
					//prazdnyZasobnik.transform.SetAsLastSibling();

					// Zmenšení objektu
					//prazdnyZasobnik.transform.localScale = new Vector3(1.8f, 1.8f, 8f);
					//prazdnyZasobnik.transform.localScale = new Vector3(0.29f, 0.3864377f, 8f);
					//prazdnyZasobnik.transform.anchore
					// Přidání prázdného zásobníku na pozici ve wearámu
					prazdnyZasobnik.transform.SetParent(images[i].transform);

					// Nastavení pozice zásobníku (pokud je potřeba)
					//prazdnyZasobnik.transform.localPosition = new Vector3(0, 0, 0); // Případně změňte souřadnice
                    prazdnyZasobnik.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0, 0);
					prazdnyZasobnik.GetComponent<RectTransform>().localScale = new Vector3(0.27f, 0.36f, 8f);//AAAAAAAAAAA, teď je zaas moc fpředu, nýýý
					prazdnyZasobnik.transform.SetAsFirstSibling();
					// Přidání prázdného zásobníku do pole munice na index i
					neni[i] = prazdnyZasobnik;
					//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//	//
					Destroy(munice[i]);
					munice[i] = null;
					Destroy(guns[i]);
					guns[i] = null;
					player.prepocitat_kontrolke = true;
				}
				else if (munice[i] != null)
                {/*
                    // Aktualizace textu munice
                    string d = "";
                    for (int l = 0; l < player.zbraně[i][0]; l++)
                        d+= "•";//'🔴';*/
					TextMeshProUGUI existingAmmoTextComponent = munice[i].GetComponent<TextMeshProUGUI>();
                    existingAmmoTextComponent.text = player.zbraně[i][1].ToString();//+"\n"+d;//+player.zbraně[i][0].ToString()+"ㅤ ";//existingAmmoTextComponent.text = "Ammo: " + player.zbraně[i, 0];Závažnost	Kód	Popis	Projekt	Soubor	Řádek	Stav potlačení Chyba	CS0022	Špatné číslo indexu uvnitř []; očekává se 1.	Assembly-CSharp	D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\ㅤ...ㅤ\ui oi\ramy dashe zivoty.cs	255	Aktivní
                    /*
						Microsoft Visual Studio
						ramy dashe zivoty.cs
						Některé znaky Unicode v tomto souboru nelze v aktuální znakové stránce uložit. Chcete pro
						zachování vašich dat uložit tento soubor znovu pomocí znakové sady Unicode?
						použít na všechny dokumenty
						Uložit s -in 'm kódováním
						Zrušit
					 */}}
                    if (player.prepocitat_kontrolke & i==1  |  prepocitavaniKontrolek){
                        if(i==9)
                            player.prepocitat_kontrolke = prepocitavaniKontrolek = false;
						if(i==1){
							foreach (GameObject s in svetylkaList)
                                Destroy(s);
                            svetylkaList.Clear();
					        prepocitavaniKontrolek = true;

						}
                        if(player.zbraně[i][1]!=0 && player.zbraně[i][0]!=0)
						    for (int j = 0; j < player.zbraně[i][0]-1; j++){
							    GameObject kontrolka = Instantiate(svetylko, images[i]);
                                kontrolka.transform.SetParent(images[i]);/*
							    kontrolka.transform.localPosition = new Vector3(-0F + j * 2, 3F, 0F);
							    kontrolka.transform.position = new Vector3(-0F + j * 2, 3F, 0F);*/
							    kontrolka.GetComponent<RectTransform>().anchoredPosition = new Vector2(-13F +13*j, 13.8F+.3f);
							    kontrolka.transform.localScale = new Vector3(1F, 1F, 1F);
							    svetylkaList.Add(kontrolka);
						    }
					}
                    if(neni[i]!=null && player.zbraně[i][1]!=0){
                        Destroy(neni[i]);
                        neni[i] = null;
                    }
                //}
          ///*//*/}
            //else if (munice[i] != null)
            //{
            //    // Smazání obrázku a textu, pokud již není munice
            //    Destroy(munice[i]);
            //    munice[i] = null;
            //}
        }

        if (player.změna){
            player.změna = false;
            if (paci != null)
                foreach (GameObject/*Image*/ r in paci)
                    Destroy(r);
            paci = new GameObject/*Image*/[player.vybraneZbrane.Length];
            for(int í = 0; í < player.vybraneZbrane.Length; í++){
                byte N = player.vybraneZbrane[í];
                if (N == 255) { return; }
                int  n = 0;
                for (int i = í-1; i >= 0; i--)//{ ručky vedle sebe, nikoliv na sebe prosím
                    if (player.vybraneZbrane[i] == N)
                        n++;
                GameObject R = new GameObject("pracicka", typeof(Image));
                R.transform.SetParent(images[N]);
                R.GetComponent<RectTransform>().anchoredPosition = new Vector2(-12.1f + n*8, -11.3f);//(-13f + n*8, -13);
                R.GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
                R.GetComponent<RectTransform>().localScale = new Vector3(1.23f, 1.5252f/*1.24f*/, 42);
                R.GetComponent<Image>().sprite = RRRRRRrrrrrrrrrrrr;
                paci[í] = R;
            }
        }
    }
}

//                   \\//__           _             __  _                   _        \\//                   _                                            _      _ 
// _ __   ___  _   _ _\//_/_   ____ _| |_  __   ___/_/_| |__  _ __ __ _  __| |_ __    \/    __ _ _ __   ___| |__   ___  _ __ ___  _   _   _ __   ___ ___(_) ___(_)
//| '_ \ / _ \| | | |_  / \ \ / / _` | __| \ \ / / | | | '_ \| '__/ _` |/ _` | '_ \ / _ \  / _` | '_ \ / __| '_ \ / _ \| '__/ _ \| | | | | '_ \ / _ \_  / |/ __| |
//| |_) | (_) | |_| |/ /| |\ V / (_| | |_   \ V /| |_| | | | | | | (_| | (_| | | | |  __/ | (_| | | | | (__| | | | (_) | | | (_) | |_| | | |_) | (_) / /| | (__| |
//| .__/ \___/ \__,_/___|_| \_/ \__,_|\__|   \_/  \__, |_| |_|_|  \__,_|\__,_|_| |_|\___|  \__,_|_| |_|\___|_| |_|\___/|_|  \___/ \__,_| | .__/ \___/___|_|\___|_|
//|_|                                             |___/                                                                                  |_|                      
//https://suno.com/song/dfce47b8-ffad-460b-8f18-22cec746167c											https://suno.com/song/8fc177d4-fff2-44fb-b6a7-1f1131754ba8

/*                                                                              *                                                                                */