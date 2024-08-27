using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public CameraFollow cameraFollow;
    private float cameraWidth;
    Vector3 originalPos;
    public int up;

    void Start(){
        originalPos = cameraFollow.transform.position;
        cameraWidth = CalculateCameraWidth();
        up=1;
    }

    public void StartShake(float shakeDuration, float shakeMagnitude, Vector3 explosionPosition){
		StartCoroutine(Shake(shakeDuration, shakeMagnitude*CalculateAttenuation(explosionPosition)/up));
	}

	private IEnumerator Shake(float shakeDuration, float shakeMagnitude){
        float elapsed = 0.0f;
        while (elapsed < shakeDuration){
            originalPos = cameraFollow.transform.position;
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            cameraFollow.transform.position = originalPos + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        //cameraFollow.transform.position = originalPos;
    }

    public void SetCameraOffset(Vector3 explosionPosition, float distance)
	{
		Vector3 direction = (transform.position - explosionPosition).normalized;
		cameraFollow.offset += direction * distance;
	}

    public void SetCameraExplosionPosition(Vector3 explosionPosition, float explosionPushDistance){/**/
        Vector3 direction = (cameraFollow.transform.position - explosionPosition).normalized;
        cameraFollow.transform.position += direction * explosionPushDistance * CalculateAttenuation(explosionPosition)/up;
        originalPos = cameraFollow.transform.position;//*/
    }

    private float CalculateAttenuation(Vector3 explosionPosition)    {
        float distance = Vector3.Distance(cameraFollow.transform.position, explosionPosition);
        return Mathf.Exp(-distance / cameraWidth);
    }
    /*
     * Ortografick� kamera v Unity pou��v� paraleln� prom�t�n�, co� znamen�, �e objekty nezmen�uj� svou velikost s rostouc� vzd�lenost� od kamery, na rozd�l od perspektivn� kamery, kter� simuluje lidsk� vid�n� t�m, �e objekty v d�lce se zdaj� men��. To znamen�, �e ve�ker� objekty si zachov�vaj� stejnou velikost, a� u� jsou bl�zko nebo daleko od kamery.

V�po�et ���ky ortografick� kamery
Pro ortografickou kameru v Unity je v��ka zorn�ho pole kamery definov�na hodnotou Camera.orthographicSize, kter� ur�uje polovinu v��ky viditeln� oblasti kamery v jednotk�ch sv�tov�ho prostoru. ���ka zorn�ho pole kamery je pak ur�ena jako:

width
=
orthographicSize
�
2
�
aspect�ratio
width=orthographicSize�2�aspect�ratio

orthographicSize: Polovina v��ky viditeln� oblasti kamery.
aspect ratio: Pom�r ���ky a v��ky zorn�ho pole kamery, co� je pom�r ���ky obrazovky k jej� v��ce.
N�soben� orthographicSize hodnotou 2 n�m tedy poskytuje celkovou v��ku viditeln� oblasti kamery, a kdy� to vyn�sob�me pom�rem stran kamery, z�sk�me celkovou ���ku viditeln� oblasti.

Aktualizovan� CameraShake skript
Zde je upraven� skript CameraShake, kter� zji��uje ���ku ortografick� kamery:*/
    private float CalculateCameraWidth()
    {
        Camera camera = Camera.main;
        if (camera.orthographic)
        {
            return camera.orthographicSize * 2.0f * camera.aspect;
        }
        else
        {
            Debug.LogError("CameraShake only supports orthographic cameras.");
            return 20.0f; // Default width if not orthogodox
        }
    }
}
