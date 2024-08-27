using UnityEngine;
using System.Collections;
using System.IO;

public class TextImageCutter : MonoBehaviour
{
    public Texture2D sourceImage;  // Pùvodní obrázek
    public string textToCut;       // Text, podle kterého se obrázek oøízne
    public Font font;              // Písmo, které bude použito pro text
    public int fontSize = 50;      // Velikost písma

    void Start()
    {
        Texture2D textImage = GenerateTextImage(textToCut, font, fontSize);
        Texture2D cutImage = CutImageByText(sourceImage, textImage);
        SaveTextureAsPNG(cutImage, "Assets/Menu/CutImage.png");
    }

    Texture2D GenerateTextImage(string text, Font font, int fontSize)
    {
        // Vytvoøení renderovací textury pro text
        RenderTexture renderTexture = new RenderTexture(1024, 1024, 24);
        RenderTexture.active = renderTexture;

        // Nastavení textu
        GameObject textObj = new GameObject("Text");
        TextMesh textMesh = textObj.AddComponent<TextMesh>();
        textMesh.text = text;
        textMesh.font = font;
        textMesh.fontSize = fontSize;
        textMesh.color = Color.white;

        // Umístìní kamery
        Camera camera = new GameObject("Camera").AddComponent<Camera>();
        camera.clearFlags = CameraClearFlags.Color;
        camera.backgroundColor = Color.clear;
        camera.orthographic = true;
        camera.orthographicSize = 5;
        camera.targetTexture = renderTexture;

        // Renderování textu
        camera.Render();

        // Pøevod renderované textury na Texture2D
        Texture2D textImage = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        textImage.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        textImage.Apply();

        // Uklizení
        RenderTexture.active = null;
        DestroyImmediate(textObj);
        DestroyImmediate(camera.gameObject);
        DestroyImmediate(renderTexture);

        return textImage;
    }

    Texture2D CutImageByText(Texture2D source, Texture2D textImage)
    {
        Texture2D cutImage = new Texture2D(source.width, source.height, TextureFormat.ARGB32, false);

        for (int y = 0; y < source.height; y++)
        {
            for (int x = 0; x < source.width; x++)
            {
                Color textColor = textImage.GetPixel(x, y);
                if (textColor.a > 0.5f)  // Pokud je pixel textu neprùhledný
                {
                    cutImage.SetPixel(x, y, source.GetPixel(x, y));
                }
                else
                {
                    cutImage.SetPixel(x, y, Color.clear);
                }
            }
        }
        cutImage.Apply();
        return cutImage;
    }

    void SaveTextureAsPNG(Texture2D texture, string filePath)
    {
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Saved PNG file to {filePath}");
    }
}
/*using UnityEngine;
using System.Collections;
using System.IO;

public class TextImageCutter : MonoBehaviour
{
    public Texture2D sourceImage;  // Pùvodní obrázek
    public string textToCut;       // Text, podle kterého se obrázek oøízne
    public Font font;              // Písmo, které bude použito pro text
    public int fontSize = 50;      // Velikost písma
    public Vector2 textPosition;   // Pozice textu v obrázku

    void Start()
    {
        Texture2D textImage = GenerateTextImage(textToCut, font, fontSize, textPosition);
        Texture2D cutImage = CutImageByText(sourceImage, textImage);
        SaveTextureAsPNG(cutImage, "Assets/Menu/CutImage.png");
    }

    Texture2D GenerateTextImage(string text, Font font, int fontSize, Vector2 position)
    {
        // Create a temporary RenderTexture
        int textureWidth = sourceImage.width;
        int textureHeight = sourceImage.height;
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 24);
        RenderTexture.active = renderTexture;

        // Create a temporary canvas
        GameObject canvasObj = new GameObject("Canvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;

        // Create a temporary camera
        Camera camera = new GameObject("Camera").AddComponent<Camera>();
        camera.clearFlags = CameraClearFlags.Color;
        camera.backgroundColor = Color.clear;
        camera.orthographic = true;
        camera.orthographicSize = textureHeight / 2;  // Adjust based on texture height
        camera.targetTexture = renderTexture;
        canvas.worldCamera = camera;

        // Create a temporary UI Text element
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(canvas.transform);
        RectTransform rectTransform = textObj.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(textureWidth, textureHeight);
        rectTransform.anchoredPosition = position;

        UnityEngine.UI.Text uiText = textObj.AddComponent<UnityEngine.UI.Text>();
        uiText.text = text;
        uiText.font = font;
        uiText.fontSize = fontSize;
        uiText.color = Color.white;
        uiText.alignment = TextAnchor.MiddleCenter;

        // Adjust the size of the text
        uiText.resizeTextForBestFit = true;
        uiText.resizeTextMinSize = fontSize;
        uiText.resizeTextMaxSize = fontSize;

        // Render the text
        canvasObj.transform.position = new Vector3(textureWidth / 2, textureHeight / 2, 0);
        camera.Render();

        // Convert the RenderTexture to a Texture2D
        Texture2D textImage = new Texture2D(textureWidth, textureHeight, TextureFormat.ARGB32, false);
        textImage.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        textImage.Apply();

        // Cleanup
        RenderTexture.active = null;
        DestroyImmediate(textObj);
        DestroyImmediate(canvasObj);
        DestroyImmediate(camera.gameObject);
        DestroyImmediate(renderTexture);

        return textImage;
    }

    Texture2D CutImageByText(Texture2D source, Texture2D textImage)
    {
        Texture2D cutImage = new Texture2D(source.width, source.height, TextureFormat.ARGB32, false);

        for (int y = 0; y < source.height; y++)
        {
            for (int x = 0; x < source.width; x++)
            {
                Color textColor = textImage.GetPixel(x, y);
                if (textColor.a > 0.5f)  // Pokud je pixel textu neprùhledný
                {
                    cutImage.SetPixel(x, y, source.GetPixel(x, y));
                }
                else
                {
                    cutImage.SetPixel(x, y, Color.clear);
                }
            }
        }
        cutImage.Apply();
        return cutImage;
    }

    void SaveTextureAsPNG(Texture2D texture, string filePath)
    {
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Saved PNG file to {filePath}");
    }
}
*/