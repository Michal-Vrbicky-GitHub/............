using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Transform target; // Cíl, který kamera sleduje (napø. postava) (šikovná gpt, to by mì nenapadlo)
    public Vector3 offset;   // Posun kamery od cíle (kamera musí býti pøed snímanou scénó, pokud nebude, bude snímat prázdný prostor, nebo, když bude v cíli snímání, bude glièovat)
    public float smoothSpeed;// Rychlost vyhlazení pohybu kamery
    public float massRatio;	 // The ratio between the character's mass and the cursor's mass, kamera sleduje barycentrum s kurzorem, né postavu.

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
			Debug.LogError("Šefe, nenastavils kameru!!!!!!!!!!!!!");
    }

    //GPT4o šikula:
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
