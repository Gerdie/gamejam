using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[HideInInspector] public bool facingRight;
	[HideInInspector] public bool jump;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool grounded;
	public LayerMask groundLayer;
//	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		facingRight = true;
		jump = false;
		grounded = false;
//		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

//		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
//		grounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
		grounded = Physics2D.OverlapArea(groundCheck.position, groundCheck.position, groundLayer);

		print (grounded);
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = true;
		}

	}

	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");

//		anim.SetFloat("Speed", Mathf.Abs(h));

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump) {
//			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		groundCheck.transform.position = new Vector2(rb2d.position.x, rb2d.position.y);
		print (groundCheck.transform.position.y);
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
