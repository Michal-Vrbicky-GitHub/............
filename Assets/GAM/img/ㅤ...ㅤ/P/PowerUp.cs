using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public GameObject[] pwruptxt;// intelicode xd: public GameObject[] pwruptyt;
    public string pwrName;
    bool šlápnuto = false;
	//public Význam_pojmu_behaviorální_je_týkající_se_chování_Můžeme_jím_označit_například_vědy_behaviorální_vědy_jsou_ty_které_se_věnují_studiu_lidského_chování_ve_společnosti_psychologie_sociologie_antropologie_Známe_také_behaviorální_terapii_jež_vychází_z_psychologických_teorií_učení_především_podmiňování wearám;

	// Start is called before the first frame update
	void Start()
    {
		UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public GameObject txtNaMape;

	void OnTriggerEnter2D(Collider2D obj){bool nope = false; if (!GetComponent<PowerUp>().enabled) {return;}
		Aktor plr = obj.GetComponent<Aktor>();///*
//        if (plr =/*!*/= null) { return; }Závažnost	Kód	Popis	Projekt	Soubor	Řádek	Stav potlačení
//		Chyba CS1525  Neplatný výraz = Assembly - CSharp D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\ㅤ...ㅤ\P\PowerUp.cs 23  Aktivní
//*/if (plr =/*!*/= null) { return; }
		if (plr == null  ||  šlápnuto) { return; }
        šlápnuto = true;//šlápnuto |= plr.enabled;
		PlayerMovement plrMvmnt = obj.GetComponent<PlayerMovement>();
		string[] txt = new string[2];
		(string, int)[] powerupy /****/ = new (string, int)[] {};
        //if (pwrName == null || p { //ta dy ta ky
            /*(string, int)[] */powerupy = new(string, int)[] {
                ("paci", 1),
			    ("XP", 1),
                ("10hp", 8),
                ("52hp", 7),
				("120mph", 4),
				("242HP", 2),
				("-22064,9625Nm/s", 2),
				("90armor", 6),
				("armor300", 3),
				("oheň", 1),
				("trap", 1),
				("mele", 2),
				("pist", 3),
				("brokovnice", 2),
				("kulomet", 1),
				("rockuete", 1),
				("GND", 1),
				("Oozegun", 1),
				("ohňoházeč", 1),
				("Plazma", 1),
				("AAAAAAAAgun", 1),
				("ammo", 8),
				("moreammo", 5),
				("dykmoreammo", 3),
				("municak", 1),
				("DASH! a AAAAAAAAAAAAA, Saviour of the Universe", 3),
				("dash flash", 1),
				("nic", 2),
				("camdamage", 7),

			};
		int[] munice_max = { 7!, 999, 9999, 9999999, 99, 99, 99, 999999, 999999, 101 };
		//}
	   while/*(pwrName == null) {*/(txt[0] == null) { // když pwrName neni ve switci zasekne unity editor a musí bejt vypnut takmagorem AAAAAAAA
			if(pwrName == null  || pwrName == ""  ) { // jka ej žoným, že se něgdy dá na null a někdy na ""??????????????????????????????????????????⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇⁇❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓❓AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaaa
			List<string> osudi = new List<string>();
			foreach (var powerup in powerupy)
			{	for (int i = 0; i < powerup.Item2; i++)
					osudi.Add(powerup.Item1);}
			pwrName = osudi[UnityEngine.Random.Range(0, osudi.Count)];}//()																																															                                                     https://suno.com/song/7b1ad2be-c296-4251-a750-eb94676fa9a9
			switch(pwrName){
				case "paci":
					if(plr.ruce >= 4)
						pwrName = null;
					else{plr.ruce++;
						txt[0] = pwrName;
						txt[1] = "další ručička";
						byte[] zb = plr.vybraneZbrane;
						plr.vybraneZbrane = new byte[plr.ruce];
						for (int i = 0; i < plr.ruce-1; i++)
							plr.vybraneZbrane[i] = zb[i];
						plr.vybraneZbrane[plr.ruce-1] = 255;
					}
					break;
				case "XP":
					txt[0] = pwrName;
					txt[1] = "xp no";
					plr.EXP += 21;//84;
					break;
				default: pwrName = null; break;                                                                                                                                                                                                                                                                                                      /////////////https://suno.com/song/b1f62f1e-c607-4686-b183-2a8669f741a7, https://suno.com/song/02004281-a753-436a-a987-580de3ca8c61
				case "pist":/*
					if (plr.zbraně[1][0] >= 4)
						pwrName = null;
					else { 
						txt[0] = "pistol";
						txt[1] = "je to pistole";
						plr.zbraně[1][0]++;
						plr.zbraně[1][1]+=20;
						plr.prepocitat_kontrolke = true;//wearám.prepocitat_kontrolke=true;
					}*/
					txt = Zbran(plr, 1, "pistol", "je to pistole", 21, 4);
					break;
				case "mele":
					txt = Zbran(plr, 0, "motorová pila", "moc se hodí", 0, 2);
					break;
				case "brokovnice":
					txt = Zbran(plr, 2, "bROKOVNICE", "fajn věc", 32, 4);
					break;
				case "kulomet":
					txt = Zbran(plr, 3, "Rotační kulomet", "rotuje\na při tom mete kule", 300, 4);
					break;
				case "rockuete":
					txt = Zbran(plr, 4, "Raketomet", "běžně používán k metání raket", 5, 4);
					break;
				case "GND":
					txt = Zbran(plr, 5, "granátomet", "tak nevim,\njestli metu granát, nebo minu,\nwhatever.\n\"This one is, shall we say,\nmore explosive – Serious Sam\"\n", 6, 4);
					break;
				case "Oozegun":
					txt = Zbran(plr, 6, "Oozegun", "\"Well\nthis certainly is a strange weapon.\"\r\n―Sam Stone\"", 8, 4);
					break;
				case "ohňoházeč":
					txt = Zbran(plr, 7, "Plamenomet", "Nezaměnitelné s hasicím přístrojem.", 100, 4);
					break;
				case "Plazma":
					txt = Zbran(plr, 8, "Plazma rifle", "kdysi se plazma používalo\npro skupenství a plasma pro krev,"+/*\n*/"ale lidi to psali blbě, tak\nje to teď blbě i ve slovníku...", 90, 4);
					break;
				case "AAAAAAAAgun":
					txt = Zbran(plr, 9, "AAAAAAAAgun", "https://www.youtube.com/watch?v=MD7-Le_Y6vM", 2, 1);
					break;
				case "Ooze":
					plr.zbraně[6][1]++;
					txt[0] = "něco";
					nope = Pickup(pwrName);
					break;
				case "XXXPPPAAA":
					plr.EXP++;
					txt[0] = "tohle je docela blbej způsob";
					nope = Pickup("Expýryjens");
					break;
				case "hýl":/*//odpadky
					if (!(plr.zivot < 963)) { ////AAAAAAAAAAA
						pwrName = null;//br
						break;//sdb
					}//8*/if (!(plr.zivot < 963)){
						Destroy(gameObject);
						txt[0] = "☠";
						nope = true;
						break;
					}
					plr.zivot+=33;
					txt[0] = "ale fachčí to";
					nope = Pickup("33hp");
					break;
				case "HEAL":
					if(plr.zivot>=899){
						Destroy(gameObject);
						txt[0] = "☠";
						nope = true;
						break;
					}
					plr.zivot += 101;
					txt[0] = "tak se do teho nebudu vrtat už";
					nope = Pickup("Da lékárna");
					break;
				case "arm":
					if (plr.brenni >= 967){
						Destroy(gameObject);
						txt[0] = "☠";
						nope = true;
						break;
					}
					plr.brenni += 33;
					txt[0] = "or leg?";
					nope = Pickup("Jou got the ármor buxus, kongratulatijóns");
					break;
				case "brambor":
					if (plr.brenni >= 800){
						Destroy(gameObject);
						txt[0] = "☠";
						nope = true;
						break;
					}
					plr.brenni += 200;
					txt[0] = "AAAAAAAAA";
					nope = Pickup("dycky to svědí, dyš se nemůžeš podrbat");
					break;
				case "https://www.bing.com/images/create?q=ikona do hry na powerup znázorňující munici":
					txt[0] = Ejmou(plr, new int[]{0, 7, 4, 7}, munice_max);//txt[0] = Ejmou(plr, new int[]{0, 42, 42, 42}, munice_max);
					nope = Pickup("trochu munice");
					break;
				case "https://suno.com/song/e0ce1a69-6cd0-4079-81b8-17818abdfcbc":
					txt[0] = Ejmou(plr, new int[] { 0, 14, 16, 18, 1, 2, 0, 21, 19 }, munice_max);//txt[0] = Ejmou(plr, new int[] { 0, 50, 64, 555, 1, 3, 0, 666, 420 }, munice_max);
					nope = Pickup("pikap nacpanej municí");
					break;
				case "Příkaz switch obsahuje víc případů s hodnotou návěstí \"\".":
					txt[0] = Ejmou(plr, new int[] { 0, 20, 18, 30, 3, 4, 5, 66, 50, 3 }, munice_max);//txt[0] = Ejmou(plr, new int[] { 0, 75, 77, 3999, 13, 18, 5, 1234, 2002, 8 }, munice_max);
					nope = Pickup("Muničák");
					break;
				case "dash flash":
					//PlayerMovement plrMvmnt = plr.gameObject.GetComponent<PlayerMovement>().dshFlsh = true; e cs0136 Místní proměnná nebo parametr s názvem plrMvmnt se nedá deklarovat v tomto oboru, protože se tento název používá v uzavírajícím místním oboru pro definování místní proměnné nebo parametru.
					if (plrMvmnt.dshFlsh) { 
						pwrName = null;
					break;
					}
					plrMvmnt.dshFlsh = true;
					txt[0] = "Flash Dash";
					txt[1] = "při dashování hodíš garnáta";
					break;
				case "DASH! a AAAAAAAAAAAAA, Saviour of the Universe":
					if (plrMvmnt.dashValue > 9) { 
						pwrName = null;
					break;
					}
					plrMvmnt.dashValue++;
					txt[0] = "Dash++";
					txt[1] = "větčy dešova kapacyta ne";
					break;
				case "nic":
					txt[0] = "nic";
					txt[1] = "jedno exkluzivní nic,\npořád o poznání lepší, než něco blbýho";
					break;
				case "ammo":
					txt[0] = "trochu munice";
					txt[1] = "trocha munice ještě nikoho nezabila......";
					Ejmou(plr, new int[] { 0, 8, 8, 13, 0, 0, 0, 2, 1, 0 }, munice_max);//Ejmou(plr, new int[] { 0, 20, 20, 42, 1, 1, 0, 20, 20, 0 }, munice_max);
					break;
				case "moreammo":
					txt[0] = "munice";
					txt[1] = "Je to o trochu víc než trochu..";
					Ejmou(plr, new int[] { 0, 21, 18, 55, 1, 1, 0, 50, 40, 0 }, munice_max);//Ejmou(plr, new int[] { 0, 50, 50, 200, 5, 5, 1, 60, 40, 0 }, munice_max);
					break;
				case "dykmoreammo":
					txt[0] = "AMMO";
					txt[1] = "Among ammunition, unemployment is high,\nsince getting fired is just part of the job.";
					Ejmou(plr, new int[] { 0, 28, 22, 66, 2, 3, 1, 69, 63, 1 }, munice_max);//Ejmou(plr, new int[] { 0, 100, 111, 666, 10, 13, 5, 120, 90, 1 }, munice_max);
					break;
				case "municak":
					txt[0] = "víc munice";
					txt[1] = "může se hodit,\nzejména pro střelbu";
					Ejmou(plr, new int[] { 0, 32, 28, 88, 5, 6, 7, 99, 77, 5 }, munice_max);//Ejmou(plr, new int[] { 0, 555, 666, 11111, 50, 64, 16, 10101, 9999, 8 }, munice_max);
					break;
				case "10hp":
					if (plr.zivot >= 990)
						pwrName = null;
					else { 
						plr.zivot += 10;
						txt[0] = "hýl";
						txt[1] = "Pyrrhula pyrrhula, +10hp";
					}
					break;
				case "52hp":
					if (plr.zivot >= 948)
						pwrName = null;
					else { 
						plr.zivot += 52;
						txt[0] = "Erste-Hilfe-Kasten";
						txt[1] = "je to kastle,\nkterá se použije pro hilfe a to první\n+52HP";
					}
					break;
					case "120mph":
					if (plr.zivot >= 880)
						pwrName = null;
					else { 
						plr.zivot += 120;
						txt[0] = "120HP";
						txt[1] = "Co k tomu říct?\nJe to heal pickup nó, +120HP.";
					}
					break;
					case "242HP":
					if (plr.zivot >= 758)
						pwrName = null;
					else { 
						plr.zivot += 242;
						txt[0] = "x^3−15x^2+8x+269";
						txt[1] = "taky způsob, jak sdělit 242";
					}
					break;
				case "-22064,9625Nm/s":
					if (plr.zivot <= 42)
						pwrName = null;
					else
					{
						plr.zivot -= 30;
						txt[0] = "hit";
						txt[1] = "-30hp\nHAHAHAHAHAHA";
					}
					break;
				case "90armor":
					if (plr.brenni >= 910)
						pwrName = null;
					else{
						plr.brenni += 90;
						txt[0] = "Armor";
						txt[1] = "+90arm";
					}
					break;
				case "armor300":
					if (plr.brenni >= 700)
						pwrName = null;
					else
					{
						plr.brenni += 300;
						txt[0] = "brnění";
						txt[1] = "asi tak 16kg kevlaru, ký plechy a volovo\n+300ARMOR";
					}
					break;
				case "camdamage":
					CameraShake cam = GameObject.Find("Mejn Kamera").GetComponent<CameraShake>();
					if (cam.up >= 4)
						pwrName = null;
					else
					{
						cam.up ++;
						txt[0] = "kamera pawrap";
						txt[1] = "kamera se míň třese";
						Camera.main.GetComponent<CameraFollow>().smoothSpeed*=2;
					}
					break;
				case "WIN":
					txt[0] = "AAAAAAAAA";
					if(SceneManager.GetActiveScene().name == "T")
						SceneManager.LoadScene("TTT");
					else if(SceneManager.GetActiveScene().name == "T 800")
						SceneManager.LoadScene("Wwq");
					else pwrName = txt[0] = null;
					break;
			}
		}
	    if(!nope)
		StartCoroutine(DisplayPowerUpText(txt));
	}

	IEnumerator DisplayPowerUpText(string[] txt)
	{
		Transform bum = transform.Find("WS2k-1");
		bum.gameObject.SetActive(true);
		GameObject zvuk = transform.Find("PowerUp").gameObject;
		zvuk.SetActive(true);
		transform.Find("M-1").gameObject.SetActive(false);

		GameObject txtObj1 = Instantiate(pwruptxt[0], pwruptxt[0].transform.position, pwruptxt[1].transform.rotation, pwruptxt[1].transform.parent);
		GameObject txtObj2 = Instantiate(pwruptxt[1], pwruptxt[1].transform.position, pwruptxt[0].transform.rotation, pwruptxt[0].transform.parent);
		txtObj1.GetComponent<TextMeshProUGUI>().text = txt[0];
		txtObj2.GetComponent<TextMeshProUGUI>().text = txt[1];
		txtObj1.SetActive(true);
		txtObj2.SetActive(true);

		//Time.timeScale = 0.2f; seberu-li víc, blbne
		float duration = 4.2f;
		float elapsed = 0f;
		//Vector3 startPos1 = txtObj1.transform.position;
		//Vector3 startPos2 = txtObj2.transform.position;
		RectTransform txtObj1RektTransform = txtObj1.GetComponent<RectTransform>();
		RectTransform txtObj2RektTransform = txtObj2.GetComponent<RectTransform>();
		Vector2 startPos1 = txtObj1RektTransform.anchoredPosition;
		Vector2 startPos2 = txtObj2RektTransform.anchoredPosition;
		//Vector3 endPos1 = startPos1 + Vector3.right * 99f;
		//Vector3 endPos2 = startPos2 + Vector3.left  * 99f;
		Vector2 endPos1 = startPos1 + Vector2.right * 99f;
		Vector2 endPos2 = startPos2 + Vector2.left  * 99f;

		while (elapsed < duration){
			Time.timeScale = 0.2f;//teď ne
			elapsed += Time.unscaledDeltaTime;
			float t = elapsed/duration;
			//txtObj1.transform.position = Vector3.Lerp(startPos1, endPos1, t);
			//txtObj2.transform.position = Vector3.Lerp(startPos2, endPos2, t);
			//txtObj2.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos1, endPos1, t);
			txtObj1RektTransform.anchoredPosition = Vector3.Lerp(startPos1, endPos1, t);
			txtObj2RektTransform.anchoredPosition = Vector3.Lerp(startPos2, endPos2, t);
			yield return null;
		}

		Time.timeScale = 1f;
		Destroy(txtObj1);
		Destroy(txtObj2);
		//Destroy(transform);	Can't destroy Transform component of 'RRRRrrrr'. If you want to destroy the game object, please call 'Destroy' on the game object instead. Destroying the transform component is not allowed.
		Destroy(gameObject);
	}

	string[] Zbran(Aktor pla, int poradi, string nadpis, string popis, int munice, int max){
		string[] nadpo = new string[2];
		if (pla.zbraně[poradi][0] >= max)
			pwrName = null;
		else
		{
			nadpo[0] = nadpis;
			nadpo[1] = popis ;
			pla.zbraně[poradi][0]++;
			pla.zbraně[poradi][1] += (uint)munice;
			pla.prepocitat_kontrolke = true;
		}
		return nadpo;
	}

	//string Pikap(Aktor ply, )
	//{
	//	ply.zbraně[6][1] += 1;
	//}

	bool Pickup(string napis)
	{
		GameObject txtNaMape = Instantiate(this.txtNaMape);//GameObject txtNaMape = Instantiate(this.txtNaMape, transform.position, Quaternion.identity);
		txtNaMape.transform.SetParent(this.txtNaMape.transform.parent);
		Vector3 position=transform.position;position.z=0;txtNaMape.GetComponent<RectTransform>().position = position;//txtNaMape.GetComponent<RectTransform>().position = transform.position;
        //rectTransform.position = transform.position;//Závažnost	Kód	Popis	Projekt	Soubor	Řádek	Stav potlačení _ Chyba	CS0131	Levou stranou přiřazení musí být proměnná, vlastnost nebo indexer.	Assembly-CSharp	D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\ㅤ...ㅤ\P\PowerUp.cs	219	Aktivní
		txtNaMape.GetComponent<TextMeshProUGUI>().text = napis;// "napis";
		foreach (Transform child in transform)
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		StartCoroutine(MoveAndFadeText(txtNaMape.GetComponent<TextMeshProUGUI>()));
		return true;
	}/*	bool Pickup(string napis)
	{
		GameObject txtNaMapeInstance = Instantiate(this.txtNaMape);
		txtNaMapeInstance.SetActive(true);
		txtNaMapeInstance.transform.SetParent(this.txtNaMape.transform.parent, false);
		txtNaMapeInstance.GetComponent<RectTransform>().position = transform.position;

		txtNaMapeInstance.GetComponent<Text>().text = napis;

		// Zkusit bez coroutine
		//StartCoroutine(MoveAndFadeText(txtNaMapeInstance.GetComponent<Text>()));

		return true;
	}*/

	IEnumerator MoveAndFadeText(TextMeshProUGUI text)//TextMeshPro je fuj, TextMeshProUGUI je yeý
	{	Debug.Log("z");
		float duration = 2.22f;
		float elapsedTime = 0f;
		Color initialColor = text.color;
		Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);
		Vector3 initialPosition = text.transform.position;
		Vector3 targetPosition = initialPosition + new Vector3(0, 1.96f, 0);
		while (elapsedTime < duration){
			elapsedTime += Time.deltaTime;
			float t = elapsedTime / duration;
			text.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
			text.color = Color.Lerp(initialColor, targetColor, t);
			yield return null;
		}
		Debug.Log("k");
		Destroy(text.gameObject);
		Destroy(gameObject);
		//yield return hull;
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		OnTriggerEnter2D(collision);
	}

	string Ejmou(Aktor P, int[] mu, int[] ma)
	{
		for (int i = 1; i < mu.Length; i++)
		{
			if (P.zbraně[i][1]+mu[i] < ma[i])
				P.zbraně[i][1]+= (uint)mu[i];
		}
		return "null";
	}
}
