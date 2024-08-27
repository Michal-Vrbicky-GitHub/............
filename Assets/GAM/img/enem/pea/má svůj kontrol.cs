using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControllerForPeaShooter : LifeController
{
	public Renderer hlava;
	public Renderer stonek;
	protected override void Start()
	{	originalColor = hlava.material.color;
		rb = GetComponent<Rigidbody2D>();
	}

	protected override IEnumerator ChangeColorRoutine(Color newColor, float duration)
	{
		hlava.material.color = newColor;
		stonek.material.color = newColor;
		yield return new WaitForSeconds(duration);
		hlava.material.color = originalColor;
		stonek.material.color = originalColor;
	}
}
