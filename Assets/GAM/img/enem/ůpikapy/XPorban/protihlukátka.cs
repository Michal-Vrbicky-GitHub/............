/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protihlukátka : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public int maxAudioSources = 55;  // Maximální počet zvukových kanálů
	public int stopOldestCount = 22;  // Počet zvuků, které se zastaví při překročení limitu

	private List<AudioSourceWithTimestamp> activeAudioSources = new List<AudioSourceWithTimestamp>();

	void Update()
	{
		// Každý frame zkontroluje všechny aktivní AudioSource ve scéně
		CheckAndStopOldestSources();
	}

	private void CheckAndStopOldestSources()
	{
		// Najdi všechny AudioSource ve scéně a zkontroluj, které hrají
		activeAudioSources.Clear();
		AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

		foreach (AudioSource source in allAudioSources)
		{
			if (source.isPlaying)
			{
				// Přidáme AudioSource spolu s časem, kdy začal přehrávat zvuk
				activeAudioSources.Add(new AudioSourceWithTimestamp(source, source.time));
			}
		}

		// Pokud je dosažen limit, zastav nejstarší zvuky
		if (activeAudioSources.Count > maxAudioSources)
		{
			StopOldestSources();
		}
	}

	private void StopOldestSources()
	{
		// Seřadí seznam podle času spuštění
		activeAudioSources.Sort((a, b) => a.startTime.CompareTo(b.startTime));

		// Zastaví nejstarší zvuky podle nastaveného počtu
		int excessSources = activeAudioSources.Count - maxAudioSources;

		for (int i = 0; i < Mathf.Min(stopOldestCount, excessSources); i++)
		{
			AudioSource oldestSource = activeAudioSources[i].audioSource;
			oldestSource.Stop();
			// Nezničíš AudioSource ani jeho GameObject, pouze ho zastavíš
		}
	}

	// Třída, která kombinuje AudioSource s časem spuštění
	private class AudioSourceWithTimestamp
	{
		public AudioSource audioSource;
		public float startTime;

		public AudioSourceWithTimestamp(AudioSource source, float time)
		{
			audioSource = source;
			startTime = time;
		}
	}
}
