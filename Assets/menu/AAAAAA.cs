using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public string Scéna;
	private void OnMouseDown()
	{
		SceneManager.LoadScene(Scéna);
	}
}
