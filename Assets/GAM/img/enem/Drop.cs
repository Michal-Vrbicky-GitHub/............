using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Drop/*na talíø, nebudu vysávat každej den 3x*/ : MonoBehaviour
{	public byte kat;
	public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject amror1;
	public GameObject amror2;
	public GameObject health1;
	public GameObject health2;
	public GameObject XP1;
	public GameObject XP2;
	public GameObject G;
	public GameObject P;
	public GameObject T;
	GameObject[] gameobjekty;

	// Awake is initialization before Start, called when the script is loaded.
	// Start is called once after Awake.
	// Update is called once per frame.
	// FixedUpdate is called at a fixed interval.
	// LateUpdate is called after all Update functions.
	// OnDestroy is called when the object is destroyed.
	// OnEnable is called when the object becomes enabled.
	// OnDisable is called when the object becomes disabled.
	// OnCollisionEnter is called when the object first collides with another object.
	// OnCollisionStay is called every frame while the object is colliding.
	// OnCollisionExit is called when the object stops colliding with another object.
	// OnTriggerEnter is called when the object enters a trigger collider.
	// OnTriggerStay is called every frame while the object is within a trigger collider.
	// OnTriggerExit is called when the object exits a trigger collider.
	// OnApplicationQuit is called when the application is about to quit.
	// Reset is called to reset variables to their default values in the editor.
	// OnValidate is called when values are changed in the editor.

	private void Awake()
	{//3/6/11
		gameobjekty = new GameObject[]{XP1, ammo1, health1, amror1, G, ammo2, T, ammo3, amror2, health2, XP2, P};
	}

	void OnDestroy()
	{   //Destroy(gameObject); intelikód šikula

		// Zkontroluj, zda se aplikace chystá opustit Plej Mód nebo je f Editoru
		#if UNITY_EDITOR
        if (!EditorApplication.isPlayingOrWillChangePlaymode)//if (!Application.isPlaying && Application.isEditor)//!Application.isPlaying || Application.isEditor && !Application.isPlayingOrWillChangePlaymode)
		{
			// Pokud ano, nic nedìlej
			return;
		}
		#endif//CS1040 Direktivy preprocesoru musí být uvedené jako první neprázdné znaky na øádku.
		 //xd gpt mluvi ako ja
		 //!vfdcdcdcdcdcdcdcdcdcdcdcdcdcdc
		 //?edfecfdcedcefvevedcvfdvfvefvefv
		 //.edv
		 //Xføýsèdriztvuglhj jùùùùùùùùùùùù																							       g        f				         g                 v       
		 //Better Comments VS2022
		int n = Random.Range(0, kat);
		GameObject D = Instantiate(gameobjekty[n], transform.position, Quaternion.identity);
		D.SetActive(true);
	}
}
/*
 * Some objects were not cleaned up when closing the scene. (Did you spawn new GameObjects from OnDestroy?)
 * The following scene GameObjects were found:
 * xp(Clone)
 * hp(Clone)
 * amokrabièka(Clone)
 * xp(Clone)
 */