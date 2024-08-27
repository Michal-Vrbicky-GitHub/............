using UnityEngine;
using UnityEngine.UI;

public class Kurbor : MonoBehaviour{
	private /*Rect*/Transform cursorTransform;
    public Vector2 offset;

    void Start(){
		cursorTransform = GetComponent<Transform>();
		/*//*/Cursor.visible = false;
	}

	void Update(){/*
		Vector2 cursorPos = Input.mousePosition;
        cursorTransform.position = cursorPos;*/
        Vector2 cursorPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorTransform.position = worldPos + offset;
    }	}
