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
     * Ortografická kamera v Unity používá paralelní promítání, což znamená, že objekty nezmenšují svou velikost s rostoucí vzdáleností od kamery, na rozdíl od perspektivní kamery, která simuluje lidské vidìní tím, že objekty v dálce se zdají menší. To znamená, že veškeré objekty si zachovávají stejnou velikost, a už jsou blízko nebo daleko od kamery.

Výpoèet šíøky ortografické kamery
Pro ortografickou kameru v Unity je výška zorného pole kamery definována hodnotou Camera.orthographicSize, která urèuje polovinu výšky viditelné oblasti kamery v jednotkách svìtového prostoru. Šíøka zorného pole kamery je pak urèena jako:

width
=
orthographicSize
×
2
×
aspect ratio
width=orthographicSize×2×aspect ratio

orthographicSize: Polovina výšky viditelné oblasti kamery.
aspect ratio: Pomìr šíøky a výšky zorného pole kamery, což je pomìr šíøky obrazovky k její výšce.
Násobení orthographicSize hodnotou 2 nám tedy poskytuje celkovou výšku viditelné oblasti kamery, a když to vynásobíme pomìrem stran kamery, získáme celkovou šíøku viditelné oblasti.

Aktualizovaný CameraShake skript
Zde je upravený skript CameraShake, který zjišuje šíøku ortografické kamery:*/
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
