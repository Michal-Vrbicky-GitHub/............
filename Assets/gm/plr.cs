using UnityEngine; using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f; // Rychlost pohybu
	public GameObject boundaryObject; // GameObject, kter� p�edstavuje �tverec
	public float minimumMoveDistance; // Minim�ln� vzd�lenost pohybu

	private Vector2 minBounds; // Minim�ln� hranice (lev� doln� roh �tverce)
	private Vector2 maxBounds; // Maxim�ln� hranice (prav� horn� roh �tverce)
	private Vector2 startMovePosition; // Po��te�n� pozice p�i zah�jen� pohybu
	private bool isMoving = false; // Flag indikuj�c�, zda je postava v pohybu
	public Vector2 moveDirection; // Sm�r pohybu
	private bool minimumDistanceReached = false; // Flag indikuj�c�, zda byla dosa�ena minim�ln� vzd�lenost

    private bool isDashing = false; // flegma je latinsky hlen
    public int dashValue = 3; // Maxim�ln� po�et dash�
    public int currentDash; // Aktu�ln� po�et dostupn�ch dash�
    public float dashCooldown = 2.2f; // �as mezi regeneracemi dash�
    public float dashSpeedMultiplier = 5f; // Sou�initel n�sobitele koeficienta �inite�u rychlosti p�i dashupu
    public float dashDuration = 0.16f; // Trv�n� jednoho dashu... 4o je holt chyt�ej��

    private Rigidbody2D ryby; // Reference na Rigidbody2D komponentu

    //public GameObject leftLeg; // Reference na lev� objekt nohy
    Transform leftLeg;
    Transform rightLeg;         //nastavovat v unity!!!
    public float legMovementAmplitude = 0.1f; // Amp
    public float legMovementFrequency = 2f; // f
    private float legMovementTime = 0f; // t

    public bool dshGnd;
	public bool dshFlsh;
    public GameObject flshGnd;

	Rigidbody2D rb;

	void Start()
	{	currentDash = dashValue; // Inicializace dostupn�ch dash�, c�? Ini na max p�i za��tku
		ryby = GetComponent<Rigidbody2D>(); // Referen�n� reference pro z�sk�n� reference na referenci Referentbody2D referuj�c� komponentu referenc�
        if (boundaryObject != null)
		{
			// Z�sk�n� velikosti a pozice �tverce
			Vector2 boundaryPosition = boundaryObject.transform.position;
			Vector2 boundarySize = boundaryObject.transform.localScale;

			// V�po�et hranic �tverce
			minBounds = boundaryPosition - (boundarySize / 2);
			maxBounds = boundaryPosition + (boundarySize / 2);
		}
		else
		{
			Debug.LogError("AAAAAAAAA!!\nBoundary object is not set!");
		}
        StartCoroutine(RegenerateDash());
        Time.timeScale = 1f;
        leftLeg = transform.Find("bl");
        rightLeg = transform.Find("bp");
		rb = GetComponent<Rigidbody2D>();

        //flshGnd = GameObject.Find("fle�"); nechce se mu hledat :(
        //ale tamten na�el
	}

	void Update()
	{
		HandleInput();
		//MovePlayer();
        //UpdateDash();
    }
    /**/void FixedUpdate()//v update b�� v editoru pomalu, v buildnutym dob�e, ve fixedupdate oboje dob�de AAAAAAAAAAAAAAAAAAAAAAAAAAA
    {	if (!GetComponent<Aktor>().mrkev){
            MovePlayer();
            UpdateDash();
            UpdateLegMovement();
		}
	}/**/

    void HandleInput()
	{
		// Z�sk�n� vstupn�ch hodnot
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (!isMoving){
			if (moveX != 0 || moveY != 0){
				isMoving = true;
				startMovePosition = transform.position;
				moveDirection = new Vector2(moveX, moveY).normalized;
				minimumDistanceReached = false;
		}	}
		else
		{
			Vector2 currentPosition = transform.position;
			float distanceMoved = Vector2.Distance(currentPosition, startMovePosition);

			if (distanceMoved >= minimumMoveDistance)
			{
				minimumDistanceReached = true;
			}

			if (!minimumDistanceReached)
			{	// Ignorov�n� opa�n�ch sm�r�
				if ((moveDirection.x > 0 && moveX < 0) || (moveDirection.x < 0 && moveX > 0))
				{
					moveX = 0;
				}
				if ((moveDirection.y > 0 && moveY < 0) || (moveDirection.y < 0 && moveY > 0))
				{
					moveY = 0;
				}
			}

			// Aktualizace sm�ru pohybu
			if (moveX != 0 || moveY != 0)
			{
				moveDirection = new Vector2(moveX, moveY).normalized;
			}

			if (minimumDistanceReached && moveX == 0 && moveY == 0)
			{
				isMoving = false;
			}
		}
	}

	void MovePlayer()
	{	if (isDashing) return;
		if (isMoving)
		{   // Vypo��t�n� nov� pozice
			Vector3 newPosition = transform.position + (Vector3)moveDirection * moveSpeed * Time.fixedDeltaTime;

			// Omezen� pohybu postavy uvnit� �tverce
			newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
			newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
			if (newPosition.x <= minBounds.x || newPosition.x >= maxBounds.x ||
				newPosition.y <= minBounds.y || newPosition.y >= maxBounds.y)
				minimumDistanceReached = true;

			/* Aktualizace pozice postavy
			 *transform.position = newPosition;
			 *rb �e�� colisij�n*/
            ryby.MovePosition(newPosition);
        }
	}

    void UpdateDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentDash > 0)
        {
            StartCoroutine(Dash());
            //b�m
        }
    }

	IEnumerator Dash()
    {
        currentDash--;
        isDashing = true;


		if (dshFlsh){
            GameObject Fgnd = Instantiate(flshGnd, transform.position, transform.rotation);
            Fgnd.SetActive(true);
		}


		float dashStartTime = Time.time;

        // Ur�en� sm�ru dashE
        //Vector3 dashDirection;
        Vector3 dashDirection = (Vector3)moveDirection;
        if (!isMoving)//moveDirection != Vector2.zero)
        {// Pou�ijeme posledn� sm�r pohybu, pokud existujesaeilughsdilughsd�iuhsd�iuhds�iuvhbnsdliugvhsdliusdv
			/*
            dashDirection = (Vector3)moveDirection;
        }
        else
        {*/
            // Pokud nen� ��dn� sm�r pohybu, pou�ijeme sm�r kurzoru
            Vector3 cursorWorldPosition = GetCursorWorldPosition();
            dashDirection = (cursorWorldPosition - transform.position).normalized;
        }

        while (Time.time < dashStartTime + dashDuration)
        {
            Vector3 dashPosition = transform.position + dashDirection * moveSpeed * dashSpeedMultiplier * Time.fixedDeltaTime;//Time.deltaTime; zase fixed mu�� bejt, dy� neni, zlob�
            ryby.MovePosition(dashPosition); //transform.position = dashPosition;

            // Omezen� pohybu postavy uvnit� �tverce
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
                transform.position.z
            );
			Camera.main.transform.position += dashDirection.normalized*.747f;
            yield return new WaitForFixedUpdate();//FFFFFFIIIIIIIIIIIIKSSSSSSSSSSS
            //yield return null;
        }

        isDashing = false;
    }

    IEnumerator RegenerateDash()
    {
        while (true)
        {
            if (currentDash < dashValue)
            {
                yield return new WaitForSeconds(dashCooldown);
                currentDash++;
            }
            else
            {
                yield return null;
            }
        }
    }

    Vector3 GetCursorWorldPosition()
    {
        // Get the mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the screen position to world position
        // Assuming the camera is orthographic
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Set the z position to the target's z position to avoid any unintended z-axis movement
        cursorWorldPosition.z = transform.position.z;

        return cursorWorldPosition;
    }/*

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("P�ek�ka"))
		{//3.5/4omini
			isMoving = false; // Zastaven� hr��e p�i n�razu do sudu
			Debug.Log("Player collided with a barrel!");
		}
	}*/

    void UpdateLegMovement()
    {
        /*if (leftLeg == null || rightLeg == null) return;

        legMovementTime += Time.fixedDeltaTime * legMovementFrequency;

        float leftLegOffset = Mathf.Sin(legMovementTime) * legMovementAmplitude;
        float rightLegOffset = Mathf.Sin(legMovementTime + Mathf.PI) * legMovementAmplitude; // Opa�n� f�ze pro druhou nohu

        leftLeg.transform.localPosition = new Vector3(leftLeg.transform.localPosition.x, leftLegOffset, leftLeg.transform.localPosition.z);
        rightLeg.transform.localPosition = new Vector3(rightLeg.transform.localPosition.x, rightLegOffset, rightLeg.transform.localPosition.z);
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         
         */
        if (isMoving)
        {
            legMovementTime += Time.fixedDeltaTime * legMovementFrequency;

            float leftLegOffset = Mathf.Sin(legMovementTime) * legMovementAmplitude;
            float rightLegOffset = Mathf.Sin(legMovementTime + Mathf.PI) * legMovementAmplitude;

            leftLeg.localPosition = new Vector3(leftLeg.localPosition.x, leftLegOffset, leftLeg.localPosition.z);
            rightLeg.localPosition = new Vector3(rightLeg.localPosition.x, rightLegOffset, rightLeg.localPosition.z);
        }else{
            leftLeg.localPosition = new Vector3(leftLeg.localPosition.x, 0, leftLeg.localPosition.z);
            rightLeg.localPosition = new Vector3(rightLeg.localPosition.x, 0, rightLeg.localPosition.z);
        }
    }

	void OnCollisionExit2D(Collision2D collision){/*
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;*/
        StartCoroutine(NeuletProsimte());}

	IEnumerator NeuletProsimte()
	{   float duration = rb.velocity.magnitude/2;
		Vector2 initialVelocity = rb.velocity;
		float elapsedTime = 0f;
		while (elapsedTime < duration){
			elapsedTime += Time.deltaTime;
			rb.velocity = Vector2.Lerp(initialVelocity, Vector2.zero, elapsedTime / duration);
			rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0f, elapsedTime / duration);
			yield return null;}
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
	}
}

//106