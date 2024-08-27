using UnityEngine;
using System.Linq;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class /*vr*//*zá*//*kon*//*tr*/Aktor: MonoBehaviour{
	public float zivot;                       
	public float brenni;
	public uint[][] zbranì;/*arrayOfSomeArrays; 1. je poèet zbraní, 2. je munice
	* 1 – Sekere
	* 2 – pewpistolka
	* 3 – brokovnice
	* 4 – gatling
	* 5 – raketomet
	* 6 – miminomet
	* 7 – Oozegun
	* 8 – plamenomet
	* 9 – plazmoment
	* 0 – AAAAAAAAgun
	*/public byte ruce = 1;
	public char brn = 'u';/*
    public sbyte[] vybrano = new sbyte[10];
    public byte [] poradi  = new byte [1 ];*/
    public byte[] vybraneZbrane = new byte[1];
    byte posPoz = 0;
	public bool zmìna;
	public GameObject Clouseau;
	public int EXP = 0;
	public bool prepocitat_kontrolke = false;
	public GameObject vid, f, k;//jj
	public AudioSource ooo;
	public bool mrkev;
	bool ch;

	public void dmg(/*double*/ float kolik)
	{/*
		bool prokleti = false;
		if (brenni == -666)
			prokleti = !prokleti;
        if (brenni > 50){
			brenni -= kolik * .9f;
			zivot  -= kolik * .3f;
		}
		else if (brenni > 0){
			brenni -= kolik;
			zivot  -= kolik*.6f;
		}
		else if (brenni == 0)
			zivot -= kolik;
		else
			zivot -= kolik * 3;
		if (brenni < 0  &&  !prokleti)
			brenni = 0;

		// Handle the player's death
		if (zivot <= 0)
		{
			Debug.Log("Player is dead!");
		}
		*/

		if (brenni < 0)
			brenni = 0;//dyby dole, neni vidìt záporný
		switch(brn){
			case 'A':
				brenni -= kolik * .666f;
				zivot  -= kolik * .1f;
			break;
			case 'E':
				brenni -= kolik * .9f;
				zivot  -= kolik * .333f;
			break;
			case 'I':
				brenni -= kolik;
				zivot  -= kolik * .697f;
			break;
			case 'Ó':
				zivot  -= kolik;
			break;
			default: Debug.Log("????????????????????????????!!!"); break;
		}

		/*
		-0.34
Y 0.21*/for(int i = 0; i < kolik; i+=5){
			Vector3 bloodOffset = new Vector3(-0.34f, 0.21f, 0f);
			Vector3 bloodPosition = transform.position + transform.TransformDirection(bloodOffset);
			GameObject bloodSplatter = Instantiate(k, bloodPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
			bloodSplatter.SetActive(true);
		}

		if (zivot <= 0  &&  !mrkev  &&  !ch)
		{	int randomNumber = Random.Range(0, 20);// = 8;//
			if (randomNumber == 8)
			{	zivot = 100;
				Time.timeScale = 0f;
				vid.SetActive(true);
				vid.GetComponent<VideoPlayer>().Play();
			}else{
				int sceneNumber = Random.Range(1, 16);
				StartCoroutine(SwitchAAA(sceneNumber.ToString()));
			}
			ooo.Play();
			mrkev = true;
		}


		if (brenni < 0)
			brenni = 0;
	}

	void Start() {
		zbranì = new uint[10][];
		for (int i = 0; i < 10; i++)
			zbranì[i] = new uint[2];
		zbranì[0][1] = uint.MaxValue;
		zbranì[0][0] = 1;
        zbranì[1][0] = 1;
		zbranì[1][1] = 101;// 1;//01;
		vybraneZbrane[0] = 1;
		ZmenaZbrani();
        zmìna = true;
		CoByloPosledni.Instance.TodleByloPosledni(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}

	void Update()
	{
		Vector3 mousl = Input.mousePosition;
		Vector3 prepoctenyNaWrrld = Camera.main.ScreenToWorldPoint(mousl);
		prepoctenyNaWrrld.z = 0;
		Vector3 direction = prepoctenyNaWrrld - transform.position;
		float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
		transform.rotation = Quaternion.Euler(0, 0, angel);
		if (brenni > 100)
			brn = 'A';
		else if (brenni > 50)
			brn = 'E';
		else if (brenni > 0)
			brn = 'I';
		else
			brn = 'Ó';


        for (int i = 0; i < 10; i++)			
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
            {	   i--	;
				if(i==-1)
				   i = 9;
                if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))/*  &&  posPoz < vybraneZbrane.Length*/){
                    int n = 0;//AAAAAAAA crl i pro sekeruAAAAAAAAAAAA nedebugej, je to dobrý takle AAAAAAAAAAAAAAA
                    for (int j = vybraneZbrane.Length-1/*posPoz*/; j >= 0; j--)
                        if (vybraneZbrane[j] == i)
                            n++;
					int nula = 0;
					if (i==0 && zbranì[i][0]==2) nula = -1;
					if (zbranì[i][0]+nula <= n  &&  vybraneZbrane[posPoz] != i   ||   zbranì[i][0]+nula < n) return;
                    bool aaaa = false;										
					if(posPoz < vybraneZbrane.Length)// { 
                        aaaa = true; //posPoz++;
					else
                        posPoz = 0;
					vybraneZbrane[posPoz] = (byte)i;
					if (aaaa) { posPoz++; }
					if (posPoz >= vybraneZbrane.Length)
						posPoz = 0;
					//break;
				}
                else
                {/*
					foreach(byte z in vybraneZbrane)
						z = 0;*/
                    if (zbranì[i][0] == 0) return;
                    for (int j = 0; j < vybraneZbrane.Length; j++)
                        vybraneZbrane[j] = 255;
                    vybraneZbrane[0] = (byte)i;
					posPoz = 0;
					//break;
                }
				ZmenaZbrani();
				zmìna = true;
                break;
            }
        }

		//      if (Input.GetMouseButton(0))
		//      {
		//          Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);/*
		//          RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
		//          if (hit.collider != null)
		//          {
		//              // Print the name of the object clicked
		//              Debug.Log("Held on: " + hit.collider.name);
		//              // Call any method you want on the clicked object
		//              // hit.collider.gameObject.GetComponent<YourComponent>().YourMethod();
		//          }*//*
		//	RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); //LifeController
		//	if (hit.collider == null) return;
		//	LifeController lifeController = hit.collider.gameObject.GetComponent<LifeController>();
		//	if (lifeController != null)
		//		lifeController.ž -= 10;*/
		//}
		foreach (char c in Input.inputString){
			putin += c;
			if (putin.Length > cc.Length)
				putin = putin.Substring(1);
			if (putin == cc){
				putin = "";
				ch = !ch;
	}	}	}
	string putin = "";
	string cc = "krefjeyivot";

	void ZmenaZbrani(){
		Transform zbraneTransform = transform.Find("zbranì");
		foreach (Transform chcild in zbraneTransform)
			chcild.gameObject.SetActive(false);

		foreach (byte zbran in vybraneZbrane){
			Transform zbranTransform = zbraneTransform.Find(zbran.ToString());
			if (zbranTransform != null  &&  zbran != 255)
				zbranTransform.gameObject.SetActive(true);
			else
				Debug.LogAssertion("Ass ser vention: " + zbran);
		}
		if(vybraneZbrane.Any(value => value != 0 && value != 255) )
            Clouseau.GetComponent<M>().dam1nebo2 = true;
		else Clouseau.GetComponent<M>().dam1nebo2 = false;
    }

	IEnumerator SwitchAAA(string deathAnim)
	{
		f.SetActive(true);
		yield return new WaitForSeconds(4.2F);
		SceneManager.LoadScene(deathAnim);
	}

}