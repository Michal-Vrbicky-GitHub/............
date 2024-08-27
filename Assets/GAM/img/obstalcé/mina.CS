using Unity.VisualScripting;
using UnityEngine;

public class Mima : MonoBehaviour
{
    public GameObject bum;

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.GetComponent<Aktor>() || other.gameObject.GetComponent<sek>() || other.gameObject.GetComponent<ChildColliderRelay>()){
            GameObject klon = Instantiate(bum, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
            klon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
