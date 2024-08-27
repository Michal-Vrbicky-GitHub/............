using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.Video;

public class Vp : MonoBehaviour{
	//publVideoPlayer videoPlayer;
	Camera mainCamera;
	public Aktor aaaaa;

	void Start()
	{
		GetComponent<VideoPlayer>().loopPointReached += OnVideoEnd;
		mainCamera = Camera.main;
		AdjustSizeToCamera();
	}

	void OnVideoEnd(VideoPlayer vp)
	{
		Time.timeScale = 1f;
		gameObject.SetActive(false);
		aaaaa.mrkev = false;
	}
	/*
	private void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();
	}*/
	void AdjustSizeToCamera(){
		float cameraHeight = mainCamera.orthographicSize * 2f;
		float cameraWidth = cameraHeight * mainCamera.aspect;
		transform.localScale = new Vector3(cameraWidth, cameraHeight, 1f);
	}
	void FollowCamera(){
		//transform.position = mainCamera.transform.position;
		Vector3 poz = mainCamera.transform.position;
		poz.z = 0f; // Nastavení Z == kam –> neni vidìt
		transform.position = poz;
	}
	void Update(){
		FollowCamera();
	}
}
