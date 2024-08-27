using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEditor;


public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
	public Button resumeButton;
	public Button mainMenuButton;
	public Button quitButton;

	private bool isPaused = false;
    public GameObject menu; // The menu panel
    public float slideDuration = 0.42f; // Duration of the slide animation
    public AudioSource opénSound; // Sound to play when opening
    public AudioSource closeSound; // Sound to play when closing

    private Vector3 offScreenPosition; // Position off-screen
    private Vector3 onScreenPosition; // Position on-screen
//    private bool isMenuOpen = false;
	bool isPlaying = false;

    RectTransform uiElement;
    private Canvas canvas;
    GameObject hvezdicka;

    void Start()
    {/*
        onScreenPosition = new Vector3(0, 0, 0);;
        menu.transform.position = onScreenPosition;*/
        pauseMenuUI.SetActive(false);

		resumeButton.onClick.AddListener(Resume);
		mainMenuButton.onClick.AddListener(GoToMainMenu);
		quitButton.onClick.AddListener(QuitGame);

        //offScreenPosition = new Vector3(menu.transform.position.x, -menu.GetComponent<RectTransform>().rect.height/3.3333f, menu.transform.position.z);
        //onScreenPosition = menu.transform.position;
        //menu.transform.position = offScreenPosition;
        onScreenPosition = Vector3.zero;//421
        offScreenPosition = new Vector3(0, -menu.transform.parent.GetComponent<RectTransform>().rect.height/2 -menu.GetComponent<RectTransform>().rect.height/2, 0);

        canvas = GetComponent/*InParent*/<Canvas>();
        GameObject obj = GameObject.Find("kotóè");
        uiElement = obj.GetComponent<RectTransform>();
        obj.SetActive(false);
        hvezdicka = obj;
    }

    void Update()
	{/*
        Vector2 screenPoint = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, canvas.worldCamera, out Vector2 localPoint);
        //uiElement.localPosition = localPoint;
        uiElement.anchoredPosition = localPoint;*/
        uiElement.anchoredPosition = new Vector3(Input.mousePosition.x / canvas.scaleFactor, Input.mousePosition.y / canvas.scaleFactor, Input.mousePosition.z-1); ;
        //Debug.Log(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Escape)) { 
			if (!isPlaying) isPlaying = true;
			else return;
			if (isPaused)	Resume();
			else Pause();
            //offScreenPosition = new Vector3(menu.transform.position.x, -menu.GetComponent<RectTransform>().rect.height / 3.3333f, menu.transform.position.z);
            //onScreenPosition = menu.transform.position;
            
        }	}
    /**//*
	void Resume()
	{
        StartCoroutine(SlideMenu(offScreenPosition, closeSound));
        pauseMenuUI.SetActive(false);//potøebuju nastavit na false, až po probìhnutí slide
		Time.timeScale = 1f;
		isPaused = false;
	}

	void Pause()
	{
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
        StartCoroutine(SlideMenu(onScreenPosition, opénSound));
    }//*/

    void GoToMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu"); //
	}

	void QuitGame()
	{
		Application.Quit();
	}
    /**//*
    private IEnumerator SlideMenu(Vector3 targetPosition, AudioSource sound)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = menu.transform.position;
        sound.Play();

        while (elapsedTime < slideDuration)
        {
            menu.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ignore timeScale
            yield return null;
        }

        menu.transform.position = targetPosition;
        sound.Stop();
    }/**//**/
    void Resume()
    {
        isPaused = false;
        StartCoroutine(SlideMenu(offScreenPosition, closeSound, false));
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        hvezdicka.SetActive(true);
        pauseMenuUI.SetActive(true);
        StartCoroutine(SlideMenu(onScreenPosition, opénSound, true));
    }
    private IEnumerator SlideMenu(Vector3 targetPosition, AudioSource sound, bool pauseAfter)
    {
        float elapsedTime = 0;
        //Vector3 startingPosition = menu.transform.position;
        RectTransform menuRect = menu.GetComponent<RectTransform>();
        Vector2 startingPosition = menuRect.anchoredPosition;
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned, až na to, že je.");//AAAAAAAAAAAAAAAA i v menu etÌEEEE
        }

        while (elapsedTime < slideDuration)
        {
            menuRect.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / slideDuration); //menu.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ignore timeScale
            yield return null;
        }

        menuRect.anchoredPosition = targetPosition;//menu.transform.anchoredPosition = targetPosition;//menu.transform.position = targetPosition;
        sound.Stop();
        isPlaying = false;

        if (!pauseAfter)
        {
            pauseMenuUI.SetActive(false);
            hvezdicka.SetActive(false);
            Time.timeScale = 1f;
        }
    }//*/
}
