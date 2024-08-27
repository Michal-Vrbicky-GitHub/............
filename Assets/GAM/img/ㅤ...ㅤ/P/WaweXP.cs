using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
//using UnityEditor.Presets; Assets\GAM\img\ㅤ...ㅤ\P\WaweXP.cs(6,19): error CS0234: The type or namespace name 'Presets' does not exist in the namespace 'UnityEditor' (are you missing an assembly reference?)
//Cannot build player while editor is importing assets or
//compiling scripts.
using UnityEngine;
using UnityEngine.SceneManagement;

public class W : MonoBehaviour
{
	(int, (string, GameObject)[])[] waves;//private (int, List<SpawnObject>)[] waves;   //public List<(int, List<SpawnObject>)> waves;
	int wáwe, Nmr, lvl = 0;
	public GameObject tele;
	//public int EXP = 0;
	public GameObject hrac;
	public GameObject susteni;
	private TextMeshProUGUI waveText;
	private RectTransform waveBar;
	private TextMeshProUGUI bodyText;
	private RectTransform bodyBar;
	/*public */float EXPnaLVL = 16;//42;


	public GameObject txt;
	public GameObject Powerup;
	public GameObject Powerdown;
	public GameObject paci;
	public GameObject XP;
	public GameObject B1;
	public GameObject B2;
	public GameObject mina;
	public GameObject krabice;
	public GameObject pistole;
	public GameObject SG;
	public GameObject MG;
	public GameObject R;
	public GameObject G;
	public GameObject O;
	public GameObject plam;
	public GameObject plaz;
	public GameObject PL;
	public GameObject mun;
	public GameObject ice;
	public GameObject H;
	public GameObject heal;
	public GameObject B;

	public GameObject igelitka;
	public GameObject hadice;
	public GameObject krokos;
	public GameObject slunecnice;
	public GameObject hraskomet;
	public GameObject AAAAAAAA;
	public GameObject motorku;
	public GameObject tank;
	public GameObject alien;
	public GameObject ancient;
	public GameObject buffbaf;


