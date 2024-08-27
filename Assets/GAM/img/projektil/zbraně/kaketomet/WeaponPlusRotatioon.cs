using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlusRotatioon : Gun
{
	protected override /*virtual*/ void Awake()
	{
		devadesat = 0;
		base.Awake();
	}

	void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		Vector2 direction = mousePosition - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
		base.Update();
	}
}
