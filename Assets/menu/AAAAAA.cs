using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public string Sc�na;
	private void OnMouseDown()
	{
		SceneManager.LoadScene(Sc�na);
	}
}