	// Start is called before the first frame update
	void Start()
	{/*
		List<SpawnObject> list1 = new List<SpawnObject>			
		{
			new SpawnObject("0,0,0", "EnemyType1"),
			new SpawnObject("1,0,0", "EnemyType2")
		};

		List<SpawnObject> list2 = new List<SpawnObject>
		{
			new SpawnObject("2,0,0", "EnemyType3"),
			new SpawnObject("3,0,0", "EnemyType4")
		};

        List<SpawnObject> vlna3 = new List<SpawnObject>
        {
            new SpawnObject("2,0,0", "EnemyType3"),
            new SpawnObject("3,0,0", "EnemyType4")
        };
		int V3 = 42;

        waves = new (int, List<SpawnObject>)[]
        {
			(8 , list1),
			(2 , list2),
			(V3, vlna3)
		};*/

		// Příklad spouštění vln
		//StartCoroutine(SpawnWaves());


		waveText = GameObject.Find("wawe").GetComponent<TextMeshProUGUI>();//Závažnost	Kód	Popis	Projekt	Soubor	Řádek	Stav potlačení Chyba CS0246  Typ nebo název oboru názvů Text se nenašel. (Nechybí direktiva using nebo odkaz na sestavení?)	Assembly - CSharp D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\ㅤ...ㅤ\P\WaweXP.cs  52  Aktivní
		waveBar = GameObject.Find("Vlna").GetComponent<RectTransform>();
		bodyText = GameObject.Find("xp, velkej bordel, dyš stejný názvy").GetComponent<TextMeshProUGUI>();
		bodyBar = GameObject.Find("LVL").GetComponent<RectTransform>();
		switch (SceneManager.GetActiveScene().name){
			case "T":
				waves = new (int, (string, GameObject)[])[]
				{/*
					(3, new (string, GameObject)[] {("kolem", Powerup),
													("kolem", Powerup),
													("kolem", Powerup)}),
					(6, new (string, GameObject)[] {("okraj", Powerup)})*/
					(123, new (string, GameObject)[] {("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("kolem", hraskomet),
													  ("random", tank), ("random", tank)})
				};
				break;
			case "T 800":
				waves = new (int, (string, GameObject)[])[]{
					(5, new (string, GameObject)[] {//1
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("kolem",  pistole),
						("kolem",  mun),
						("kolem",  SG),
						("kolem",  mun),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", hadice),
						("random", hadice),
						("random", hadice)
					}),
					(15, new (string, GameObject)[] {//2
						("okraj",  ice),
						("okraj",  H),
						("okraj",  ice),
						("okraj",  H),
						("okraj",  B),
						("random", pistole),
						("kolem",  krokos),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", mina),
						("random", mina),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hraskomet),
						("random", igelitka),
						("kolem",  krokos),
						("random", XP),
					}),
					(36, new (string, GameObject)[] {//3
						("okraj",  ice),
						("okraj",  heal),
						("okraj",  heal),
						("okraj",  ice),
						("okraj",  B),
						("okraj",  B),
						("okraj",  pistole),
						("okraj",  krokos),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("kolem",  krabice),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", krokos),
						("random", XP),
					}),
					(28, new (string, GameObject)[] {//4
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", hraskomet),
						("random", hraskomet),
						("random", mina),
						("okraj",  ice),
						("okraj",  mun),
						("okraj",  hadice),
						("okraj",  Powerup),
						("okraj",  SG),
						("okraj",  heal),
						("okraj",  B),
						("okraj",  pistole),
						("okraj",  hadice),
						("random", XP),
					}),
					(90, new (string, GameObject)[] {//5
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B1),//complex
						("kolem",  igelitka),
						("kolem",  krokos),
						("kolem",  igelitka),
						("kolem",  krokos),
						("kolem",  igelitka),
						("okraj",  SG),
						("okraj",  krabice),
						("okraj",  krabice),
						("okraj",  krabice),
						("okraj",  krabice),
						("okraj",  krabice),
						("okraj",  SG),
						("okraj",  krabice),
						("okraj",  krabice),
						("random", hadice),
						("okraj",  heal),
						("okraj",  H),
						("random", krokos),
						("random", krokos),
					}),
					(42, new (string, GameObject)[] {//6
						("kolem",  MG),
						("kolem",  mun),
						("kolem",  ice),
						("kolem",  paci),
						("kolem",  ice),
						("kolem",  mun),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", krabice),
						("random", B2),
						("random", B2),
						("okraj",  B),
						("okraj",  H),
						("okraj",  B),
						("okraj",  H),
						("random", XP),
					}),
					(77, new (string, GameObject)[] {//7
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
					}),
					(16, new (string, GameObject)[] {//8
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", XP),
					}),
					(36, new (string, GameObject)[] {//8
						("kolem",  AAAAAAAA),
						("kolem",  hraskomet),
						("kolem",  AAAAAAAA),
						("kolem",  hraskomet),
						("kolem",  AAAAAAAA),
						("kolem",  hraskomet),
						("okraj",  AAAAAAAA),
						("random", MG),
						("random", MG),
						("random", R),
						("random", G),
						("random", B),
						("random", H),
						("random", H),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", XP),
					}),
					(42, new (string, GameObject)[] {//9
						("kolem",  buffbaf),
						("random", slunecnice),
						("random", slunecnice),
						("random", slunecnice),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
					}),
					(42, new (string, GameObject)[] {//10
						("kolem",  MG),
						("kolem",  H),
						("kolem",  plaz),
						("kolem",  H),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", paci),
						("random", plaz),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", igelitka),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", slunecnice),
						("random", XP),
					}),
					(42, new (string, GameObject)[] {//11
						("kolem",  buffbaf),
						("kolem",  buffbaf),
						("kolem",  B),
						("kolem",  H),
						("random", plam),
						("random", plaz),
						("random", R),
						("random", G),
						("random", paci),
						("random", tank),
						("random", igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("random", hraskomet),
						("random", hraskomet),
						("random", krokos),
						("random", XP),
					}),
					(88, new (string, GameObject)[] {//12
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
					}),
					(8, new (string, GameObject)[] {//13
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
					}),
					(8, new (string, GameObject)[] {//14
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
					}),
					(8, new (string, GameObject)[] {//15
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						//("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
					}),
					(36, new (string, GameObject)[] {//16
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  heal),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", slunecnice),
						("random", slunecnice),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", hraskomet),
						("random", Powerup),
						("random", Powerup),
						("random", Powerup),
					}),
					(13, new (string, GameObject)[] {//17
						("kolem",  tank),
						("kolem",  tank),
						("kolem",  tank),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
					}),
					(52, new (string, GameObject)[] {//18
						("kolem",  AAAAAAAA),
						("kolem",  plaz),
						("kolem",  AAAAAAAA),
						("kolem",  plam),
						("kolem",  AAAAAAAA),
						("kolem",  O),
						("random", buffbaf),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
					}),
					(21, new (string, GameObject)[] {//19
						("kolem",  H),("kolem",  H),("kolem",  H),
						("okraj",  tank),("okraj",  tank),("okraj",  tank),
						("random", slunecnice),("random", slunecnice),("random", slunecnice),
					}),
					(123, new (string, GameObject)[] {//20
						("kolem",  H),
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  H),
						("kolem",  B),
						("kolem",  heal),
						("kolem",  B),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("okraj",  igelitka),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
					}),
					(33, new (string, GameObject)[] {//21
						("kolem",  H),
						("kolem",  heal),
						("kolem",  heal),
						("kolem",  B),
						("kolem",  B),
						("kolem",  H),
						("random", krabice),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("random", krokos),
						("okraj",  R),
						("okraj",  G),
						("okraj",  O),
						("okraj",  plam),
						("okraj",  plaz),
						("okraj",  paci),
						("okraj",  XP),
					}),
					(42, new (string, GameObject)[] {//22
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("okraj",  hraskomet),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B1),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						//Bcomplex
					}),
					(33, new (string, GameObject)[] {//23
						("random", buffbaf),
						("random", buffbaf),
						("random", igelitka),
						("random", igelitka),
						("random", krokos),
						("random", krokos),
						("random", hadice),
						("random", hadice),
					}),
					(42, new (string, GameObject)[] {//24
						("random", alien),
					}),
					(16, new (string, GameObject)[] {//25
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
					}),
					(100, new (string, GameObject)[] {//26
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("random", krabice),
						("okraj",  tank),
						("okraj",  tank),
						("okraj",  tank),
					}),
					(100, new (string, GameObject)[] {//27
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", buffbaf),
						("random", Powerup),
						("random", Powerup),
						("random", Powerup),
						("random", Powerup),
						("okraj",  heal),
						("okraj",  H),
						("okraj",  B),
						("okraj",  heal),
						("okraj",  H),
						("okraj",  B),
						("okraj",  heal),
						("okraj",  H),
						("okraj",  B),
						("okraj",  heal),
						("okraj",  H),
						("okraj",  B),
						("okraj",  heal),
						("okraj",  H),
						("okraj",  B),
					}),
					(101, new (string, GameObject)[] {//28
						("kolem",  slunecnice),
						("kolem",  slunecnice),
						("kolem",  slunecnice),
						("kolem",  slunecnice),
						("kolem",  slunecnice),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
					}),
					(55, new (string, GameObject)[] {//29
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("kolem",  mina),
						("kolem",  mina),
						("kolem",  mina),
						("kolem",  mina),
						("kolem",  mina),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
						("okraj",  AAAAAAAA),
					}),
					(20, new (string, GameObject)[] {//30
						//barels o' fun
						("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),("random", B1),
					}),
					(20, new (string, GameObject)[] {//31
						("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),("random", B2),
					}),
					(20, new (string, GameObject)[] {//32
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("okraj",  hadice),
						("random", heal),
						("random", heal),
						("random", heal),
						("random", heal),
						("random", heal),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", H),
					}),
					(242, new (string, GameObject)[] {//33
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
					}),
					(50, new (string, GameObject)[] {//34
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
					}),
					(71, new (string, GameObject)[] {//35
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
						("kolem",  alien),
					}),
					(99, new (string, GameObject)[] {//36
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
					}),
					(66, new (string, GameObject)[] {//37
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", B2),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("random", mina),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("okraj",  Powerup),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
						("kolem",  krokos),
					}),
					(36, new (string, GameObject)[] {//38
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", buffbaf),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", alien),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
						("random", AAAAAAAA),
					}),
					(101, new (string, GameObject)[] {//39
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("kolem",  B2),
						("random", B1),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", B),
						("random", H),
						("random", H),
						("random", H),
						("random", H),
						("random", heal),
						("random", heal),
						("random", PL),
						("random", O),
						("random", Powerup),
						("random", Powerup),
						("okraj",  Powerup),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  ice),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  ice),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  ice),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  mun),
						("okraj",  ice),
					}),
					(10, new (string, GameObject)[] {//40
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  hraskomet),
						("kolem",  slunecnice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("random", hadice),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
						("okraj",  krokos),
						("okraj",  igelitka),
					}),
					(69, new (string, GameObject)[] {//41
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("random", tank),
						("kolem",  R),
						("kolem",  G),
						("kolem",  O),
						("kolem",  AAAAAAAA),
						("okraj",  B),
						("okraj",  B),
						("okraj",  B),
						("okraj",  B),
						("okraj",  B),
						("okraj",  B),
						("okraj",  B),
					}),//*/
					(222, new (string, GameObject)[] {//!42
						("random", ancient),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("okraj",  alien),
						("kolem",  Powerup),
						("kolem",  mun),
						("kolem",  Powerup),
						("kolem",  ice),
						("kolem",  Powerup),
						("kolem",  B),
					}),
				};
				break;
			case "2":
				waves = new (int, (string, GameObject)[])[]
				{(1, new (string, GameObject)[] {
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
				}),
				(10, new (string, GameObject)[] {
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
				}),
				(20, new (string, GameObject)[] {
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
					("random", Powerup),
				}),
				};
				break;
		}
		StartCoroutine(SpawnWaves());
	}

	// Update is called once per frame
	void Update()
	{/*
		// Kontrola, aby EXP nepřekročilo max hodnotu
		EXP = Mathf.Clamp(EXP, 0, maxEXP);*/
		int XP = hrac.GetComponent<Aktor>().EXP;
		float t = XP/EXPnaLVL;
		bodyText.text = $"Body: {XP}/{EXPnaLVL}";
		float newLength = t * 800;
		bodyBar.sizeDelta = new Vector2(newLength, bodyBar.sizeDelta.y);
		Color newColor = Color.Lerp(Color.yellow, Color.red, t);
		bodyBar.GetComponent<UnityEngine.UI.Image>().color = newColor;
		//TODO když levlup, zvuk a spawn
		// TODO: Implement this function?
		//? 
		// ! 

		if (XP >= EXPnaLVL)
		{
			hrac.GetComponent<Aktor>().EXP -= (int)EXPnaLVL;
			SpawnKolem(new List<GameObject>{Powerup,Powerup,Powerup}, hrac.transform.position, 4.2f, hrac.GetComponent<PlayerMovement>().boundaryObject.transform.position, hrac.GetComponent<PlayerMovement>().boundaryObject.transform.localScale);
			//transform.FindChild("wawe").GetComponent<TextMeshProUGUI>();
			GameObject.Find("YEÝ").GetComponent<AudioSource>().Play();
		}
	}

	private IEnumerator SpawnWaves()
	{
		/*
		foreach (var wave in waves)
		{
			int waveNumber = wave.Item1;
			List<SpawnObject> spawnObjects = wave.Item2;

			Debug.Log("Spawning wave " + waveNumber);

			foreach (var spawnObject in spawnObjects)
			{
				// Zde naspawnujte objekty na základě pozice a typu
				// Instantiate(prefab, spawnObject.Position, Quaternion.identity);
				Debug.Log("Spawning " + spawnObject.ItemType + " at " + spawnObject.Position);
			}

			// Čekání mezi vlnami (přizpůsobte dle potřeby)
			yield return new WaitForSeconds(5f);
		}*//*yield return new WaitForSeconds(wavesy[wawujNmr][0]);
		StartCoroutine(SpawnWaves());*//*
		foreach (var wave in waves)
		{
			Nmr = wave.Item1;//delay
			var coKamSeznam = wave.Item2;
			yield return new WaitForSeconds(Nmr);
	    	Spawn(coKamSeznam);
		}*/
		foreach (var wave in waves){
			wáwe++;
			waveText.text = "Wave: " + wáwe;

			float timer = wave.Item1;
			float initialWidth = waveBar.sizeDelta.x;

			while (timer > 0){
				yield return null; // wait for the next frame
				timer -= Time.deltaTime;
				float newHeight = (timer / wave.Item1) * initialWidth;
				waveBar.sizeDelta = new Vector2(newHeight, waveBar.sizeDelta.y);
				float t = 1 - (timer / wave.Item1);
				Color newColor = Color.Lerp(Color.green, Color.blue, t);
				waveBar.GetComponent<UnityEngine.UI.Image>().color = newColor;
			}
			waveBar.sizeDelta = new Vector2(initialWidth, waveBar.sizeDelta.y);
			waveBar.GetComponent<UnityEngine.UI.Image>().color = Color.green;
			Spawn(wave.Item2);
		}
	}

	void Spawn ((string, GameObject)[] veciKeSpawnuti) {
			//Debug.LogWarning(SpawnWaves().ToString());
		List<GameObject> kolem = new List<GameObject>();
		List<GameObject> okraj = new List<GameObject>();
		List<GameObject> random= new List<GameObject>();
		List<GameObject> prsne = new List<GameObject>();
		foreach (var item in veciKeSpawnuti)
		{
			switch (item.Item1)
			{
				case "kolem":
					kolem.Add(item.Item2);
					break;
				case "okraj":
					okraj.Add(item.Item2);
					break;
				case "random":
				   random.Add(item.Item2);
					break;
				default:
					prsne.Add(item.Item2);
					break;
			}
		}
		Vector3 hracPosition = hrac.transform.position;
		//Bounds bounds = hrac.GetComponent<PlayerMovement>().boundaryObject.GetComponent<Collider>().bounds;
		Vector3 boundaryCenter = hrac.GetComponent<PlayerMovement>().boundaryObject.transform.position;
		Vector3 boundarySize = hrac.GetComponent<PlayerMovement>().boundaryObject.transform.localScale;
		SpawnKolem(kolem, hracPosition, 4.2f, boundaryCenter, boundarySize);
		SpawnOkraj(okraj, boundaryCenter, boundarySize, -.42f);
		SpawnRandom(random, boundaryCenter, boundarySize);
	}

	IEnumerator/*void*/ SpawnSusteni(GameObject objekt, Vector3 Posise, int poradí){
		GameObject s = Instantiate(susteni, Posise, Quaternion.identity);
		s.GetComponent<AniKill>().spawn = objekt;
		yield return new WaitForSeconds(poradí*.042f);
		s.SetActive(true);
	}

	void SpawnKolem(List<GameObject> objects, Vector3 center, float radius, Vector3 Bcenter, Vector3 Bsize)//V2
	{	int count = objects.Count;
		if (count == 0) return;
		float angleStep = 360f/count;
		byte rnd = (byte)UnityEngine.Random.Range(0, 256);

		for (int i = 0; i < count; i++){
			float angle = (i*angleStep +rnd)*Mathf.Deg2Rad;//i * angelaStep * Mathf.Deg2Rad;
			Vector3 spawnPosition = new Vector3(center.x + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, center.z);
			if(objects[i] != igelitka  &&  objects[i] != hadice  &&  objects[i] != krokos  &&  objects[i] != slunecnice  &&  objects[i] != hraskomet  &&  objects[i] != AAAAAAAA  &&  objects[i] != motorku  &&  objects[i] != tank  &&  objects[i] != alien  &&  objects[i] != ancient)//AAAAAAAAAAAAA if(objects[i] == Powerup)
			{
				Vector3 boundaryMin = Bcenter -Bsize/2;
				Vector3 boundaryMax = Bcenter +Bsize/2;
				///*
				if (spawnPosition.x < boundaryMin.x  ||  spawnPosition.x > boundaryMax.x  ||  
					spawnPosition.y < boundaryMin.y  ||  spawnPosition.y > boundaryMax.y)
				{
					spawnPosition.x = Mathf.Clamp(spawnPosition.x, boundaryMin.x, boundaryMax.x);
					spawnPosition.y = Mathf.Clamp(spawnPosition.y, boundaryMin.y, boundaryMax.y);
				}/***//*
				if (spawnPosition.x < boundaryMin.x)
				{
					spawnPosition.x = boundaryMin.x;
				}*/
			}
			StartCoroutine(SpawnSusteni(objects[i], spawnPosition, i));
		}
	}

	void SpawnOkraj(List<GameObject> objects, Vector3 center, Vector3 size, float innerOffset){
		int count = objects.Count;
		if (count  == 0) return;//Závažnost	Kód	Popis	Projekt	Soubor	Řádek	Stav potlačení Chyba CS0029  Typ bool nejde implicitně převést na typ int.Assembly - CSharp D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\GAM\img\ㅤ...ㅤ\P\WaweXP.cs  172 Aktivní if (cunt = objects.Count == 0) return;
		float angleStep = 360f / count;
		float radiusX = (size.x / 2) - innerOffset;
		float radiusZ = (size.y / 2) - innerOffset;
		byte rnd = (byte)UnityEngine.Random.Range(0, 256);
		for (int i = 0; i < count; i++){
			float angle = (i*angleStep +rnd)*Mathf.Deg2Rad;
			Vector3 spawnPosition = new Vector3(center.x + Mathf.Cos(angle) * radiusX, center.y + Mathf.Sin(angle) * radiusZ, center.z);
			StartCoroutine(SpawnSusteni(objects[i], spawnPosition, i));/*
			//Instantiate(, spawnPosition, Quaternion.identity);
			GameObject s = Instantiate(susteni, spawnPosition, Quaternion.identity);//Quaternions are used to represent rotations.
			s.GetComponent<AniKill>().spawn = objects[i];
			s.SetActive(true);*/
		}
	}

	void SpawnRandom(List<GameObject> objects, Vector3 center, Vector3 size)
	{	foreach (var obj in objects)
		{	Vector3 randomPosition = new Vector3(
				UnityEngine.Random.Range(center.x - size.x/2, center.x + size.x/2),
				UnityEngine.Random.Range(center.y - size.y/2, center.y + size.y/2),
				center.z
			); StartCoroutine(SpawnSusteni(obj, randomPosition, UnityEngine.Random.Range(0,16)));
}	}	}


/*
public class SpawnObject
{
	//public Vector3 Position { get; private set; }
	//public string ItemType { get; /*private set; }

	public string Co { get; set; }
	public string Kam { get; set; }

	public SpawnObject(string co, string kam)//(string position, string itemType)
	{
		//Position = ParsePosition(position);
		//ItemType = itemType;
		this.Co = co;
		this.Kam = kam;
	}
	/*
	private Vector3 ParsePosition(string position)
	{
		// Předpokládáme, že pozice je zadána ve formátu "x,y,z"
		string[] values = position.Split(',');
		if (values.Length == 3)
		{
			float x = float.Parse(values[0]);
			float y = float.Parse(values[1]);
			float z = float.Parse(values[2]);
			return new Vector3(x, y, z);
		}
		else
		{
			Debug.LogError("Invalid position format");
			return Vector3.zero;
		}
	}*/
//}