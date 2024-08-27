using UnityEngine;
using System.Collections;
// chtìl sem zapsat èas poslední dmg a porovnávat s aktu, ale gpt vymyslela pokroèilejší
public class DamageOverTime : MonoBehaviour
{
    public int damage; // Amount of damage to apply
    private bool isColliding; // Flag to check if currently colliding
    private Aktor targetAktor; // Reference to the colliding Aktor

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has the Aktor component
        targetAktor = other.GetComponent<Aktor>();
        if (targetAktor != null)
        {
            isColliding = true;
            StartCoroutine(ApplyDamageOverTime());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other object is the same Aktor and stop applying damage                                     traktor
        if (other.GetComponent<Aktor>() == targetAktor)
        {
            isColliding = false;
            targetAktor = null;
        }
    }

    private IEnumerator ApplyDamageOverTime()
    {
        while (isColliding)
        {
            // Apply damage to the target Aktor
            if (targetAktor != null)
            {
                targetAktor.dmg(damage);
            }
            // Wait for 0.6 seconds before applying damage again
            yield return new WaitForSeconds(0.6f);
        }
    }
}
