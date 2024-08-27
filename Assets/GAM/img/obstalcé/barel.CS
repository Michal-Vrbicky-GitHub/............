using UnityEngine;
using System.Collections;
public class LifeController : MonoBehaviour
{
	public int ž;
	public GameObject boom;

	protected float colorChangeDuration = .3f;
	protected Renderer objRenderer;
	protected Color originalColor;

	protected Rigidbody2D rb;

	void Update()
	{	if (ž <= 0){
			GameObject klon = Instantiate(boom, transform.position, Quaternion.identity);
			klon.SetActive(true);
			//gameObject.SetActive(false);//aaaa je tu bordel
            Destroy(gameObject);//lepèi
        }if(objRenderer==null) Debug.LogError("WTF najednou AAAAAAAAAAAAAAA");
	}

	public void DMG(int dmg){
		ž -= dmg;//volá se to vejš a dyš je vejš disablovanej lifecontroller a podnim je jeden enablovanej, je to blbý
		StartCoroutine(ChangeColorRoutine(Color.red, colorChangeDuration));
	}

	public void DMG(int dmg, Color kvuliKoze)
	{
		ž -= dmg;
		StartCoroutine(ChangeColorRoutine(kvuliKoze, colorChangeDuration));
	}

	protected virtual IEnumerator ChangeColorRoutine(Color newColor, float duration)
	{
		objRenderer.material.color = newColor;
		yield return new WaitForSeconds(duration);
		objRenderer.material.color = originalColor;
	}

	protected virtual void Start()
	{	objRenderer = GetComponent<Renderer>();
		if (objRenderer == null)
			objRenderer = GetComponentInChildren<Renderer>();
		if (objRenderer != null)
			originalColor = objRenderer.material.color;
		else
			Debug.LogError("Objekt nemá Renderer komponentu!");
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;//nemusí to kopnout až do pièe
	}
}
