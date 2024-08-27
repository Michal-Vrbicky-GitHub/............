using System.IO;
using UnityEngine;

public class CaptureCamera : MonoBehaviour
{
    public Camera cameraToCapture; // Kamera, jej� obraz chcete zachytit
    public int imageWidth = 1920;  // ���ka v�sledn�ho obr�zku
    public int imageHeight = 1080; // V��ka v�sledn�ho obr�zku
    public string fileName = "CameraCapture.png"; // N�zev souboru

    void Start()
    {
        if (cameraToCapture == null)
        {
            cameraToCapture = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Stiskn�te kl�vesu "C" pro zachycen� obrazu
        {
            CaptureAndSaveImage();
        }
    }

    void CaptureAndSaveImage()
    {
        RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
        cameraToCapture.targetTexture = renderTexture;
        Texture2D texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);

        cameraToCapture.Render();

        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
        texture.Apply();

        cameraToCapture.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Invertov�n� barev
        Color[] pixels = texture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i].r = 1.0f - pixels[i].r;
            pixels[i].g = 1.0f - pixels[i].g;
            pixels[i].b = 1.0f - pixels[i].b;
        }
        texture.SetPixels(pixels);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        string directoryPath = Path.Combine(Application.dataPath, "menu");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string filePath = Path.Combine(directoryPath, fileName);
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Image saved: " + filePath);
    }
}
