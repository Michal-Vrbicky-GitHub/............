using UnityEngine;

public class BarrelCollisionDebug : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Barrel collided with " + collision.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Barrel triggered by " + other.gameObject.name);
	}
}
