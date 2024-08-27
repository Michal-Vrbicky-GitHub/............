using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Pøekážka"))
		{
			Debug.Log("Collision with obstacle: " + collision.gameObject.name);
		}
        Debug.Log("Collided with " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D otter)
    {
        Debug.Log("Player triggered by " + otter.gameObject.name);
    }
}
