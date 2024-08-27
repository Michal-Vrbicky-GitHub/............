using UnityEngine;
using UnityEngine.UI;

public class CreateText : MonoBehaviour
{
    void Start()
    {
        // Create Canvas
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Create Text object
        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(canvasGO.transform);

        Text text = textGO.AddComponent<Text>();
        text.text = "Hello, World!";
        text.fontSize = 32;

        // Set Text color to green
        text.color = Color.green;

        // Set Text position and alignment
        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
        text.alignment = TextAnchor.MiddleCenter;

        // Load a built-in font dynamically
        Font font = Font.CreateDynamicFontFromOSFont("Arial", 32); // Replace "Arial" with your preferred system font

        // Assign the loaded font to the text
        text.font = font;
    }
}
