using UnityEngine;
//using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
	private void OnMouseDown()
	{
        Debug.Log("Application quitting application...");//dbc
        Application.Quit();
    }
}
