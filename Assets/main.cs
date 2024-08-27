using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainController : MonoBehaviour
{
	public GameObject loadAni;
    public GameObject errSaund;
    public GameObject errBlu;
    public GameObject errBlak;
    public GameObject errWhite;
    public GameObject HaHaHaHa;
    public GameObject BUBUBUBU;

	void Start()
	{    
		Cursor.visible = false;
        float loadAniS =	0f;
        float loadaniende = 14.2f;
        float errTime =		14.2f+0.808f;
	    float BSOD =        /*errTime; Závažnost Kód Popis Projekt Soubor Øádek   Stav potlaèení Chyba CS0236  Inicializátor pole nemùže odkazovat na nestatické pole, metodu nebo vlastnost MainController.errTime.Assembly-CSharp D:\jako takový nìco\VOŠ\2\Lrrrrrrrr\Pjù\pyèo junyty\2! AAAAA\AAAAAAAA\Assets\main.cs    16	Aktivní*/42f;
	    float blak;//		666f;
        float XD =			999f;
    	float bubu;// =		aaaff
		BSOD = errTime + .91f*2.1f;
		blak = BSOD + 1.23f;
		XD = blak + 2.016f;
        VideoPlayer videoPlayer = HaHaHaHa.GetComponent<VideoPlayer>();
        bubu = XD + (float)videoPlayer.length + .8f;
        videoPlayer = BUBUBUBU.GetComponent<VideoPlayer>();
        float menu = bubu + (float)videoPlayer.length + .4f;
        Invoke("Bu", bubu);
        Invoke("ActivateAnimation", loadAniS);
        Invoke("AniPryc", loadaniende);
        Invoke("ActivateSound", errTime);
		Invoke("ActivateImage", BSOD);
        Invoke("Cerny", blak);
        Invoke("ActivateVideo", XD);
        Invoke("HaBliknutiFix", XD+.2f);
        Invoke("MenuSvist", menu);        
    }
    /*
    void OnVideoPrepared_NacteniMetadat(VideoPlayer vp){
        bubu = XD + (float)vp.length;
        Invoke("Bu", bubu);
    }*/

    void ActivateAnimation()
	{
		if (loadAni != null)
		{
			loadAni.SetActive(true);
		}
	}

	void AniPryc(){
        loadAni.SetActive(false);}

	void ActivateSound()
	{
        errWhite.SetActive(true);
      //loadAni.SetActive(false);
    }

	void ActivateImage()
	{
		if (errBlu != null)
		{
            errBlu.SetActive(true);
		}
	}

    void Cerny(){
        errBlak.SetActive(true);}

	void ActivateVideo()
	{
		HaHaHaHa.SetActive(true);
	  //errBlu.SetActive(false);
      //errBlak.SetActive(false);
      //errWhite.SetActive(false);
    }

    void HaBliknutiFix(){
        errBlak.SetActive(false);}

	void Bu(){Debug.Log("42ef962e1e0460506829b04b090ae3fa2cb5b5bad51f5ecf38977c0e9f198ebe5081eb14c8ab5bc8df6ec34062d668f8137e65ada224c2c4f3f9959f478777f9");
        HaHaHaHa.SetActive(false);
        BUBUBUBU.SetActive(true);}

    void MenuSvist(){
        SceneManager.LoadScene("Menu");}
}
