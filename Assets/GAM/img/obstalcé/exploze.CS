using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AniKill : MonoBehaviour
{
    public char typ;
    public List<float[]> dmg = new List<float[]>();//Ëac, poökozenÌ
    private Animator ani;//private Animation ani; //public AnimationClip animationClip;// = GetComponent<Animation>();;
    //short radius = 5.55;

    /*void Start()
	{   ani = GetComponent<Animation>();
		if (ani != null && ani.clip != null){
			ani.Play();
			StartCoroutine(DeleteAfterPlay(ani.clip.length));
		}else Debug.Log("Nemaö tam animu");
	}*/
    float radius;
    public CameraShake cameraShake;//kameraTŸöejk
    public float bumbrm;
  //public float shakeDuration;
    public float shakeMagnitude;
    void Start()
    {/*
        if (typ == 'b')
            dmg.Add(new float[] { 0.1f, 32f });
            //radius = 1;
        else if(typ == 'm')
        {
            dmg.Add(new float[] { 0.01f, 91f });
            dmg.Add(new float[] { .77f, 8f });
        }*/
     	switch (typ){
			case 'b':
			    dmg.Add(new float[] { 0.1f, 32f });
				break;
			case 'm':
			    dmg.Add(new float[] { 0.01f, 91f });
			    dmg.Add(new float[] { .77f, 8f });
				break;
       		case 'S':
				dmg.Add(new float[] { 0.3f, 0.1f });
				dmg.Add(new float[] { 0.6f, 0.1f });
				dmg.Add(new float[] { 0.9f, 0.1f });
				break;
            case '\0':
                //to se ned· nacpat do editora
                break;
			case 'n':
				//nic
				break;
			case 'R':
                dmg.Add(new float[] { 0.001f, 77f });
                dmg.Add(new float[] { 0.010f, 71f });
				dmg.Add(new float[] { 0.100f, 17f });
				break;
			case 'M':
				dmg.Add(new float[] { 0.1f, 11f });
				dmg.Add(new float[] { 0.3f, 33f });
				break;
			case 'G':
				dmg.Add(new float[] { 0.001f, 66f });
				dmg.Add(new float[] { 0.333f, 16f });
				dmg.Add(new float[] { 0.4995f, 012.4425f });
				dmg.Add(new float[] { 0.666f, 88f });
				break;
			case 'g':
				dmg.Add(new float[] { 0.001f, 42f });
				break;
			case 'o':
				dmg.Add(new float[] { 0.1f, 1f });
				dmg.Add(new float[] { 0.9f, 8f });
				break;
			case 'p':
				dmg.Add(new float[] { 0.2f, 0.8f });
				break;
			case 'P':
				dmg.Add(new float[] { 0.5f, 666f });
				dmg.Add(new float[] { 0.3f, 111f });
				dmg.Add(new float[] { 0.1f, 333f });
				break;
			case 'q':
				dmg.Add(new float[] { 0.42f, 0.9f });
				break;
			case 'k':
				dmg.Add(new float[] { 0.1f, 60f });
				dmg.Add(new float[] { 0.2f, 20f });
				dmg.Add(new float[] { 0.3f, 10f });
				break;
            case 'N':
                transform.position += new Vector3(0, 1.64f, 0);
				dmg.Add(new float[] { 0.01f, 101 });
				dmg.Add(new float[] { 0.20f, 020 });
                dmg.Add(new float[] { 2.12f, 012 });
                break;
			case 'Q':
				dmg.Add(new float[] { 0.01f, 42 });
				break;
			case 'F':
				dmg.Add(new float[] { 0.01f, 6 });
				dmg.Add(new float[] { .5f, 6 });
				dmg.Add(new float[] { 1, 6 });
				break;
			case 'K':
				transform.position += new Vector3(-0.6f, 0F, 0);
				break;
			case 'A':
				dmg.Add(new float[] { 0.001f, 52 });
				dmg.Add(new float[] { 0.5f, 42 });
				dmg.Add(new float[] { 1, 36 });
				break;
		}
        ani = GetComponent<Animator>();
        if (ani != null && ani.runtimeAnimatorController != null)
        {
            AnimationClip[] clips = ani.runtimeAnimatorController.animationClips;
            if (clips.Length > 0)
            {
                //float shakeDuration;
                string animationName = clips[0].name;
                ani.Play(animationName);
                float animLength = clips[0].length;
                //radius = clips[0].width * 1.2f;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                radius = spriteRenderer.bounds.size.x * 0.6f;
                StartCoroutine(DeleteAfterPlay(animLength));
                StartCoroutine(ApplyDamageOverTime());
                cameraShake.StartShake(animLength, shakeMagnitude, transform.position);/**/
                cameraShake.SetCameraExplosionPosition(transform.position, bumbrm);//cameraShake.SetCameraOffset(transform.position);
            }
            else
            {
                Debug.Log("Anim·tor nem· û·dnÈ animace :( :( :( :(");
            }
        }
        else Debug.Log("Nem·ö tam Anim·tora nebo ControlÈra AAAAAAAA");
    }

	/*    public void PlayAndDestroy()//ssek
        {	if (ani != null && ani.clip != null){
                ani.Play();
                StartCoroutine(DeleteAfterPlay(ani.clip.length));
            }
        }*/
	public GameObject spawn;
    private IEnumerator DeleteAfterPlay(float delay)
    {
		if(/*typ != 'S'*/spawn == null)
            yield return new WaitForSeconds(delay-0.08f);//uk·ûe 1. snÌmek, je pot¯eba zkr·tiù
		else{
			yield return new WaitForSeconds(delay/3);
			spawn = Instantiate(spawn, transform.position, Quaternion.identity); spawn.SetActive(true);
			///*GameObject spawn = */Instantiate(this.spawn, transform.position, Quaternion.identity);// spawn.SetActive(true);
			yield return new WaitForSeconds(delay*2/3 -0.08f);
		}
        Destroy(gameObject);
    }

	private void OnDisable(){
		Destroy(gameObject);
	}

	private IEnumerator ApplyDamageOverTime()
    {
        foreach (var dmgPair in dmg)
        {
            yield return new WaitForSeconds(dmgPair[0]);
            ApplyDamage(dmgPair[1]);
        }
    }

    private void ApplyDamage(float dogmage)
    {
        //float radius = 7F;
        /**/DrawCircle(transform.position, radius); DrawCircleJeste(transform.position, radius); /**/DrawDamageIndicators(transform.position, dogmage);//*//
        Debug.DrawLine(transform.position, transform.position + Vector3.up * radius, Color.red, 42);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius); //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 666f);//lze bez pouûitÌ Collider2D???
        foreach (var hitCollider in hitColliders)
        {
            Vector2 colliderPosition = hitCollider.transform.position;
            float distance = Vector2.Distance(transform.position, colliderPosition);
            float normalizedDistance = Mathf.InverseLerp(0, radius, distance);
            float damage = Mathf.Lerp(dogmage * 1.11f, dogmage * 0.06f, normalizedDistance);//float damage = Mathf.Lerp(111, 6, normalizedDistance);
            damage = Mathf.Pow(damage, 1.11f);
            Debug.Log("Collider2D: " + hitCollider.name + "\nDMG: " + damage);
            var barel = hitCollider.GetComponent<LifeController>();
            if (barel != null  &&  typ != 'S')
            {
                int kulatÈPoökozenÌ = (int)Math.Round(damage, MidpointRounding.AwayFromZero);
				barel.DMG(kulatÈPoökozenÌ);//barel.û -= kulatÈPoökozenÌ;
				continue;
            }

            var actor = hitCollider.GetComponent<Aktor>();
            if (actor != null)
            {
                actor.dmg(damage);
            }
        }
    }

    private void DrawCircleJeste(Vector3 center, float radius)
    {
        int segments = 30; // Number of segments to approximate the circle
        float angle = 0f;
        float angleIncrement = 360f / segments;

        for (int i = 0; i < segments; i++)
        {
            float x1 = center.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y1 = center.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            float x2 = center.x + radius * Mathf.Cos(Mathf.Deg2Rad * (angle + angleIncrement));
            float y2 = center.y + radius * Mathf.Sin(Mathf.Deg2Rad * (angle + angleIncrement));

            Debug.DrawLine(new Vector3(x1, y1, center.z), new Vector3(x2, y2, center.z), Color.red, 10.10f);//durejön
            angle += angleIncrement;
        }
    }
    private void DrawCircle(Vector3 center, float radius)
    {
        int segments = 36; // Number of segments to approximate the circle
        float angle = 0f;
        float angleIncrement = 360f / segments;

        Vector3 previousPoint = center + new Vector3(radius, 0, 0);
        for (int i = 1; i <= segments; i++)
        {
            angle += angleIncrement;
            Vector3 newPoint = center + new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * angle), radius * Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            Debug.DrawLine(previousPoint, newPoint, Color.red, 8f);//zajÌmav˝ todleto
            previousPoint = newPoint;
        }
    }/*
    private void DrawDamageIndicators(Vector3 center, float baseDamage)
    {
        float damage33 = baseDamage * 0.33f;
        float damage66 = baseDamage * 0.66f;

        // Calculate radii where damage is 33% and 66% of baseDamage
        /*
        float radius33 = CalculateRadiusForDamage(center, damage33);
        float radius66 = CalculateRadiusForDamage(center, damage66);*//*
        float radius33 = CalculateRadiusForDamage(damage33);
        float radius66 = CalculateRadiusForDamage(damage66);

        // Draw circles at these radii
        DrawCircle(center, radius33);
        DrawCircle(center, radius66);
    }
    /*
    private float CalculateRadiusForDamage(Vector3 center, float targetDamage)
    {
        float radius = 0f;
        float step = radius / 100f;
        for (float r = step; r <= radius; r += step)
        {
            Vector3 point = center + new Vector3(r, 0, 0);
            float distance = Vector2.Distance(center, point);
            float normalizedDistance = Mathf.InverseLerp(0, radius, distance);
            float damage = Mathf.Lerp(111, 6, normalizedDistance);

            // Exponential falloff
            damage = Mathf.Pow(damage, 1.5f); // Adjust exponent as needed

            if (Mathf.Approximately(damage, targetDamage))
            {
                radius = r;
                break;
            }
        }
        return radius;
    }*//*
    private float CalculateRadiusForDamage(float targetDamage)
    {
        float step = radius / 100f;
        for (float r = 0; r <= radius; r += step)
        {
            float distance = r;
            float normalizedDistance = Mathf.InverseLerp(0, radius, distance);
            float damage = Mathf.Lerp(111, 6, normalizedDistance);
            damage = Mathf.Pow(damage, 2.1f);

            if (Mathf.Approximately(damage, targetDamage))
            {
                return r;
            }
        }
        return radius; // Fallback to max radius if no exact match is found
    }*//*
    private float CalculateRadiusForDamage(float targetDamage)
    {
        // The calculation uses an iterative approach to find the radius
        float step = radius / 100f;
        for (float r = 0; r <= radius; r += step)
        {
            float distance = r;
            float normalizedDistance = Mathf.InverseLerp(0, radius, distance);
            float damage = Mathf.Lerp(111, 6, normalizedDistance);
            damage = Mathf.Pow(damage, 2.1f);

            // Check if the damage is close to the targetDamage
            if (Mathf.Approximately(damage, targetDamage) || Mathf.Abs(damage - targetDamage) < 0.1f)
            {
                return r;
            }
        }
        return radius; // Return max radius if no exact match is found
    }*//*
    float CalculateRadiusForDamage(float targetDamage)
    {
        float step = radius / 100f;
        for (float r = 0; r <= radius; r += step)
        {
            float distance = r;
            float normalizedDistance = Mathf.InverseLerp(0, radius, distance);
            float damage = Mathf.Lerp(111, 6, normalizedDistance);
            damage = Mathf.Pow(damage, 2.1f);

            if (Mathf.Approximately(damage, targetDamage) || Mathf.Abs(damage - targetDamage) < 0.1f)
            {
                return r;
            }
        }
        return radius; // Return max radius if no exact match is found
    }*/
    private void DrawDamageIndicators(Vector3 center, float baseDamage)
    {
        float damage33 = 0.33f * 111f; //33% of the max damage
        float damage66 = 0.66f * 111f; //66% of the max damage

        float radius33 = CalculateRadiusForDamage(damage33, 111f, 6f, radius);
        float radius66 = CalculateRadiusForDamage(damage66, 111f, 6f, radius);

        DrawCircle(center, radius33);
        DrawCircle(center, radius66);
    }

    private float CalculateRadiusForDamage(float targetDamage, float maxDamage, float minDamage, float maxRadius)
    {
        float low = 0;
        float high = maxRadius;
        while (high - low > 0.01f)
        {
            float mid = (low + high) / 2f;
            float normalizedDistance = Mathf.InverseLerp(0, maxRadius, mid);
            float damage = Mathf.Lerp(maxDamage, minDamage, normalizedDistance);
            damage = Mathf.Pow(damage, 1.11f);//.95f
            if (damage < targetDamage)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        return (low + high) / 2f;
    }
}