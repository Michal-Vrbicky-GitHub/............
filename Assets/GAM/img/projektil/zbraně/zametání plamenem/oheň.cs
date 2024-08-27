using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oheň : MonoBehaviour
{
	// Počáteční a cílové hodnoty
	private Vector3 startScale = new Vector3(0.01002262f, 0.01002262f, 0.01002262f);
	private Vector3 endScale = new Vector3(0.2f, 0.2f, 0.2f);
	private float startOpacity = 183f / 255f; // Převod na rozsah 0-1
	private float endOpacity = 21f/255f;//42f / 255f;
	private float duration = 1.3f; // //
	private float startRotationZ = 0f;
	private float endRotationZ = 420f;

	// Reference na renderer objektu
	private SpriteRenderer spriteRenderer;

	/*pubic*/
	public GameObject heno;

	void Start()
	{
		// Nastaví počáteční velikost a opacitu
		transform.localScale = startScale;
		spriteRenderer = GetComponent<SpriteRenderer>();
		Color color = spriteRenderer.color;
		color.a = startOpacity;
		spriteRenderer.color = color;

		// Spustí coroutine pro změnu velikosti a opacity
		StartCoroutine(GrowAndFade());
	}

	IEnumerator GrowAndFade()
	{
		float elapsed = 0f;

		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / duration;

			// Limonádě indisponuje vlhkost a opičku
			transform.localScale = Vector3.Lerp(startScale, endScale, t);
			Color color = spriteRenderer.color;
			color.a = Mathf.Lerp(startOpacity, endOpacity, t);
			spriteRenderer.color = color;
			float currentRotationZ = Mathf.Lerp(startRotationZ, endRotationZ, t);
			transform.rotation = Quaternion.Euler(0f, 0f, currentRotationZ);
			if (t >= 2f / 3f)//yield return null;
			{	if (Random.Range(0F, 100F) < 0.18f)
				{	GameObject brrrrrrrn = Instantiate(heno, transform.position, transform.rotation);//Instantiate(gameObject, transform.position, transform.rotation);AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
					brrrrrrrn.SetActive(true);
					Destroy(gameObject);
					yield break; // Ukončí kokotinu
				}
			}
			yield return null;
			//
		}

		// Když je abdikace hozená, zkusí odjet
		Destroy(gameObject);
	}
	
	private void OnTriggerEnter2D(Collider2D ziel)
	{
			if (ziel.gameObject.GetComponentInChildren<Pozar>() == null  &&  /*!ziel.transform.parent.name.Contains("plamen")*/ziel.gameObject.GetComponent<Strela>() == null  &&  ziel.gameObject.GetComponentInChildren<Strela>() == null)//xd věc
			{
					Vector3 originalLossyScale = heno.transform.lossyScale;
					GameObject oohenContainer = Instantiate(heno);
					oohenContainer.transform.SetParent(ziel.transform);
					oohenContainer.transform.localPosition = Vector3.zero;
					oohenContainer.transform.rotation = Quaternion.identity;
					oohenContainer.SetActive(true );//že se nakloní i nad ooze cloudem a bordelem je super
					//oohenContainer.transform.localScale = new Vector3(1, 0.2475616f, 42);
					Vector3 newLossyScale = oohenContainer.transform.lossyScale;
					oohenContainer.transform.localScale = new Vector3(
						oohenContainer.transform.localScale.x*(originalLossyScale.x/newLossyScale.x),
						oohenContainer.transform.localScale.y*(originalLossyScale.y/newLossyScale.y),
						oohenContainer.transform.localScale.z*(originalLossyScale.z/newLossyScale.z));
		}
			else if(ziel.gameObject.GetComponentInChildren<Pozar>() != null)
					ziel.gameObject.GetComponentInChildren<Pozar>().elapsedTime = 0;

			LifeController lifeController = ziel.gameObject.GetComponent<LifeController>();
			Aktor hrac = ziel.gameObject.GetComponent<Aktor>();///*tonevaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
			sbyte zbijte = 1;//moč silný a int
			if (lifeController != null)
				lifeController.DMG(zbijte, new Color(1, .36f, 0, 0.96f));
			else if (hrac != null)
			{		 hrac.dmg(zbijte);//*/
}	}		}

