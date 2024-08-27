using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioVeci : MonoBehaviour
{
	List<AudioSource> audioSources = new List<AudioSource>();
	//bool KdyzSePrepneOknoPustiDalsi;
	//bool isPaused;
	AudioSource currentlyPlayingSource;

	void Start()
	{
		LoadAudioSources();
		//PlayNextTrack();
		StartCoroutine(PockejTrocu());
	}

	void LoadAudioSources()
	{
		audioSources.Clear();
		AudioSource[] succes = GetComponentsInChildren<AudioSource>();
		foreach (AudioSource soccer in succes)
		{
			audioSources.Add(soccer);
		}
	}

	void PlayNextTrack()
	{   //if (KdyzSePrepneOknoPustiDalsi) return;
		//if (IsAnyAudioPlaying()) return;
		//if (isPaused) return;
		if (audioSources.Count == 0)
			LoadAudioSources();
		//KdyzSePrepneOknoPustiDalsi = true;
		int randomIndex = Random.Range(0, audioSources.Count);
		AudioSource selectedSource = audioSources[randomIndex];
		currentlyPlayingSource = audioSources[randomIndex];
		selectedSource.Play();
		audioSources.RemoveAt(randomIndex);
		//StartCoroutine(WaitForTrackToEnd(selectedSource));
		StartCoroutine(WaitForTrackToEnd(currentlyPlayingSource.clip.length));
	}
	/*
	bool IsAnyAudioPlaying()
	{	foreach (AudioSource source in GetComponentsInChildren<AudioSource>())
		{	if (source.isPlaying){
				return true;
		}	}
		return false;
	}*/

	//void OnApplicationPause(bool p)
	//{
	//	isPaused = p;
	//}

	//void OnApplicationFocus(bool hasFocus)
	//{/*
	//	if (hasFocus && !isPaused)
	//	{
	//		PlayNextTrack();  // Ensure a track is playing when returning to focus
	//	}*/
	//	isPaused = hasFocus;
	//}
	/*
	IEnumerator WaitForTrackToEnd(AudioSource source)
	{
		yield return new WaitWhile(() => source.isPlaying);
		//KdyzSePrepneOknoPustiDalsi = false;
		PlayNextTrack();
	}*/

	IEnumerator WaitForTrackToEnd(float trackLength)
	{
		yield return new WaitForSeconds(trackLength);
		currentlyPlayingSource = null;
		PlayNextTrack();
	}

	IEnumerator PockejTrocu()
	{
		yield return new WaitForSeconds(3);
		PlayNextTrack();
/*}*/}

	void Update()
	{	foreach (AudioSource source in /*audioSources*/GetComponentsInChildren<AudioSource>())
		{	if (source.isPlaying && source != currentlyPlayingSource){
				source.Stop();
}	}	}	}
