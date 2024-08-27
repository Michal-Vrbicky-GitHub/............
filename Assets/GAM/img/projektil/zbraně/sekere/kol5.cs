using UnityEngine;

public class ChildColliderRelay : MonoBehaviour
{
	ChainSaw parentScript;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (parentScript != null)
		{
			parentScript.OnTriggerStay2D(collision);
		}
	}

	private void Awake()
	{
		parentScript = GetComponentInParent<ChainSaw>();
	}
}
