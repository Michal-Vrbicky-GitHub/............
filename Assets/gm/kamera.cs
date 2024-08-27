using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Transform target; // C�l, kter� kamera sleduje (nap�. postava) (�ikovn� gpt, to by m� nenapadlo)
    public Vector3 offset;   // Posun kamery od c�le (kamera mus� b�ti p�ed sn�manou sc�n�, pokud nebude, bude sn�mat pr�zdn� prostor, nebo, kdy� bude v c�li sn�m�n�, bude gli�ovat)
    public float smoothSpeed;// Rychlost vyhlazen� pohybu kamery
    public float massRatio;	 // The ratio between the character's mass and the cursor's mass, kamera sleduje barycentrum s kurzorem, n� postavu.

    void LateUpdate(){
        if (target != null){
			Vector3 cursorWorldPosition = GetCursorWorldPosition();
			Vector3 gravitationalCenter = CalculateGravitationalCenter(target.position, cursorWorldPosition, massRatio);
			Vector3 desiredPosition	    = gravitationalCenter + offset;	//	Debug.Log(gravitationalCenter);

            //																											//
          //Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
			Debug.LogError("�efe, nenastavils kameru!!!!!!!!!!!!!");
    }

    //GPT4o �ikula:
    Vector3 GetCursorWorldPosition()
    {
        // Get the mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;
		//Debug.Log(mouseScreenPosition);

        // Convert the screen position to world position
        // Assuming the camera is orthographic
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Set the z position to the target's z position to avoid any unintended z-axis movement
        cursorWorldPosition.z = target.position.z;

        return cursorWorldPosition;
    }

    Vector3 CalculateGravitationalCenter(Vector3 targetPosition, Vector3 cursorPosition, float massRatio)
    {
        // Calculate the weighted average of the target position and the cursor position
        Vector3 gravitationalCenter = (targetPosition + cursorPosition * massRatio) / (1 + massRatio);
        return gravitationalCenter;
    }
}
